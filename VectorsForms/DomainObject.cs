using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace VectorsForms
{
    abstract class DomainObject
    {
        public int _id;
        protected static DBConnection _connection = null;
        public DomainObject(List<string> _params)
        {
            _connection=new DBConnection(@"Data Source=DESKTOP-RQ1TD73\SQLEXPRESS;Initial Catalog=VectorsBase;Integrated Security=True");
            
            if (Convert.ToInt32(_params[0]) > 0)
            {
                _id = Convert.ToInt32(_params[0]);
                Console.WriteLine($"Подгружаем из базы объект:{this.GetType().Name}");
                
            }
            else
            {
                Console.WriteLine($"Создаём объект:{this.GetType().Name}");
            }
        }
        protected abstract void LoadObject(List<string> _params);
    }
}
