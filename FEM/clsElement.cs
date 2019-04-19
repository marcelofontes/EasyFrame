using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//TODO : implementar metodo para inserir rotulas nos elementos ( diagonais)

namespace FEM
{
   

    /// <summary>
    /// Element Type: TRUSS2D, BEAM2D, FRAME2D
    /// </summary>
    public enum ElemType { TRUSS2D = 1, BEAM2D, FRAME2D, FRAME3D };

    /// <summary>
    /// struct to store the element internal forces
    /// </summary>
   
    /// <summary>
    /// Creates Bar element
    /// </summary>
    public class clsElement : clsFEM
    {

        public double           Length         { get; }   // member length - to be used in Design
        public double           RealLength     { get; set; } // Length to be used in the drawing
        public double           Weight         { get; set; }          // bar total weight
        public clsNode          StartNode      { get; set; }
        public clsNode          EndNode        { get; set; }
        public ElemType         ElementType;
   
        public clsCsSection     CS             { get; set; }     // Cross Section 
       
        public double           Alpha;          // bar inclination 
        private int[]           DOFId;          // Degrees of freedom ID
        private double[,]       KL;             // local stiffener matrix
        private double[,]       KGL;            // Global stiffener matrix
        private double[,]       RT;             // Rotation Matrix
        private double[,]       RTT;            // transposed Rotation Matrix
        private List<clsLoad>   Loads = new List<clsLoad>(); // stores loads entered by user
        //double[] DisplVect;       // Displacement vector
        //double[] EPForcesVector;  // coeficientes de engastamento perfeito de barra de portico

