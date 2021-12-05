using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Linq;
//using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public class CsSection
    {

        public Material material;
 
        public int ID { set; get; }         
        public string Name { set; get; }
        public double b { set; get; }
        public double h { set; get; }
        public double cover { set; get; }
        
        public int profCode;
        public double A { set; get; }       
        public double Ix {set;get;}         
        public double Iy { set; get; }     
        public double Wx { set; get; }     
        public double Wy { set; get; }
        public double rx { set; get; }
        public double ry { set; get; }
        public double YCG { set; get; }
        public double XCG { set; get; }
        public double wgt { set; get; }

        public CsSection() { }
        public  CsSection(int _ID, string _Name, double _b, double _h, Material _material, double _cover)
        {
            this.b = _b;
            this.h = _h;
            this.material = _material;
            this.Name = _Name;
            this.ID = _ID;
            this.cover = _cover;
            fillProperties();
        }
        // unidades em cm
       public void fillProperties()
        {
            this.A = b * h;
            this.Ix = b * h * h * h / 12;
            this.Iy = h * b * b * b / 12;
            this.Wx = b * h * h / 6;
            this.Wy = h * b * b / 6;
            this.rx = Math.Sqrt(Ix / A);
            this.ry = Math.Sqrt(Iy / A);
            this.YCG = h / 2;
            this.XCG = b / 2;
            this.wgt = this.material.uniWeight * A * 0.0001; // kN/m

        }

        
          }

    
}
