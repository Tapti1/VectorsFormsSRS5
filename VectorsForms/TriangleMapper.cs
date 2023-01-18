using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class TriangleMapper
    {
        //мапер только для коллекций
        protected static DBConnection _connection = null;
        Mapper mapper;
        public TriangleMapper()
        {
            if (_connection == null)
            {
                _connection = new DBConnection(@"Data Source=DESKTOP-RQ1TD73\SQLEXPRESS;Initial Catalog=VectorsBase;Integrated Security=True");
            }
            mapper = new Mapper("triangles");
        }
        public List<Triangle> SelectAll()
        {
            string query = $"SELECT * FROM triangles";
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            List<Triangle> ret = new List<Triangle>();
            List<int> ids = new List<int>();

            _connection.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                ids.Add(id);
            }
            reader.Close();

            for (int i = 0; i < ids.Count(); i++)
            {
                ret.Add((Triangle)mapper.GetById(ids[i]));
            }
            _connection.closeConnection();

            return ret;
        }
     
    }
}
