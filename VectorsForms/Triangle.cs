using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class Triangle:DomainObject
    {
        public Vector v1, v2;

        public Triangle(List<string> _params) : base(_params) { }

        protected override void LoadObject(List<string> _params)
        {            
            Mapper mapper = new Mapper("vectors");
            v1 = (Vector)mapper.GetById(Convert.ToInt32(_params[1]));
            v2 = (Vector)mapper.GetById(Convert.ToInt32(_params[2]));
        }
        public override string InsertObjectString()
        {
            return $"triangles(v1_id,v2_id) VALUES ({v1._id},{v2._id}";
        }
        public override string SetObjectString()
        {
            return $"v1_id='{v1._id}' , v2_id='{v2._id}' WHERE  id={_id}";
        }        
    }
}
