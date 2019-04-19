using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public struct React // at global UCS
    {
        public double Tx;
        public double Ty;
        public double Mz;
    }

    public class clsSupport : clsFEM
    {

        public Dictionary<string,React>  Reactions;


        public int Tx { get; set; }

        public int Ty { get; set; }

        public int Rz { get; set; }
        public int Owner { get; set;}

        /// <summary>
        /// Creates a support object .
        /// </summary>
        /// <param name="_Tx"></param>
        /// <param name="_Ty"></param>
        /// <param name="_Rz"></param>
        public clsSupport(int _ID, int _Tx, int _Ty, int _Rz, int _nodeID)
        {
            // 0 - free
            // 1 - restrained
            ID = _ID;
            Name = ID.ToString();
            Tx = _Tx;
            Ty = _Ty;
            Rz = _Rz;
            Owner = _nodeID;
        }


    }
}
