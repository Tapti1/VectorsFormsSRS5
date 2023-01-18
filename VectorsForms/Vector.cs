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
            _x = Convert.ToDouble(_params[1]);
            _y = Convert.ToDouble(_params[2]);
        }        
        public double Lenght()
        {
            return Math.Sqrt(_x*_x+_y*_y);
        }
        public override string InsertObjectString()
        {
            return $"vectors(x, y) VALUES({_x.ToString().Replace(',', '.')},{ _y.ToString().Replace(',', '.')}";
        }
        public override string SetObjectString()
        {
            return $"x='{_x.ToString().Replace(',', '.')}' , y='{_y.ToString().Replace(',', '.')}' WHERE  id={_id}";
        }
        


    }
}
