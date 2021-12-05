using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public class Rebar
    {
        public double diam { set; get; }
        public double area { set; get; }
        public double peso { set; get; }
        public string aco { set; get; }
        public double fy { set; get; }
        public Rebar(double _diam, double _area, double _peso, string _aco, double _fy)
        {
            this.diam = _diam;
            this.area = _area;
            this.peso = _peso;
            this.aco = _aco;
            this.fy = _fy;
            
        }
    }
}
