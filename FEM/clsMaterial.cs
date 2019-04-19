using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public class clsMaterial :clsFEM
    {

        public double E { get; set; }
        public double G { get; set; }
        public double Fy { get; set; }
        public double Fu { get; set; }
        public double uniWeight { get; set; }


        public clsMaterial() { }

        public clsMaterial(string _Name, double _E, double _G, double _Fy, double _Fu)
        {
            this.Name = _Name;
            E = _E;
            G = _G;
            Fy = _Fy;
            Fu = _Fu;
        }

        public clsMaterial(int _ID, string _Name, double _E, double _G, double _Fy, double _Fu)
        {
            this.Name = _Name;
            this.ID = _ID;
            E = _E;
            G = _G;
            Fy = _Fy;
            Fu = _Fu;
        }


    }
}
