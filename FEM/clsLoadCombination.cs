using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public enum combType { ULS, SLS}

   public class clsLoadCombination
    {
        public int      ID          { set; get; }
        public string   name        { set; get; }
        public combType cbType      { set; get; }
        public double   CPfactor    { set; get; }
        public double   SCCFactor   { set; get; }
        public double   SCPFactor   { set; get; }
        public double   VFactor     { set; get; }

        public          clsLoadCombination(int _ID, string _name, combType _cbType, double _CPFactor, double _SCCFactor, double _SCPFactor, double _VFactor)
        {
            cbType      = _cbType;
            CPfactor    = _CPFactor;
            SCCFactor   = _SCCFactor;
            SCPFactor   = _SCPFactor;
            VFactor     = _VFactor;
            ID          = _ID;
            name        = _name;
        }

        public double   getLoadFactor(string lc)
        {
            double lf = 0;
            switch (lc)
            {
                case "PP":
                    lf = CPfactor;
                    break;
                case "CP":
                    lf = CPfactor;
                    break;
                case "SCC":
                    lf = SCCFactor;
                    break;
                case "SCP":
                    lf = SCPFactor;
                    break;
                case "V":
                    lf = VFactor;
                    break;
            }

            return lf;
        }
    }
}
