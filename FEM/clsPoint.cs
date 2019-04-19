using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public class clsPoint
    {
        public int ID { get; set; }

        public double x { get; set; }

        public double y { get; set; }

        public clsPoint() { }

        public clsPoint(int _ID, double _x, double _y)
        {
            x = _x;
            y = _y;
            ID = _ID;
        }
    }
}
