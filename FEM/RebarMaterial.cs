using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public class RebarMaterial
    {

        public double Fy { get; set; }
        public string Name { set; get; }
        
         public RebarMaterial() { }

        public RebarMaterial(string _Name, double _Fy)
        {
            this.Name = _Name;
            Fy = _Fy;
            
        }

        
        
    }
}
