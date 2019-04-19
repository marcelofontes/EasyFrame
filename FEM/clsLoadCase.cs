using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM

{
    
    public class clsLoadClass
    {
        public  int     ID          { get; set; }
        public string   Name        { get; set; }
        public double   gama        { get; set; }
        public double   psi0        { get; set; }
        public double   psi1        { get; set; }
        public double   psi2        { get; set; }
        public bool     isVariable  { set; get; }
        public bool     isWind      { set; get; }

        
        public clsLoadClass(int _ID, string _Name, double _gama, double _psi0, double _psi1, double _psi2,bool _isVariable)
        {
            this.ID     = _ID;
            this.Name   = _Name;
            this.gama   = _gama;
            this.psi0   = _psi0;
            this.psi1   = _psi1;
            this.psi2   = _psi2;
            this.isVariable = _isVariable;
        }
    }

    public class clsLoadCase
    {
        public int          ID      { get; set; }
        public string       Name    { get; set; }
        public clsLoadClass LClass  { get; set; }
    
        public clsLoadCase(int _ID, string _Name, clsLoadClass _LoadClass)
        {
          ID        = _ID;
          Name      = _Name;
          LClass    = _LoadClass;
        }
        public void setLoadClass(clsLoadClass _lclass)
        {
            this.LClass = _lclass;
        }
   }
}