        Dictionary<string, double[]> EPForcesVector;
        Dictionary<string, double[]> GlobalForcesVector;
        Dictionary<string, double[]> LoadVector;  // Element Force Vector
        public Dictionary<string, Dictionary<double, IntForces>> IntForces { set; get; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_Name"></param>
        /// <param name="_StartNode"></param>
        /// <param name="_EndNode"></param>
        /// <param name="_CS"></param>
        /// <param name="_ElemType"></param>
        /// <param name="_MType"></param>
        public              clsElement(int _ID, string _Name, clsNode _StartNode, clsNode _EndNode, clsCsSection _CS, ElemType _ElemType)
        {
            StartNode   = _StartNode;
            EndNode     = _EndNode;
            CS          = _CS;
            ElementType = _ElemType;
            Weight      =  Length * CS.wgt;
            this.ID     = _ID;
            this.Name   = _Name;
            
            clsPoint Pi = StartNode.GetCoord();
            clsPoint Pf = EndNode.GetCoord();
            IntForces = new Dictionary<string, Dictionary<double, IntForces>>();

            // calculate bar Length
            Length = Math.Sqrt(Math.Pow((Pf.x - Pi.x), 2) + Math.Pow((Pf.y - Pi.y), 2));
            
           // calculate bar inclination
            Alpha = Math.Atan((Pf.y - Pi.y) / (Pf.x - Pi.x));

            // Calculate Vector of DOF
            CalculateDOFId();

            // define element matrices
            AssembElemGlStiffMatrix();
        }
        /// <summary>
        /// Calculates Elements Local Stiffness matrix
        /// </summary>
        public void         CalculateKLocal()
        {

            double E = CS.material.E;
            double I = CS.Ix*Math.Pow(10,-8);
            double A = CS.A*Math.Pow(10,-4);
            double L = Length; //[m]

            if (ElementType == ElemType.BEAM2D)
            {
                KL = new double[4, 4];

                KL[0, 0] = 12 * E * I / Math.Pow(L, 3);
                KL[0, 1] = 6 * E * I / Math.Pow(L, 2);
                KL[0, 2] = -12 * E * I / Math.Pow(L, 3);
                KL[0, 3] = 6 * E * I / Math.Pow(L, 2);

                KL[1, 0] = KL[0, 1];
                KL[1, 1] = 4 * E * I / L;
                KL[1, 2] = -6 * E * I / Math.Pow(L, 2);
                KL[1, 3] = 2 * E * I / L;

                KL[2, 0] = KL[0, 2];
                KL[2, 1] = KL[1, 2];
                KL[2, 2] = 12 * E * I / Math.Pow(L, 3);
                KL[2, 3] = -6 * E * I / Math.Pow(L, 2);

                KL[3, 0] = KL[0, 3];
                KL[3, 1] = KL[1, 3];
                KL[3, 2] = KL[2, 3];
                KL[3, 3] = 4 * E * I / L;

            }

            //for frame 2D
               
                    if (ElementType == ElemType.FRAME2D)
                    {
                KL = new double[6, 6];

                KL[0, 0] = E * A / L;
                KL[0, 1] = 0.0;
                KL[0, 2] = 0.0;
                KL[0, 3] = -E * A / L;
                KL[0, 4] = 0.0;
                KL[0, 5] = 0.0;

                KL[1, 1] = 12 * E * I / Math.Pow(L, 3);
                KL[1, 2] = 6 * E * I / Math.Pow(L, 2);
                KL[1, 3] = 0.0;
                KL[1, 4] = -12 * E * I / Math.Pow(L, 3);
                KL[1, 5] = 6 * E * I / Math.Pow(L, 2);

                KL[2, 2] = 4 * E * I / L;
                KL[2, 3] = 0.0;
                KL[2, 4] = -6 * E * I / Math.Pow(L, 2);
                KL[2, 5] = 2 * E * I / L;

                KL[3, 3] = E * A / L;
                KL[3, 4] = 0.0;
                KL[3, 5] = 0.0;

                KL[4, 4] = 12 * E * I / Math.Pow(L, 3);
                KL[4, 5] = -6 * E * I / Math.Pow(L, 2);

                KL[5, 5] = 4 * E * I / L;

                //simmetric coefficients

                KL[1, 0] = 0.0;

                KL[2, 0] = 0.0;
                KL[2, 1] = KL[1, 2];

                KL[3, 0] = KL[0, 3];
                KL[3, 1] = 0.0;
                KL[3, 2] = 0.0;

                KL[4, 0] = 0.0;
                KL[4, 1] = KL[1, 4];
                KL[4, 2] = KL[2, 4];
                KL[4, 3] = 0.0;

                KL[5, 0] = 0.0;
                KL[5, 1] = KL[1, 5];
                KL[5, 2] = KL[2, 5];
                KL[5, 3] = 0.0;
                KL[5, 4] = KL[4, 5];

            }

            // For 2D Truss
           
            if (ElementType == ElemType.TRUSS2D)
            {
                KL = new double[4, 4];

                KL[0, 0] = E * A / L;
                KL[0, 1] = 0.0;
                KL[0, 2] = -E * A / L;
                KL[0, 3] = 0.0;

                KL[1, 0] = 0.0;
                KL[1, 1] = 0.0;
                KL[1, 2] = 0.0;
                KL[1, 3] = 0.0;

                KL[2, 0] = KL[0, 2];
                KL[2, 1] = 0.0;
                KL[2, 2] = E * A / L;
                KL[2, 3] = 0.0;

                KL[3, 0] = KL[0, 3];
                KL[3, 1] = KL[1, 3];
                KL[3, 2] = KL[2, 3];
                KL[3, 3] = 0.0;
            }

           

        }
        /// <summary>
        /// calculates rotation matrix
        /// </summary>
        public void         CalculateRotMatrix()
        {

            clsPoint Pi = StartNode.GetCoord();
            clsPoint Pf = EndNode.GetCoord();
            double C = (Pf.x - Pi.x) / Length;  // cossine
            double S = (Pf.y - Pi.y) / Length;  // sine

            // if (ElementType == "FRAME2D")
            if (ElementType == ElemType.FRAME2D)
            {
                RT = new double[6, 6];

                RT[0, 0] = C;
                RT[0, 1] = S;
                RT[0, 2] = 0;
                RT[0, 3] = 0;
                RT[0, 4] = 0;
                RT[0, 5] = 0;

                RT[1, 0] = -S;
                RT[1, 1] = C;
                RT[1, 2] = 0;
                RT[1, 3] = 0;
                RT[1, 4] = 0;
                RT[1, 5] = 0;

                RT[2, 0] = 0;
                RT[2, 1] = 0;
                RT[2, 2] = 1;
                RT[2, 3] = 0;
                RT[2, 4] = 0;
                RT[2, 5] = 0;

                RT[3, 0] = 0;
                RT[3, 1] = 0;
                RT[3, 2] = 0;
                RT[3, 3] = C;
                RT[3, 4] = S;
                RT[3, 5] = 0;

                RT[4, 0] = 0;
                RT[4, 1] = 0;
                RT[4, 2] = 0;
                RT[4, 3] = -S;
                RT[4, 4] = C;
                RT[4, 5] = 0;

                RT[5, 0] = 0;
                RT[5, 1] = 0;
                RT[5, 2] = 0;
                RT[5, 3] = 0;
                RT[5, 4] = 0;
                RT[5, 5] = 1;

            }

            if (ElementType == ElemType.BEAM2D)
            {
                RT = new double[4, 4];

                RT[0, 0] = C;
                RT[0, 1] = S;
                RT[0, 2] = 0;
                RT[0, 3] = 0;


                RT[1, 0] = -S;
                RT[1, 1] = C;
                RT[1, 2] = 0;
                RT[1, 3] = 0;


                RT[2, 0] = 0;
                RT[2, 1] = 0;
                RT[2, 2] = C;
                RT[2, 3] = S;


                RT[3, 0] = 0;
                RT[3, 1] = 0;
                RT[3, 2] = -S;
                RT[3, 3] = C;

            }

        }
        /// <summary>
        ///  transpose rotation matrix
        /// </summary>
        void                TransposeRotMatrix()
        {
            int n  = 0;
            //this.CalculateRotMatrix();
            switch (ElementType)
            {
                case ElemType.BEAM2D:
                     n = 4;
                    break;

                case ElemType.FRAME2D:
                     n = 6;
                    break;
            }

            RTT = new double[n,n];
            
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {

                        RTT[i, j] = RT[j, i];
                    }

                }

        }
        /// <summary>
        /// calculates Element's global stiffnes matrix
        /// </summary>
        public void         CalculateKGL()
        {
            TransposeRotMatrix();
            int n = 0;
            switch (ElementType)
            {
                case ElemType.BEAM2D:
                    n = 4;
                    break;
                case ElemType.FRAME2D:
                    n = 6;
                    break;
            }
            
            double[,] Aux = new double[n, n];
            KGL = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                   // Aux[i, j] = 0.0;
                    for (int k = 0; k < n; k++)
                    {
                        Aux[i, j] += RTT[i, k] * KL[k, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    KGL[i, j] = 0.0;
                    for (int k = 0; k < n; k++)
                    {
                        KGL[i, j] +=  Aux[i, k] * RT[k, j];
                    }
                }
            }
        }
        /// <summary>
        /// populate the variable of loads
        /// </summary>
        /// <param name="_Load"></param>
        public void         AddLoad(clsLoad _Load)
        {
            
            Loads.Add(_Load);

            //if (Loads.ContainsKey(_Load.LoadCase.Name))
            //{
            //    Loads[_Load.LoadCase.Name].Add(_Load);
            //}
            //else
            //{
            //    Loads.Add(_Load.LoadCase.Name, new List<clsLoad>());
            //    Loads[_Load.LoadCase.Name].Add(_Load);
            //}
        }
        /// <summary>
        /// calcula o vetor de cargas de engastamento perfeito locais
        /// </summary>
        public void         calculateEPForces()
        {
            EPForcesVector = new Dictionary<string, double[]>();
            if (ElementType == ElemType.BEAM2D)
            {
                //var ld = Loads.GroupBy(p => p.LoadCase.LClass.Name);
                var ld = Loads.GroupBy(p => p.LoadCase.Name);

                foreach (var l in ld)
                {
                    foreach (var load in l)
                    {
                        // for point loads
                        if (load.lType == LoadType.P)
                        {
                            double L    = this.Length; //[m]
                            double b    = L - load.arel;
                            double a    = load.arel;

                            double MA   = load.Py * a * b * b / (L * L);
                            double MB   = load.Py * a * a * b / (L * L);
                            // já multiplicado por (-1) para somar ao vetor de forças nodais.
                            if (EPForcesVector.ContainsKey(l.Key))
                            {
                                var f = EPForcesVector[l.Key];
                                f[0] +=    -(load.Py * b) / L + (MA + MB) / L;
                                f[1] +=    -MA;
                                f[2] +=    -(load.Py - (load.Py * b) / L + (MA + MB) / L);
                                f[3] +=    MB;
                                EPForcesVector[l.Key] = f;      // replace vector in dictionary
                            }
                            else
                            {
                                double[] f = new double[4];
                                f[0] =  -load.Py * b / L + (MA + MB) / L;
                                f[1] =  -MA;
                                f[2] =  -(load.Py - load.Py * b / L + (MA + MB) / L);
                                f[3] =   MB;
                                EPForcesVector.Add(l.Key, f);
                            }
                        }
                        else if(load.lType == LoadType.D)
                        {
                            // for line loads
                            double L = this.Length;
                            if (EPForcesVector.ContainsKey(l.Key))
                            {
                                var f = EPForcesVector[l.Key];
                                f[0] += -load.Py * L / 2;
                                f[1] += -load.Py * L * L / 12;
                                f[2] += -load.Py * L / 2; ;
                                f[3] += load.Py * L * L / 12;
                                EPForcesVector[l.Key] = f; // replace vector in dictionary
                            }
                            else
                            {
                                double[] f = new double[4];
                                f[0] = -load.Py * L / 2;
                                f[1] = -load.Py * L * L / 12;
                                f[2] = -load.Py * L / 2;
                                f[3] = load.Py * L * L / 12;
                                EPForcesVector.Add(l.Key, f);
                            }
                        }
                    }
                }
            }
            //clsIOManager io = new clsIOManager();
            //io.printEPVector(EPForcesVector);
        }
        /// <summary>
        /// calculate global vector forces
        /// </summary>
        public void         calculateGLForceVector()
        {
            calculateEPForces();
            GlobalForcesVector = new Dictionary<string, double[]>();
            var GVF = EPForcesVector;
           // GlobalForcesVector = new Dictionary<string, double[]>();

            // insert equivalente nodal forces into global load vector

            if (ElementType == ElemType.BEAM2D)
            {
                foreach (var F in GVF)
                {
                    var f = GVF[F.Key];             // retrieve load vector for especific key
                    double[] GL = new double[4];    // to store locally load vector

                    for(int i = 0; i < 4; i++)
                    {
                        for(int j=0; j < 4; j++)
                        {
                            GL[i] += -RT[i, j] * f[j];
                        }
                    }
                    GlobalForcesVector.Add (F.Key, GL);
                }
            }
        }
        //public void CreateLocalForcesVector()
        //{
        //      double W = CS.wgt;
        //      if (ElementType == ElemType.BEAM2D)
        //    {


