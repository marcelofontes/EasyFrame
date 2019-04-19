using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM

{

    public struct IntForces
    {
        /// <summary>
        /// Force in X local direction - axial
        /// </summary>
        public double N;
        /// <summary>
        /// Force in X local direction - shear
        /// </summary>
        public double Vx;
        /// <summary>
        /// Force in Y local direction - shear
        /// </summary>
        public double Vy;
        /// <summary>
        /// Force in Z local direction - shear
        /// </summary>
        public double Vz;
        /// <summary>
        /// Moment about X local direction
        /// </summary>
        public double Mx;
        /// <summary>
        /// moment about Y local direction
        /// </summary>
        public double My;
        /// <summary>
        /// moment abou Z local direction
        /// </summary>
        public double Mz;
    }
    /// <summary>
    /// Displacement
    /// </summary>
    public struct Disp
    {

        public double ux;
        public double uy;
        public double rz;
    }
    /// <summary>
    /// End Bar releases
    /// </summary>
    public struct Release
    {
        public int Nx;
        public int Vy;
        public int Rz;
    }


    /// <summary>
    /// Class clsNode
    /// </summary>
    public class clsNode :clsFEM
    {
        public bool                             isSupport { set; get; }
        bool                                    IsReleased = false;
        clsPoint                                Coord;
        public clsSupport                       Support;
        List<clsLoad>                           Loads; // nodal loads
        public Dictionary<string,Disp>          Displacement;
        private Release                         Releases;
        bool                                    internalNode = false;
        bool                                    lateralSupport = false;
        public Dictionary<string, IntForces>    InternalForces { set; get; }       // vector to store internal forces on beams.
        public int[]                            DofRelated;


        /// <summary>
        /// Constructor - Point P
        /// </summary>
        /// <param name="_P"></param>
        public clsNode(clsPoint _P)
        {
            this.Coord =        new clsPoint();
            this.Coord.x =      _P.x;
            this.Coord.y =      _P.y;
            isSupport =         false;
            this.ID =           _P.ID;
            Loads =             new List<clsLoad>();
            InternalForces =    new Dictionary<string, IntForces>();
            this.Displacement = new Dictionary<string, Disp>();

            DofRelated = new int[2];
            this.DofRelated[0] = 2 * this.ID - 2;
            this.DofRelated[1] = 2 * this.ID - 1;

        }

        public                  clsNode(int _ID, clsPoint _P)
        {
            this.Coord =         new clsPoint();
            this.ID =            _ID;
            this.Coord.x =       _P.x;
            this.Coord.y =       _P.y;
            isSupport =          false;
            this.Name =          _ID.ToString() ;
            Loads =              new List<clsLoad>();
            this.InternalForces =     new Dictionary<string, IntForces>();
            this.Displacement =       new Dictionary<string, Disp>();
            this.DofRelated =         new int[2];
            this.DofRelated[0] = 2 * this.ID - 2;
            this.DofRelated[1] = 2 * this.ID - 1;
        }

        public void             SetCoord(clsPoint _P)
        {
            Coord = _P;

        }

        public clsPoint         GetCoord()
        {
            return Coord;
        }

        public void             AddSupport(clsSupport _Supp)
        {
            isSupport = true;
            Support = _Supp;
        }

        public clsSupport       GetSupport() { return Support; }

        public bool             ISReleased() { return IsReleased; }

        public void             AddLoad(clsLoad _Load)
        {
            
            Loads.Add(_Load);
        }

        public List<clsLoad>    GetLoadVector() { return Loads; }

        public void             SetReleases(Release _Releases)
        {
            Releases = _Releases;
            IsReleased = true;
        }

        public void             RemoveReleases()
        {
            Releases.Nx = 1;
            Releases.Nx = 1;
            Releases.Vy = 1;
            IsReleased = false;
        }

        public Release          GetReleases() { return Releases; }

        /// <summary>
        /// Stores node displacements
        /// </summary>
        /// <param name="Displ"></param>
        //public void             SetDisplacements(double[] Displ)
        //{
        //    Displacement.ux = Displ[0];
        //    Displacement.uy = Displ[1];
        //    Displacement.ry = Displ[2];


        //}

        /// <summary>
        /// Get Node displacements
        /// </summary>
        /// <param name="Displ"></param>
        /// <returns></returns>
        //public Disp             GetDisplacements(double[] Displ) { return Displacement; }
        
        public bool             isInternalNode() { return internalNode; }
        
        public void             setInternalNode() { this.internalNode = true; }

        public void             setLateralSupport() { this.lateralSupport = true; }

        public bool             isLateralSuppport() { return lateralSupport; }

        public void             calculateDOFID()
        {
            this.DofRelated[0] = 2 * this.ID - 2;
            this.DofRelated[1] = 2 * this.ID - 1;
        }

    }
}

