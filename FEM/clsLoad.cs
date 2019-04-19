using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FEM
{

    /// <summary>
    /// P - Point load on beam
    /// D - uniform load on beam
    /// N - Nodal load
    /// </summary>
    public enum LoadType { P=1, D, N};


    /// <summary>
    /// Load Class
    /// </summary>
    public class clsLoad
    {

        public int                      ID          { get; set; }
        public string                   name        { get; set; }
        
        public clsLoadCase              LoadCase    { get; set; }
        bool                            IsLocal = false;                      // Flag for Local or Global load
        public double                   Px          { get; set; }
        public double                   Py          { get; set; }
        public double                   Mz          { get; set; }
        private int                     OwnerID;
        public                          LoadType lType;
        public double                   a           { get; set; }            // load position from begging of the global beam ... only for point load
        public double                   arel        { get; set; }            // load relative position from beggining of the element


        public clsLoad() { }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="_ID"> Load ID</param>
        /// <param name="_name">Load Description or name</param>
        /// <param name="_Px"> Load on X global direction</param>
        /// <param name="_Py"> Load on Y global direction</param>
        /// <param name="_MZ"> Moment about Z global direction</param>
        /// <param name="_LoadCase">Load Case - clsLoadCase object</param>
        /// <param name="_lType"> can be P for point load on beam, D for uniform load on beam or N for nodal load</param>
        /// <param name="_a"> load position in case of point load (P)</param>
        public clsLoad(int _ID, string _name, double _Px, double _Py, double _MZ, clsLoadCase _LoadCase, LoadType _lType, double _a)
        {
            ID = _ID;
            lType = _lType;
            LoadCase = _LoadCase;
            Px = _Px;
            Py = _Py;
            Mz = _MZ;
            name = _name;
            // OwnerID = _OwnerID;
            a = _a;
        }   

        public clsLoadCase  GetLoadCase() { return LoadCase; }
       // public  int         getOwnerID() { return this.OwnerID; }
       // public void         setOwnerID(int _ID) { this.OwnerID = _ID; }

    }

    //    /// <summary>
    //    /// Point Load Class
    //    /// </summary>
    //    public class clsPointLoad : clsLoad
    //    {

    //        //  public double Px { get; set; }
    //        //  public double Py { get; set; }
    //        //  public double Mz { get; set; }
    //        public double   Alpha { get; set; }

    //        /// <summary>
    //        /// Constructor for UCS Point Load
    //        /// </summary>
    //        /// <param name="_ID"></param>
    //        /// <param name="_Name"></param>
    //        /// <param name="_Px"></param>
    //        /// <param name="_Py"></param>
    //        /// <param name="_LoadCase"></param>
    //        public          clsPointLoad(int _ID,  double _Px, double _Py, double _Mz, clsLoadCase _LoadCase)
    //        {
    //            Px = _Px;
    //            Py = _Py;
    //            Mz = _Mz;


    //            this.ID = _ID;
    //            this.LoadCase = _LoadCase;
    //            //this.Type = LoadType.POINT;
    //            Alpha = 0.0f;


    //        }

    //        /// <summary>
    //        /// Constructor for LCS  Point Loads
    //        /// </summary>
    //        /// <param name="_ID"></param>
    //        /// <param name="_Name"></param>
    //        /// <param name="_Px"></param>
    //        /// <param name="_Py"></param>
    //        /// <param name="_Alpha"></param>
    //        /// <param name="_LoadCase"></param>
    //        public          clsPointLoad(int _ID,  double _Px, double _Py, double _Mz, double _Alpha, clsLoadCase _LoadCase)
    //        {
    //            Px = _Px;
    //            Py = _Py;
    //            Mz = _Mz;
    //            this.ID = _ID;
    //            Alpha = _Alpha;
    //            this.LoadCase = _LoadCase;
    //           // this.Type = LoadType.POINT;
    //        }

    //    }

    //    /// <summary>
    //    /// Distributed Line Load
    //    /// </summary>
    //    public class clsLineLoad : clsLoad
    //    {

    //        //      public double Qx { get; set; }   
    //        //      public double Qy { get; set; }
    //        double alpha;
    //        public double Alpha { get; set; }   // angle in relation to the bar center line
    //        double StartPos;                    // start Position in LCS
    //        double EndPos;                      // End Position in LCS

    //        /// <summary>
    //        /// Constructor for UCS Distributed loads
    //        /// </summary>
    //        /// <param name="_ID"></param>
    //        /// <param name="_Name"></param>
    //        /// <param name="_qx"></param>
    //        /// <param name="_qy"></param>
    //        /// <param name="_LoadCase"></param>
    //        public      clsLineLoad(int _ID,  double _qx, double _qy, clsLoadCase _LoadCase)
    //        {
    //            Px = _qx;
    //            Py = _qy;
    //            this.ID = _ID;
    //            this.LoadCase = _LoadCase;
    //            Alpha = 0.0f;
    //            alpha = 0.0f;


    //        }

    //        /// <summary>
    //        /// Constructor for LCS Distributed load
    //        /// </summary>
    //        /// <param name="_ID"></param>
    //        /// <param name="_Name"></param>
    //        /// <param name="_Px"></param>
    //        /// <param name="_Py"></param>
    //        /// <param name="_Alpha"></param>
    //        /// <param name="_LoadCase"></param>
    //        public      clsLineLoad(int _ID,  double _qx, double _qy, double _Alpha, clsLoadCase _LoadCase)
    //        {
    //            Px = _qx;
    //            Py = _qy;
    //            this.ID = _ID;
    //            alpha = _Alpha;
    //            this.LoadCase = _LoadCase;

    //        }

    //        /// <summary>
    //        /// Constructor for UCS Partial Distributed loads
    //        /// </summary>
    //        /// <param name="_ID"></param>
    //        /// <param name="_Name"></param>
    //        /// <param name="_Px"></param>
    //        /// <param name="_Py"></param>
    //        /// <param name="_Alpha"></param>
    //        /// <param name="_StartPos"></param>
    //        /// <param name="_EndPos"></param>
    //        /// <param name="_LoadCase"></param>
    //        public      clsLineLoad(int _ID, double _qx, double _qy, double _Alpha, double _StartPos, double _EndPos, clsLoadCase _LoadCase)
    //        {
    //            Px = _qx;
    //            Py = _qy;
    //            this.ID = _ID;
    //            alpha = _Alpha;
    //            StartPos = _StartPos;
    //            EndPos = _EndPos;
    //            this.LoadCase = _LoadCase;
    //        }
    //    }

}