        //    }
            //if (ElementType == ElemType.FRAME2D)
            //{
            //    // create self weight forces
            //    // self weigth is always in Global Coordinate system    

                
            //    // double W=0.0f; /// eliminar esta variavel
            //    //clsLineLoad SW = new clsLineLoad(1,  0, -1.05 * W, new clsLoadCase(1, "Peso Proprio", LoadClass.PP));
            //    clsLineLoad SW = new clsLineLoad(1, 0, -1.05 * W, new clsLoadCase(1, "Peso Proprio", new clsLoadClass(1, "PP", 1.25, 1, 1, 1)));
            //    //         SW.Type = LoadType.LINE;
            //    this.AddLoad(SW);

            //    double[] F = new double[6];

            //    // equivalente nodal loads
            //    if (!LoadVector.ContainsKey(SW.LoadCase.Name))
            //    {
            //        F[0] = 0;
            //        F[1] = -SW.Py * Length / 2;
            //        F[2] = -SW.Py * Length * Length / 12;
            //        F[3] = F[0];
            //        F[4] = F[1];
            //        F[5] = -F[2];
            //        LoadVector.Add(SW.LoadCase.Name, F);
            //    }




            //    clsLoadCase LC;
            //    string LCName;



            //    foreach (KeyValuePair<string, List<clsLoad>> par in Loads)
            //    {
            //        LCName = par.Key;
            //        List<clsLoad> Ld = par.Value;
            //        int n = Ld.Count();
            //        //F = LoadVector[LCName];

