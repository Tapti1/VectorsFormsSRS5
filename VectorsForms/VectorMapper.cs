using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class VectorMapper
    {
        //мапер только для коллекций
        protected static DBConnection _connection = null;

        Mapper mapper;
        public VectorMapper()
        {
            if (_connection == null)
            {
                _connection = new DBConnection(@"Data Source=DESKTOP-RQ1TD73\SQLEXPRESS;Initial Catalog=VectorsBase;Integrated Security=True");
            }
            mapper=new Mapper("vectors");
        }
        public List<Vector> SelectAll()
        {            
            string query = $"SELECT * FROM vectors";
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            List<int> ids= new List<int>();
            List<Vector> ret = new List<Vector>();

            _connection.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                ids.Add(id);
            }
            reader.Close();

            for(int i = 0; i < ids.Count(); i++)
            {
                ret.Add((Vector)mapper.GetById(ids[i]));
            }
            _connection.closeConnection();

            return ret;
        }   
    }
}
