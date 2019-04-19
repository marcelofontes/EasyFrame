using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWin
{
    class Load
    {

        public int ID               { set; get; }
        public double position      { get; set; }
        public double Py            { get; set; }
        public string type          { get; set; } // P ou D
        public string loadCase      { get; set; } // Carga Permanente, Sobrecarga de Piso, Sobrecarga de Cobertura, Vento
        public string description   { get; set; }

        public Load() { }

        /// <summary>
        /// generate Nodal load
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_position"></param>
        /// <param name="_Py"></param>
        /// <param name="_type"></param>
        /// <param name="_loadCase"></param>
        public Load(int _ID, string _description, double _position, double _Py, string _loadCase)
        {
            ID          = _ID;
            position    = _position;
            Py          = _Py;
            type        = "P";
            loadCase    = _loadCase;
            description = _description;
        }

        /// <summary>
        /// generate uniform load
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_Py"></param>
        /// <param name="_type"></param>
        /// <param name="_loadCase"></param>
        public Load(int _ID, string _descriprion, double _Py, string _loadCase)
        {
            ID = _ID;
            position = 0;
            Py = _Py;
            type = "D";
            loadCase = _loadCase;
            description = _descriprion;
        }

    }
}
