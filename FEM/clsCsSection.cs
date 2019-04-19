using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Linq;
//using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public class clsCsSection
    {
        public clsMaterial material{set;get;}
        public int ID { set; get; }         
        public string Name { set; get; }
        public int profCode;
        public int fabrication;
        public string table;
        public double A { set; get; }       
        public double Ix {set;get;}         
        public double Iy { set; get; }     
        public double Wxs { set; get; }     
        public double Wxi { set; get; }
        public double Wy { set; get; }
        public double rx { set; get; }
        public double ry { set; get; }
        public double Zx { set; get; }
        public double Zy { set; get; }
        public double YCG { set; get; }
        public double XCG { set; get; }
        public double It { set; get; }
        public double Cw { set; get; }
        public double wgt { set; get; }

        public double d { set; get; }       // out-out depth
        public double bfs { set; get; }
        public double bfi { set; get; }
        public double tfs { set; get; }
        public double tfi { set; get; }
        public double tw { set; get; }
        public double c { set; get; }       // lip for cold formed profile
        public double alpha { set; get; }   // lip angle
        public double rT { set; get; }
        public double R { set; get; }

        public clsCsSection() { }
        
        public void defineCG()
        {
            if (profCode==100 || profCode == 101)
            {
                YCG = d / 2;
                XCG = 0;
            }

            else if (profCode == 102)
            {
                YCG = (bfi * tfi * tfi *0.5 + (d - tfs - tfi) * tw * d *0.5 + bfs * tfs * (d - 0.5 * tfs)) / (bfi*tfi+bfs*tfs+(d-tfs-tfi)*tw);
                XCG = 0;
            }
        }

    }

    
}
