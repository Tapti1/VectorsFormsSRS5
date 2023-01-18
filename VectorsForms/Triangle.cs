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
            VectorMapper mapper = new VectorMapper();
            v1 = mapper.GetById(Convert.ToInt32(_params[0]));
            v2 = mapper.GetById(Convert.ToInt32(_params[1]));
        }           
    }
}
