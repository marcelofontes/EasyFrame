using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    /// <summary>
    /// SuperClass
    /// </summary>
    public class clsFEM
    {
        // Properties
        public int ID { get; set; }
        public string Name { get; set; }// description to be used in BOM

        /// <summary>
        /// constructor
        /// </summary>
        public clsFEM() { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_Name"></param>
        /// 
        public clsFEM(int _ID, string _Name)
        {
            ID = _ID; //  Object ID
            Name = _Name;// Object Name
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_ID"></param>
        public clsFEM(int _ID)
        {
            ID = _ID;
        }

        


    }
}