            //        if (LCName != "Peso Proprio")
            //        {
            //            for (int i = 1; i < n; i++)
            //            {
            //                F[0] = 0;
            //                F[1] = -Ld[i].Px * Length / 2 - Ld[i].Py * Length / 2;
            //                F[2] = -Ld[i].Px * Length * Length / 12 - Ld[i].Py * Length * Length / 12;
            //                F[3] = F[0];
            //                F[4] = F[1];
            //                F[5] = -F[2];

            //                LoadVector.Add(LCName, F);  // insert loads related to the first node to the Element load vector 
            //            }
            //        }
            //    }


            //    // insert releases into the loads vector


            //    int[] v = new int[6];

            //    for (int j = 0; j < 6; j++)
            //    {
            //        v[j] = 1;
            //    }


            //    Release Rel = StartNode.GetReleases();
            //    double m;

            //    foreach (KeyValuePair<string, double[]> par in LoadVector)
            //    {
            //        LCName = par.Key;
            //        F = par.Value;

            //        if (Rel.Nx == 0)
            //        {

            //            for (int i = 0; i < 6; i++)
            //            {
            //                if ((i != 0) && (v[i] == 1))
            //                {
            //                    m = KL[i, 0] / KL[0, 0];

            //                    //for (int k = 0; k < 6; k++)
            //                    //{
            //                    //    KL[i, k] = KL[i, k] - m * KL[0, k];

