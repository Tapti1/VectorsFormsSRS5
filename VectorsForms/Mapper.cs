using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsForms
{
    
    internal class Mapper
    {
        //основной мапер
        protected string tableName;
        protected static DBConnection _connection = null;
        public Mapper(string tableName)
        {
            if (_connection == null)
            {
                _connection = new DBConnection(@"Data Source=DESKTOP-RQ1TD73\SQLEXPRESS;Initial Catalog=VectorsBase;Integrated Security=True");
            }

            this.tableName = tableName;
        }        

        public void Insert(DomainObject v)
        {
            string query = $"insert into {v.InsertObjectString()})";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            cmd.ExecuteNonQuery();
            _connection.closeConnection();
        }
        public DomainObject GetById(int id)
        {
            string query = $"SELECT * FROM {tableName} WHERE id={id}";
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            List<string> par = new List<string>();
            _connection.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            par.Add(Convert.ToString(reader.GetInt32(0)));
            par.Add(Convert.ToString(reader.GetValue(1)));
            par.Add(Convert.ToString(reader.GetValue(2)));
            reader.Close();
            _connection.closeConnection();

            //рефлексия
            string className=CamelCase.GetClassName(tableName);
            Type type = Type.GetType($"VectorsForms.{className}");
            System.Reflection.ConstructorInfo ci = type.GetConstructor(new Type[] { typeof(List<string>) });
            
            return (DomainObject) ci.Invoke(new object[] {par});
        }
        public bool Delete(int id)
        {
            string query = $"DELETE FROM {tableName} WHERE id={id}";

            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            int num = cmd.ExecuteNonQuery();
            _connection.closeConnection();

            return num > 0;
        }
        public bool Update(DomainObject new_v)
        {
            string query = $"UPDATE {tableName} SET {new_v.SetObjectString()}";
            _connection.openConnection();
            SqlCommand cmd = new SqlCommand(query, _connection.getConnection());
            int num = cmd.ExecuteNonQuery();
            _connection.closeConnection();
            return num > 0;
        }
    }
}
