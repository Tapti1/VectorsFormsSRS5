using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VectorsForms
{
    internal class Vector:DomainObject
    {
        public double _x,_y;
        public Vector(List<string> _params) : base(_params) { }

        protected override void LoadObject(List<string> _params)
        {
            _x = Convert.ToInt32(_params[0]);
            _y = Convert.ToInt32(_params[1]);
        }        
        public double Lenght()
        {
            return Math.Sqrt(_x*_x+_y*_y);
        }

        
    }
}