            //                    //}

            //                    F[i] = F[i] - m * F[0];
            //                }
            //                F[0] = 0;
            //                v[0] = 0;
            //            }
            //        }

            //        if (Rel.Vy == 0)
            //        {

            //            for (int i = 0; i < 6; i++)
            //            {
            //                if ((i != 1) && (v[i] == 1))
            //                {
            //                    m = KL[i, 1] / KL[1, 1];

            //                    //for (int k = 0; k < 6; k++)
            //                    //{
            //                    //    KL[i, k] = KL[i, k] - m * KL[1, k];

            //                    //}

            //                    F[i] = F[i] - m * F[1];
            //                }
            //                F[1] = 0;
            //                v[1] = 0;
            //            }
            //        }

            //        if (Rel.Rz == 0)
            //        {

            //            for (int i = 0; i < 6; i++)
            //            {
            //                if ((i != 2) && (v[i] == 1))
            //                {
            //                    m = KL[i, 2] / KL[2, 2];

            //                    //for (int k = 0; k < 6; k++)
            //                    //{
            //                    //    KL[i, k] = KL[i, k] - m * KL[2, k];

            //                    //}

            //                    F[i] = F[i] - m * F[2];
            //                }

            //                F[2] = 0;
            //                v[2] = 0;
            //            }
            //        }
            //        //}

            //        // --- for endnode

            //        Rel = EndNode.GetReleases();

            //        //foreach (KeyValuePair<string, double[]> par in LoadVector)
            //        //{
            //        //    LCName = par.Key;
            //        //    F = par.Value;

            //        if (Rel.Nx == 0)
            //        {

            //            for (int i = 0; i < 6; i++)
            //            {
            //                if ((i != 3) && (v[i] == 1))
            //                {
            //                    m = KL[i, 3] / KL[3, 3];

            //                    //for (int k = 0; k < 6; k++)
            //                    //{
            //                    //    KL[i, k] = KL[i, k] - m * KL[3, k];

            //                    //}

            //                    F[i] = F[i] - m * F[3];
            //                }
            //                F[3] = 0;
            //                v[3] = 0;
            //            }
            //        }

            //        if (Rel.Vy == 0)
            //        {

            //            for (int i = 0; i < 6; i++)
            //            {
            //                if ((i != 4) && (v[i] == 1))
            //                {
            //                    m = KL[i, 4] / KL[4, 4];

            //                    //for (int k = 0; k < 6; k++)
            //                    //{
            //                    //    KL[i, k] = KL[i, k] - m * KL[4, k];

            //                    //}

            //                    F[i] = F[i] - m * F[4];
            //                }
            //                F[4] = 0;
            //                v[4] = 0;
            //            }
            //        }

            //        if (Rel.Rz == 0)
            //        {

            //            for (int i = 0; i < 6; i++)
            //            {
            //                if ((i != 5) && (v[i] == 1))
            //                {
            //                    m = KL[i, 5] / KL[5, 5];

            //                    //for (int k = 0; k < 6; k++)
            //                    //{
            //                    //    KL[i, k] = KL[i, k] - m * KL[5, k];

            //                    //}

            //                    F[i] = F[i] - m * F[5];
            //                }

            //                F[5] = 0;
            //                v[5] = 0;
            //            }
            //        }

            //        LoadVector.Remove(LCName);
            //        LoadVector.Add(LCName, F);
            //    }

            //}

          
        //}
        /// <summary>
        /// Get rotation matrix of the element
        /// </summary>
        /// <returns></returns>
        public double[,]    GetRotMatrix() { return RT; }
        /// <summary>
        /// Get tranposed matrix of the Element's rotation matrix 
        /// </summary>
        /// <returns></returns>
        public double[,]    GetTranspRotMatrix() { return RTT; }
        /// <summary>
        /// poupate vector of degrees of freedom ID
        /// </summary>
        void                CalculateDOFId()
        {

            if (ElementType == ElemType.FRAME2D)
            {
                DOFId = new int[6];

                DOFId[0] = 3 * StartNode.ID - 3;
                DOFId[1] = 3 * StartNode.ID - 2;
                DOFId[2] = 3 * StartNode.ID-1;
                DOFId[3] = 3 * EndNode.ID - 3;
                DOFId[4] = 3 * EndNode.ID - 2;
                DOFId[5] = 3 * EndNode.ID-1;
            }
            if (ElementType == ElemType.BEAM2D)
            {
                DOFId = new int[4];

                DOFId[0] = 2 * StartNode.ID - 2;
                DOFId[1] = 2 * StartNode.ID-1;
                DOFId[2] = 2 * EndNode.ID - 2;
                DOFId[3] = 2 * EndNode.ID-1;
                
            }
        }
        public Dictionary<string, double[]> getEPVector() { return EPForcesVector; }
        /// <summary>
        /// returns the vector with Element's degrees of freedom 
        /// </summary>
        /// <returns></returns>
        public int[]        GetDOFIdVector() { return DOFId; }
        /// <summary>
        /// return a dictionary with global vector force
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, double[]> getGLForceVector() { return GlobalForcesVector; }
        /// <summary>
        /// assemles the element's stiffener matrix into the Global coordinate system
        /// </summary>
        public void         AssembElemGlStiffMatrix()
        {
            CalculateDOFId();
            CalculateKLocal();
           // SetReleasesonKL();
            CalculateRotMatrix();
            TransposeRotMatrix();
            CalculateKGL();
            
        }
        /// <summary>
        /// returns the Element's stiffness matriz in Global coordinate system
        /// </summary>
        /// <returns></returns>
        public double[,]    GetKGL() { return KGL; }
        /// <summary>
        /// returns the Element's stiffness matrix in local coordinate system
        /// </summary>
        /// <returns></returns>
        public double[,]    GetKL() { return KL; }
        /// <summary>
        /// Get Element Type ( TRUSS2D=1, BEAM2D, FRAME2D, FRAME3D)
        /// </summary>
        /// <returns></returns>
        public ElemType     GetElementType() { return ElementType; }
        /// <summary>
        /// Set end bar releases
        /// </summary>
        /// <param name="StartNodeRelease"></param>
        /// <param name="EndNodeRelease"></param>
        public void         SetBarReleases(Release StartNodeRelease, Release EndNodeRelease)
        {

            StartNode.SetReleases(StartNodeRelease);
            EndNode.SetReleases(EndNodeRelease);
        }
        /// <summary>
        /// set releases by modifying KL and Equivalent nodal forces vector
        /// </summary>
        public void         SetReleasesonKL()
        {

            // modify KL

            // for Start Node
            if (StartNode.ISReleased())
            {

                double m;
                Release Rel = StartNode.GetReleases();

                if (Rel.Nx == 0)
                {

                    for (int i = 0; i < 6; i++)
                    {
                        if (i != 0)
                        {
                            m = KL[i, 0] / KL[0, 0];

                            for (int k = 0; k < 6; k++)
                            {
                                KL[i, k] = KL[i, k] - m * KL[0, k];
                            }

                            for (int j = 0; j < 6; j++)
                            {
                                KL[0, j] = 0;
                            }


                        }
                    }
                }

                if (Rel.Vy == 0)
                {

                    for (int i = 0; i < 6; i++)
                    {
                        if (i != 1)
                        {
                            m = KL[i, 1] / KL[1, 1];

                            for (int k = 0; k < 6; k++)
                            {
                                KL[i, k] = KL[i, k] - m * KL[1, k];
                            }

                            for (int j = 0; j < 6; j++)
                            {
                                KL[1, j] = 0;
                            }

                        }
                    }
                }

                if (Rel.Rz == 0)
                {

                    for (int i = 0; i < 6; i++)
                    {
                        if (i != 2)
                        {
                            m = KL[i, 2] / KL[2, 2];

                            for (int k = 0; k < 6; k++)
                            {
                                KL[i, k] = KL[i, k] - m * KL[2, k];
                            }
                            for (int j = 0; j < 6; j++)
                            {
                                KL[2, j] = 0;
                            }

                        }
                    }
                }

            }


            // For EndNode

            if (EndNode.ISReleased())
            {

                double m;
                Release Rel = StartNode.GetReleases();

                if (Rel.Nx == 0)
                {

                    for (int i = 0; i < 6; i++)
                    {
                        if (i != 3)
                        {
                            m = KL[i, 3] / KL[3, 3];

                            for (int k = 0; k < 6; k++)
                            {
                                KL[i, k] = KL[i, k] - m * KL[3, k];
                            }

                            for (int j = 0; j < 6; j++)
                            {
                                KL[3, j] = 0;
                            }
                        }
                    }
                }

                if (Rel.Vy == 0)
                {

                    for (int i = 0; i < 6; i++)
                    {
                        if (i != 4)
                        {
                            m = KL[i, 4] / KL[4, 4];

                            for (int k = 0; k < 6; k++)
                            {
                                KL[i, k] = KL[i, k] - m * KL[4, k];
                            }

                            for (int j = 0; j < 6; j++)
                            {
                                KL[4, j] = 0;
                            }
                        }
                    }
                }

                if (Rel.Rz == 0)
                {

                    for (int i = 0; i < 6; i++)
                    {
                        if (i != 5)
                        {
                            m = KL[i, 5] / KL[5, 5];

                            for (int k = 0; k < 6; k++)
                            {
                                KL[i, k] = KL[i, k] - m * KL[5, k];
                            }
                            for (int j = 0; j < 6; j++)
                            {
                                KL[5, j] = 0;
                            }

                        }
                    }
                }

            }


        }

        

    

    }
}

