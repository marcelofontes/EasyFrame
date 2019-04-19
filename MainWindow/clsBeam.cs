using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEM;
using DotNumerics;
using DotNumerics.LinearAlgebra;


namespace Beam
{
    public class clsBeam
    {
        public int                                                  ID;                                             // beam ID
        public string                                               Name            { set; get; }                   // beam name
        public double                                               Length          { set; get; }                   // beam total length - all spans
        private const int                                           ngl = 2;                                        // number of degrees of freedom per node
        public int                                                  MeshRefinement  { set; get; }                   // beam refinement ... generate internal nodes
        public int                                                  divisions       { set; get; }                   // number of divisions to trace diagrams and calculate de forces on beam span
        private double                                              coordY = 0.0f;                                  // set origin coordinate
        private int                                                 nVao;                                           // beam span
        public  clsCsSection                                        CS;                                             // profile
        private List<clsNode>                                       nodes = new List<clsNode>();                    // list of beam nodes
        public List<double>                                         vaos            { set; get; }                   // list of spans
        private List<clsElement>                                    bars = new List<clsElement>();                  // list of elements BEAM2D
        public double                                               minSize         { set; get; }                   // minimum element size
        private double[,]                                           KGL;                                            // Model Global stiffnes matrix
        private Dictionary<string,double[]>                         F;                                              // Model Global load vector
        private Dictionary<string, double[]>                        U;                                              // result vector
        private Dictionary<string, double[]>                        EPL;                                            // local EP forces
        public Dictionary<string, Dictionary<double, IntForces>>    InternalForces;                                 // stores forces along beam span
        public Dictionary<string, Dictionary<double, double>>       Displacements;
        public List<double>                                         toplateralBracing;
        public List<double>                                         bottomlateralBracing;
        public List<clsLoadClass>                                   LClass;
        public List<clsLoadCase>                                    LCase;
        public List<clsLoadCombination>                             LCombination;
        public List<clsLoad>                                        Loads;                                          // stores the list of applied loads
        public bool                                                 optimize = false;

        public                              clsBeam() { }

        public                              clsBeam( string _Name, List<double> _vaos, clsCsSection _CS)
        {
            
            Name = _Name;
            nVao = _vaos.Count();
            vaos = _vaos;
            CS = _CS;

            foreach (var l in _vaos)
            {
                Length += l;
            }
            toplateralBracing = new List<double>();
            bottomlateralBracing = new List<double>();
            MeshRefinement = 108;
            minSize = 0.1;
            //divisions = 1;

            genGeometry();
            generateLoadCombinations();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_Name"></param>
        /// <param name="_vaos"></param>
        /// <param name="_CS"></param>
        public                              clsBeam(int _ID, string _Name,  List<double> _vaos,  clsCsSection _CS)
        {
            ID      =   _ID;
            Name    =   _Name;
            nVao    =   _vaos.Count();
            vaos    =   _vaos;
            CS      =   _CS;

            foreach(var l in _vaos)
            {
                Length += l;
            }
            toplateralBracing = new List<double>();
            bottomlateralBracing = new List<double>();
            MeshRefinement = 108;
            minSize = 0.1;
            //divisions = 1;

            genGeometry();
            generateLoadCombinations();
            
        }

        public void                         addSpans(double span)
        {
            vaos.Add(span);
        }
        /// <summary>
        /// Generate beam Geometry
        /// </summary>
        private void                        genGeometry()
        {
            //foreach(double v in vaos) { Length += v; }

            Console.WriteLine("gerando nós");
            generateNodes();

            Console.WriteLine("gerando apoios");
            generateSupports();

            Console.WriteLine("refinando malha");
            this.refineMesh();

            Console.WriteLine("gerando barras");
            generateBars(CS);

            clsIOManager inp = new clsIOManager();
            inp.printNodes(nodes);
            inp.printLength(bars);
        }
        /// <summary>
        /// generate beam nodes
        /// </summary>
        private  void                       generateNodes()
        {
            clsPoint pt1 = new clsPoint(0, 0, coordY);
            double coord = 0;

            for (int i = 0; i < nVao; i++)
            {
                if (i == 0)
                {
                    clsNode nd1 = new clsNode(i + 1, pt1);
                    clsPoint pt2 = new clsPoint(i + 2, vaos[i], coordY);
                    clsNode nd2 = new clsNode(i + 2, pt2);
                    nodes.Add(nd1);
                    nodes.Add(nd2);
                    coord += vaos[i];
                }
                else
                {
                    double L = vaos[i] + coord; //[m]
                    coord += vaos[i];
                    clsPoint pt = new clsPoint(i + 2, L, coordY);
                    clsNode nd = new clsNode(i + 2, pt);
                    nodes.Add(nd);
                }
            }
        }
        /// <summary>
        /// generate system bars
        /// </summary>
        /// <param name="_profile"></param>
        private void                        generateBars(clsCsSection _profile)
        {
            bars.Clear();
            this.renumberNodes();
            this.sortnodesByCoord();
            for (int i = 0; i < nodes.Count() - 1; i++)
            {
                if (i == 0)
                {
                    clsElement b = new clsElement(i + 1, "V" + (i + 1), nodes[i], nodes[i + 1], CS, ElemType.BEAM2D);
                    bars.Add(b);
                }
                else
                {
                    clsElement b = new clsElement(i + 1, "V" + (i + 1), nodes[i], nodes[i + 1], CS, ElemType.BEAM2D);
                    bars.Add(b);
                }
            }
            this.sortnodesByID();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<clsElement>             getBarElements() { return bars; }
        /// <summary>
        /// generate supports
        /// </summary>
        private void                        generateSupports()
        {

            int n = nodes.Count();

            for (int i = 0; i < n; i++)
            {
                
                if (i == 0)
                {
                    clsSupport s = new clsSupport(i, 1, 1, 0, nodes[i].ID);
                    nodes[i].setLateralSupport();
                    nodes[i].AddSupport(s);
                    setLateralBracing(nodes[i].GetCoord().x,true,true);
                }
                else
                {
                    clsSupport s = new clsSupport(i, 0, 1, 0, nodes[i].ID);
                    nodes[i].AddSupport(s);
                    nodes[i].setLateralSupport();
                    setLateralBracing(nodes[i].GetCoord().x,true,true);
                }
            }
        }
        /// <summary>
        /// add nodes by coordinate
        /// </summary>
        /// <param name="pt"></param>
        public void                         addNode(clsPoint pt)
        {
               
            clsNode nd = new clsNode(this.nodes.Count(), pt);
            this.nodes.Add(nd);

        }
        /// <summary>
        /// 
        /// </summary>
        private void                        sortnodesByCoord()
        {
            IEnumerable<clsNode> orderedList = this.nodes.OrderBy(coord => coord.GetCoord().x);
            this.nodes = orderedList.ToList();
        }
        /// <summary>
      /// sort nodes by ID
      /// </summary>
        private void                        sortnodesByID()
        {
            IEnumerable<clsNode> orderedList = this.nodes.OrderBy(coord => coord.ID);
            this.nodes = orderedList.ToList();
        }
        /// <summary>
        /// adds point load
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ld"></param>
        public void                         addPointLoad_and_CreateNode(clsPoint p, clsLoad ld)
        {

            var v = nodes.Where(c => c.GetCoord().x == p.x).ToList().Count();
            if (v != 0)
            {
                var n = nodes.Where(c => c.GetCoord().x == p.x).ToList();
                n[0].AddLoad(ld);
            }

            else
            {
                int c = nodes.Count();
                clsNode nd = new clsNode(c, p);
                nd.AddLoad(ld);
                nodes.Add(nd);
            }
            this.generateBars(CS);
            //bool flag = false;
            //foreach(clsNode n in nodes)
            //{
            //    if(p.x==n.GetCoord().x && p.y==n.GetCoord().y)
            //    {
            //        n.AddLoad(ld);
            //        flag = true;
            //    }

            //}
            //if (flag == false)
            //{
            //    int c = nodes.Count();
            //    clsNode nd = new clsNode(c, p);
            //    nd.AddLoad(ld);
            //    nodes.Add(nd);
            //}

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ld"></param>
        public void                         addPointLoadonBeam(clsLoad ld)
        {
            double a = ld.a;

            // seleciona o elemento que contem a coordenada a da carga.
            var b = from barra in bars where (a >= barra.StartNode.GetCoord().x && a < barra.EndNode.GetCoord().x) select barra;
            ld.arel = ld.a - b.First().StartNode.GetCoord().x;
            b.First().AddLoad(ld);
        }
        /// <summary>
        /// Adds load to a node element
        /// </summary>
        public void                         addNodalLoad(clsLoad ld, int nodeID)
        {
            var nd = nodes.Where(p => p.ID == nodeID);
            nd.First().AddLoad(ld);


        }
        /// <summary>
        /// adds line load on beam
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="barID"></param>
        public void                         addLineLoad(clsLoad ld)
        {
            //var b = bars.Where(p => p.ID == barID);
            //b.First().AddLoad(ld);
            foreach(var bar in bars)
            {
                bar.AddLoad(ld);
            }

        }
        /// <summary>
        /// adds line load over all beam length
        /// </summary>
        /// <param name="ld"></param>
        //public void                         addLineLoadOverAll(clsLoad ld)
        //{
        //    foreach(clsElement e in bars)
        //    {
        //        e.AddLoad(ld);
        //    }
        //}
        /// <summary>
        /// adds a cantilever 
        /// </summary>
        /// <param name="vao"></param>
        public void                         addCantilever(double vao, string position)
        {
            int c = bars.Count();  //  get the number of bars

            if (position.CompareTo("begin")==0)
            {
                var n = (from ndd in nodes where (ndd.GetCoord().x == 0) select ndd).ToList();      //get the node with initial coordinate
                clsNode nd = new clsNode(new clsPoint(c, -vao, coordY));
                bars.Add(new clsElement(c, "V" + c, n[0], nd, this.CS, ElemType.BEAM2D));
            }
            else if (position.CompareTo("end") == 0)
            {
                var n = (from ndd in nodes where (ndd.GetCoord().x == Length) select ndd).ToList(); //get the node with maximum coordinate
                clsNode nd = new clsNode(new clsPoint(c, Length + vao, coordY));
                bars.Add(new clsElement(c, "V" + c, n[0], nd, this.CS, ElemType.BEAM2D));
            }
        }
        /// <summary>
        /// refine elements mesh
        /// </summary>
        private void                        refineMesh()
        {
            double coordx = 0.0f;
            for (int n = 0; n < nVao; n++)
            {
                double step = vaos[n] / MeshRefinement;
                if (step < 0.1)
                {
                    step = vaos[n]/(Math.Round(vaos[n] / minSize,0));
                }

                // create internal nodes if does not exists a node with same coord x
                for (int i = 1; i <= MeshRefinement; i++)
                {
                    coordx += step;
                    if (coordx < this.Length)
                    {
                        var v = nodes.Where(c => c.GetCoord().x == Math.Round(coordx,2)).ToList().Count();
                        if (v == 0)
                        {
                            double actualx = nodes.Last().GetCoord().x;
                            double l = coordx - actualx;
                            if (Math.Abs(l) >= 0.1) { 

                            clsPoint p = new clsPoint(nodes.Count(), coordx, coordY);
                            clsNode nd = new clsNode(p);

                            nd.setInternalNode();
                            nodes.Add(nd);
                         }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Assembles Global stiffner matrix
        /// </summary>
        private void                        AssembleKGL()
        {
            int NEl = bars.Count();   // get number of elements
            int NND = nodes.Count();   // get number of nodes
            KGL = new double[ngl * NND, ngl * NND];
            double[,] KEL;


            for (int n = 0; n < NEl; n++)
            {
                KEL = bars[n].GetKGL();
                int[] DOFId = bars[n].GetDOFIdVector();

                for (int i = 0; i < ngl*2; i++)
                {

                    for (int j = 0; j < ngl*2; j++)
                    {

                        KGL[DOFId[i], DOFId[j]] = KGL[DOFId[i], DOFId[j]] + KEL[i, j];
                       
                    }
                }
            }

            //for(int i=0; i < NND * 2; i++)
            //{
            //    for(int j=0; j<NND*2; j++)
            //    {
            //        Console.Write(KGL[i, j]+"\t" );

            //    }
            //    Console.WriteLine();
            //}

           
           

        }
        /// <summary>
        /// Assembles Load Vector of the global system
        /// </summary>
        private void                        AssembleLoadVector()
        {
            int NEL     = bars.Count();
            int NND     = nodes.Count();
            F = new Dictionary<string,  double[]>();
           
            foreach(var b in bars)
            {
                //b.calculateEPForces();
                b.calculateGLForceVector();
            }

            // loop over all nodes
            foreach (var nd in nodes)
            {
                var a = nd.GetLoadVector();
                if (a != null)
                {
                    // group loads by Load Class (PP,CP,SC ...)
                    //var Llist = a.GroupBy(p => p.LoadCase.LClass.Name);
                    var Llist = a.GroupBy(p => p.LoadCase.Name);

                    foreach (var ld in Llist)
                {
                    string k    = ld.Key;
                    double[] f = new double[2 * NND];
                    foreach (var load in ld)
                    {
                        int dof1 = nd.ID * 2 - 2;
                        int dof2 = nd.ID * 2 - 1;
                        f[dof1] += load.Py;
                        f[dof2] += load.Mz;
                    }
                    F.Add(k, f);
                }
            }
            }

            //loop over all elements
            for (int i = 0; i < NEL; i++)
            {
                int[] DOFId = bars[i].GetDOFIdVector();   // get vector of degree of freed for that bar 
                var FL      = bars[i].getGLForceVector(); // get the element global load vector of the bar wich is a dictionary at this point

                foreach(var l in FL)
                {
                    if (F.ContainsKey(l.Key))
                    {
                        var k = l.Key;     // retrieve key
                        var BGF = F[k];    // retrieve beam global forces vector for key k
                        var EGF = FL[k];   // retrieve element global forces vector for key k
                        for (int j = 0; j < ngl * 2; j++)
                        {
                            BGF[DOFId[j]] += EGF[j];
                        }
                        F[k] = BGF;         // replace the old vector by updated vector
                    }
                   else
                    {
                        var k = l.Key;     // retrieve key
                        var EGF = FL[k];   // retrieve element global forces vector for key k
                        double[] BGF = new double[2 * NND];
                        for (int j = 0; j < ngl * 2; j++)
                        {
                            BGF[DOFId[j]] += EGF[j];
                        }
                        F.Add(l.Key, BGF);
                    }
                }
            }
        }
        /// <summary>
        /// Impose restriction due support type in the KGL and F
        /// </summary>
        private void                        ImposeSupportRetrictions()
        {
            
            int n = nodes.Count();
            if (bars.First().ElementType == ElemType.FRAME2D)
            {
                double[] GF;
                string k;
                for (int i = 1; i < n; i++)
                {
                    if (nodes[i].isSupport)
                    {
                        clsSupport Sup = nodes[i].GetSupport();
                        int N = nodes[i].ID;

                        if (Sup.Tx == 1)
                        {
                            KGL[3 * N - 2, 3 * N - 2] = KGL[3 * N - 2, 3 * N - 2] + 1 * Math.Pow(10, 15);
                            foreach (var FF in F)
                            {
                                k = FF.Key;
                                GF = F[k];
                                GF[3 * N - 2] +=  1 * Math.Pow(10, 15);
                                F[k] = GF;
                            }
                            //F[3 * N - 2] = F[3 * N - 2] + 1 * Math.Pow(10,15);
                        }

                        if (Sup.Ty == 1)
                        {
                            KGL[3 * N - 1, 3 * N - 1] = KGL[3 * N - 1, 3 * N - 1] + 1 * Math.Pow(10, 15);
                            foreach (var FF in F)
                            {
                                k = FF.Key;
                                GF = F[k];
                                GF[3 * N - 1] +=  1 * Math.Pow(10, 20);
                                F[k] = GF;
                            }
                            //F[3 * N - 1] = F[3 * N - 1] + 1 * Math.Pow(10, 15);
                        }

                        if (Sup.Rz == 1)
                        {
                            KGL[3 * N, 3 * N] = KGL[3 * N, 3 * N] + 1 * Math.Pow(10, 15);
                            foreach (var FF in F)
                            {
                                k = FF.Key;
                                GF = F[k];
                                GF[3 * N ] +=  1 * Math.Pow(10, 15);
                                F[k] = GF;
                            }
                            //F[3 * N] = F[3 * N] + 1 * Math.Pow(10, 15);
                        }
                    }
                }
            }

            else if (bars.First().ElementType == ElemType.BEAM2D)
            {
                double[] GF;
                string k;
                for (int i = 0; i < n; i++)
                {
                    if (nodes[i].isSupport)
                    {
                        clsSupport Sup = nodes[i].GetSupport();
                        int N = nodes[i].ID;
                        //int aa = nodes.Count();
                        if (Sup.Ty == 1)
                        {
                            //KGL[2 * N - 2, 2 * N - 2] = KGL[2 * N - 2, 2 * N - 2] + 1 * Math.Pow(10, 15);
                            for(int j = 0; j < ngl*n; j++)
                            {
                                KGL[2 * N - 2, j] = 0;
                                KGL[j, 2 * N - 2] = 0;
                            }
                            
                            KGL[2 * N - 2, 2 * N - 2] = 1;
                           
                            //foreach (var FF in F)
                            //{
                            //    k = FF.Key;
                            //    GF = F[k];
                            //    GF[2 * N - 2] += -1 * Math.Pow(10, 20);
                            //    F[k] = GF;
                            //}
                        }

                        if (Sup.Rz == 1)
                        {
                            //KGL[2 * N - 1, 2 * N - 1] = KGL[2 * N - 1, 2 * N - 1] + 1 * Math.Pow(10, 15);

                            for (int j = 0; j < 2 * ngl; j++)
                            {
                                KGL[2 * N - 1, j] = 0;
                                KGL[j, 2 * N - 1] = 0;
                            }
                            KGL[2 * N - 1, 2 * N - 1] = 1;
                            //foreach (var FF in F)
                            //{
                            //    k = FF.Key;
                            //    GF = F[k];
                            //    GF[2 * N - 1] += -1 * Math.Pow(10, 20);
                            //    F[k] = GF;
                            //}
                        }

                    }
                }

                Dictionary<string, double[]> ff = new Dictionary<string, double[]>();
                foreach (var ld in F)
                {
                    k = ld.Key;
                   

                    double[] f = new double[ngl*n];
                    ld.Value.CopyTo(f,0);

                    for (int i = 0; i <  n; i++)
                    {
                        if (nodes[i].isSupport)
                        {
                           int id = nodes[i].ID;

                            if (nodes[i].Support.Ty == 1)
                            {
                                f[2 * id - 2] = 0;
                            }
                            if (nodes[i].Support.Rz == 1)
                            {
                                f[2 * id - 1] = 0;
                            }
                        }
                    }
                    ff[k] = f;
                }
                F = ff;
            }
        }
        /// <summary>
        /// renumber nodes
        /// </summary>
        public void                         renumberNodes()
        {
            this.sortnodesByCoord();
            int i = 0;
            foreach(clsNode n in nodes)
            {
                n.ID = i + 1;
                i += 1;
                n.calculateDOFID();
            }
            this.sortnodesByID();

        }
        /// <summary>
        /// renumber bars
        /// </summary>
        public void                         renumberBars()
        {
            this.generateBars(CS);

        }
        /// <summary>
        /// return list of nodes
        /// </summary>
        /// <returns></returns>
        public List<clsNode>                getNodes() { return this.nodes; }
        /// <summary>
        /// assamble EP local vector
        /// </summary>
        private void                        AssembleEPLTotalVector()
        {
            EPL = new Dictionary<string, double[]>();
            int i = 0;
            foreach(var b in bars)
            {
                var Ep = b.getEPVector();
                var dof = b.GetDOFIdVector();

                foreach(var E in Ep)
                {
                    string k = E.Key;
                    var epload = Ep[k];

                    if (EPL.ContainsKey(k))
                    {
                    var aux = EPL[k];

                    aux[dof[0]] += epload[0];
                    aux[dof[1]] += epload[1];
                    aux[dof[2]] += epload[2];
                    aux[dof[3]] += epload[3];
                    EPL[k] = aux; 
                    }

                    else
                    {
                   
                        double[] aux =new double[ngl*nodes.Count()];
                        aux[dof[0]] = epload[0];
                        aux[dof[1]] = epload[1];
                        aux[dof[2]] = epload[2];
                        aux[dof[3]] = epload[3];
                        EPL.Add(k, aux);

                    }
                }
                i++;
            }
        }
        /// <summary>
        /// assemble model
        /// </summary>
        private void                        AssembleModel()
        {
            
            AssembleKGL();
            AssembleLoadVector();
            ImposeSupportRetrictions();
            int NND = nodes.Count();
            clsIOManager inp = new clsIOManager(vaos, new List<clsLoad>());
            inp.printKGL(KGL, NND, NND);
            inp.printSupports(nodes);
        }
        /// <summary>
        /// Solve the linear system
        /// </summary>
        private void                        solveEquation()
        {
            Matrix K = new Matrix(KGL);
            U = new Dictionary<string, double[]>();
            int i = 0;
            foreach (var f in F)
            {
                i = 0;
                string k =              f.Key;
                Vector ff =             new Vector(f.Value);
                LinearEquations Leq =   new LinearEquations();
                double[] u =            Leq.Solve(K, ff).ToArray();
                U.Add(k, u);
                
                foreach (var n in nodes)
                {
                    var DoF = n.DofRelated;
                   
                    Disp D = new Disp();
                    D.ux = 0;
                    D.uy = u[DoF[0]];
                    D.rz = u[DoF[1]];
                    nodes[i].Displacement.Add(k, D);
                    i++;
                }

            }
            
            clsIOManager inp = new clsIOManager(vaos, new List<clsLoad>());
            inp.printDisplacements(U);
        }
        /// <summary>
        /// calculate reactions
        /// </summary>
        private void                        calculateReactions()
        {
            AssembleKGL();
            int i=0;
            this.AssembleEPLTotalVector();
            foreach (var nd in nodes)
            {
                if (nd.isSupport)
                {
                    nd.Support.Reactions = new Dictionary<string, React>();
                    // calculate degree of freedom related
                    int V = ngl * nd.ID - 2;
                    int M = ngl * nd.ID - 1;

                    foreach (var u in U)
                    {
                        string k = u.Key;
                        var Epg = EPL[k]; // vetor de engastamento perfeito da carga k
                        var ul = U[k];    // vetor de deslocamentos da carga k
                        var f = F[k];
                        React R = new React();

                        // calcula as reações e soma as cargas de engastamento perfeito
                        for (int j = 0; j < ngl * nodes.Count(); j++)
                        {
                            R.Tx = 0;
                            if (nd.Support.Ty == 1)
                            {
                                R.Ty += KGL[V, j] * ul[j];

                            }else { R.Ty = 0; }

                            if (nd.Support.Rz == 1)
                            {
                                R.Mz += KGL[M, j] * ul[j];

                            }else { R.Mz =0; }
                        }

                        if (nd.Support.Ty == 1)
                        {
                            R.Ty += Epg[V];
                        }
                        else { R.Ty = 0; }
                        
                        if (nd.Support.Rz == 1)
                        {
                            R.Mz += Epg[M];
                        } else { R.Mz = 0; }

                        if (nodes[i].isSupport)
                        {
                            if (!nodes[i].Support.Reactions.ContainsKey(k))
                            {
                                nodes[i].Support.Reactions.Add(k, R);
                            }
                            else { nodes[i].Support.Reactions[k] = R; }
                        }
                        
                    }
                   
                }
                i++;
            }
            clsIOManager io = new clsIOManager();
            io.printReactions(nodes);
        }
        /// <summary>
        /// Calculate nodal internal forces
        /// </summary>
        private void                        calculateInternalForces()
        {
            // iterate throught each element
           
            foreach(var bar in bars)
            {
                var kl  = bar.GetKL();
                var rt  = bar.GetRotMatrix();
                var dof = bar.GetDOFIdVector();

                // iterate throut each load case/load class
                foreach (var u in U)
                {
                    // take global displacement vector
                    var k = u.Key;
                    var UG = U[k];
                    double[] aux = new double[4];
                    aux[0] = UG[dof[0]];
                    aux[1] = UG[dof[1]];
                    aux[2] = UG[dof[2]];
                    aux[3] = UG[dof[3]];

                    //pega vetor de engastamento perfeito
                    Vector EP;

                    var aux2 = bar.getEPVector();
                    if (aux2.ContainsKey(k))
                    {
                        var aux3 = aux2[k];
                        EP = new Vector(aux3);
                    }
                    else
                    {
                        EP = new Vector(4);
                    }

                    Vector UGB = new Vector(aux); // pega vetor de deslocamentos globais
                    Matrix Rt = new Matrix(rt);   // pega matriz de rotação
                    Matrix Kl = new Matrix(kl);   // pega matriz de rigidez local


                    Matrix ul = Rt.Multiply(UGB);
                    Matrix f = Kl.Multiply(ul) + EP;

                    var UL = f.GetColumnVector(0).ToArray();
                    IntForces IF = new IntForces();
                    IF.N = 0;
                    IF.Vy = UL[0];
                    IF.Mx = UL[1];
                    if (!bar.StartNode.InternalForces.ContainsKey(k)) { bar.StartNode.InternalForces.Add(k, IF); }

                    IF.Vy = UL[2];
                    IF.Mx = UL[3];
                    if (!bar.EndNode.InternalForces.ContainsKey(k)) { bar.EndNode.InternalForces.Add(k, IF); }

                }
            }
            clsIOManager inp = new clsIOManager(vaos, new List<clsLoad>());
            inp.printNodalInternalForces(nodes);

        }
        /// <summary>
        /// Interpolate internal forces along beam span
        /// </summary>
        public void                         calculeSpanInternalForces()
        {
            int n = bars.Count();
            double x = 0;
            InternalForces = new Dictionary<string, Dictionary<double, IntForces>>();
            Dictionary<string, Dictionary<double, IntForces>> intForces = new Dictionary<string, Dictionary<double, IntForces>>(); //stores forces along beam span for each loadcase

            for (int j=0; j<n; j++) // loop over all bar elements
            {
                double step = bars[j].Length;
               
                double L = bars[j].Length;
                double E = bars[j].CS.material.E;
                double I = bars[j].CS.Ix*(1e-8);

                var nd1 = bars[j].StartNode;
                var nd2 = bars[j].EndNode;

                foreach (var ld in nd1.Displacement)    // for each displacements
                {
                    string k = ld.Key;
                    double[] EP = new double[ngl * nodes.Count()];

                    if (bars[j].getEPVector().ContainsKey(k))
                    {
                         EP = bars[j].getEPVector()[k];  // get equivalent nodal loads
                    }
                                        
                    x = 0;
                    IntForces IF = new IntForces();
                    while (x <= L)
                    {
                        // calculate shape functions for bending moments and shear forces

                        double N2 = 12 * x / (L * L * L) - 6 / (L * L);
                        double N3 = 6 * x / (L * L) - 4 / L;
                        double N5 = 6 / (L * L) - 12 * x / (L * L * L);
                        double N6 = 6 * x / (L * L) - 2 / L;

                        double N2v = 12 / (L * L * L);
                        double N3v = 6 / (L * L);
                        double N5v = -12 / (L * L * L);
                        double N6v = 6 / (L * L);
                        
                        IF.N = 0;
                        IF.Mx =  ((N2 * nd1.Displacement[k].uy + N3 * nd1.Displacement[k].rz + N5 * nd2.Displacement[k].uy + N6 * nd2.Displacement[k].rz) * E * I - EP[1]);
                        IF.Vy = ((N2v * nd1.Displacement[k].uy + N3v * nd1.Displacement[k].rz + N5v * nd2.Displacement[k].uy + N6v * nd2.Displacement[k].rz) * E * I ) - EP[0];

                        Dictionary<double, IntForces> aux1 = new Dictionary<double, IntForces>();
                      
                          if (!InternalForces.ContainsKey(k))
                            {
                                IF.Vy = bars[j].StartNode.InternalForces[k].Vy;
                                aux1.Add(x , IF);
                                InternalForces.Add(k, aux1);
                            }
                       
                            else if (j == 0 && x > 0)
                                {
                                    InternalForces[k].Add(x, IF);
                                }
                            else if(j>0 && x == 0)
                                {
                                    Console.WriteLine("j={0}  vy= [1] - skip",j,IF.Vy);
                                }
                            else if(j>0 && x > 0)
                                {
                                    double l = InternalForces[k].Last().Key;
                                    InternalForces[k].Add(x + l, IF);
                                }
                        x += step;
                    }
                }
            }
            clsIOManager io = new clsIOManager();
            io.printDiagrams("M", LCase.First().Name, InternalForces);
        }
        /// <summary>
        /// generate displacement diagram
        /// </summary>
        public void                         calculateSpanDisplacements()
        {
            Displacements = new Dictionary<string, Dictionary<double, double>>();
            int n = bars.Count();

            for(int i = 0; i < n; i++)
            {
                double L = bars[i].Length;
                double E = bars[i].CS.material.E;
                double I = bars[i].CS.Ix;
               
                double step = bars[i].Length;

                var nd1 = bars[i].StartNode.Displacement;
                var nd2 = bars[i].EndNode.Displacement;

                double l = 0;

                foreach ( var nd in nd1)
                {
                    string k = nd.Key;
                    double x = 0;

                    while (x <= L)
                    {
                        double N2 = 1 - 3 * x * x / (L * L) + 2 * x * x * x / (L * L * L);
                        double N3 = x - 2 * x * x / L + x * x * x / (L * L);
                        double N5 = 3 * x * x / (L * L) - 2 * x * x * x / (L * L * L);
                        double N6 = -x * x / L + x * x * x / (L * L);

                        double uy = N2 * nd1[k].uy + N3 * nd1[k].rz + N5 * nd2[k].uy + N6 * nd2[k].rz;

                        if (!Displacements.ContainsKey(k))

                        {
                            Dictionary<double, double> aux = new Dictionary<double, double>();
                            aux.Add(x, uy);
                            Displacements.Add(k, aux);
                        }

                        else
                        {
                            if (i == 0 && x>0)
                            {
                            //l = bars[i].Length;
                            Displacements[k].Add(x , uy);
                            }

                            else if (i>0 && x==0)
                            {
                                //l = bars[i - 1].Length;
                                //Displacements[k].Add(x + l, uy);
                            }

                            else
                            {
                                l =  Displacements[k].Last().Key;
                                Displacements[k].Add(x+l , uy);
                            }
                            Dictionary<double, double> aux = new Dictionary<double, double>();
                            aux.Add(x, uy);
                        }

                        x += step;
                    }
                }
            }
            clsIOManager io = new clsIOManager();
            io.printDispDiagram(Displacements, LCase.First().Name);
        }
        /// <summary>
        /// calculate displacement for a combination
        /// </summary>
        /// <param name="lc"></param>
        /// <returns></returns>
        public Dictionary<double,double>    calculateCombDisplacements( clsLoadCombination lc)
        {
            Dictionary<double, double> Dsp = new Dictionary<double, double>();
            int c                          = LCase.Count();             // take number of load cases
            double lf;

            for (int i = 0; i < c; i++)
            {
                string k        = LCase[i].Name;
                string ldtype   = LCase[i].LClass.Name;
                var d           = Displacements[k];
                lf              = lc.getLoadFactor(ldtype);             // take load factor/multiplier for that load type
                double aux = 0;

                foreach (var x in d)
                  {
                    if(Dsp.TryGetValue( x.Key ,out aux))
                    {
                        aux += x.Value * lf;
                        Dsp[x.Key] += aux;
                    }
                    else
                    {
                        aux = x.Value * lf;
                        Dsp.Add(x.Key, aux);
                    }
                  }
            }

            return Dsp;
        }
        /// <summary>
        /// calculate combined internal forces for a specific combination
        /// </summary>
        /// <param name="lc"></param>
        /// <returns></returns>
        public Dictionary<double,IntForces> calculateCombIntForces(clsLoadCombination lc)
        {
            {
                Dictionary<double, IntForces> CLC = new Dictionary<double, IntForces>(); // combined load
                int c = LCase.Count();             // take number of load cases
                double lf;

                // loop for each load case
                for (int i = 0; i < c; i++)
                {
                    string      k        = LCase[i].Name;
                    string      ldtype   = LCase[i].LClass.Name;
                    Dictionary<double, IntForces> d;
                    //var         d        = InternalForces[k];

                    if(InternalForces.TryGetValue(k, out d))
                    {
                                lf       = lc.getLoadFactor(ldtype);             // take load factor/multiplier for that load type
                    double      Maux     = 0;
                    double      Vaux     = 0;
                    double      Naux     = 0;
                    IntForces   IF;

                    foreach (var x in d)
                    {
                        if (CLC.TryGetValue(x.Key, out  IF))
                        {
                            IF.Mx += x.Value.Mx * lf;
                            IF.Vy += x.Value.Vy * lf;
                            IF.N  += x.Value.N * lf;
                            CLC[x.Key] = IF;
                        }
                        else
                        {
                            IF.Mx = x.Value.Mx * lf;
                            IF.Vy = x.Value.Vy * lf;
                            IF.N = x.Value.N * lf;
                            CLC.Add(x.Key, IF);
                        }
                    }
                }
                }
                return CLC;
            }
        }
        /// <summary>
        /// get internal forces at specific position
        /// </summary>
        /// <param name="loadCase"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public IntForces                    getInternalForces(string loadCase, double position)
        {
            string k = loadCase;
            double x = position;
            IntForces iForce = new IntForces();

            // checa se tem a posição pedida no vetor
            if (InternalForces[k].ContainsKey(x))
            {
                var f = InternalForces[k];
                iForce = f[x];
            }

            // se nao tiver, interpola os valores
            else
            {
                var f = InternalForces[k];
                var lista = f.Keys.ToList();

                var xb = (from n in lista where (n < x) select n).ToList().Last(); // pega o valor imediatamente abaixo do ponto x 
                var xa = (from n in lista where (n > x) select n).ToList().First(); // pega o valor imediatamente acima do ponto x

                double mb = f[xb].Mx;
                double ma = f[xa].Mx;
                double vb = f[xb].Vy;
                double va = f[xa].Vy;

                double mx = (x - xa) * (mb - ma) / (xb - xa) + ma;
                double vx = (x - xa) * (vb - va) / (xb - xa) + va;

                iForce.Mx = mx;
                iForce.Vy = vx;
                iForce.N  = 0;
                //g.OrderByDescending(c=> c < x);
            }

            return iForce;
        }
        /// <summary>
        /// get internal forces for a combination
        /// </summary>
        /// <param name="lc"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public IntForces                    getInternalForces(clsLoadCombination lc, double position)
        {
            double x            = position;
            IntForces iForce    = new IntForces();
            int c               = LCase.Count();                        // take number of load cases
            double                lf;

            for(int i = 0; i < c; i++)
            {
                string k        = LCase[i].Name;
                string ldtype   = LCase[i].LClass.Name;
                var f           = this.calculateCombIntForces(lc);
               // lf              = lc.getLoadFactor(ldtype);            // take load factor/multiplier for that load type
                    
                if(f.TryGetValue(x, out iForce))
                    {
                    //var v = f.Where(b => b.Key == x);
                    //iForce      = v.First().Value;
                    iForce.N    = f[x].N;
                    iForce.Mx   = f[x].Mx; 
                    iForce.Vy   = f[x].Vy;
                    


                }
                else
                {
                    var lista = f.Keys.ToList();

                    var xb = (from n in lista where (n < x) select n).ToList().Last();  // pega o valor imediatamente abaixo do ponto x 
                    var xa = (from n in lista where (n > x) select n).ToList().First(); // pega o valor imediatamente acima do ponto x

                    double mb = f[xb].Mx;
                    double ma = f[xa].Mx;
                    double vb = f[xb].Vy;
                    double va = f[xa].Vy;

                    double mx = (x - xa) * (mb - ma) / (xb - xa) + ma;
                    double vx = (x - xa) * (vb - va) / (xb - xa) + va;

                    //iForce.Mx += mx * lf;
                    //iForce.Vy += vx * lf;
                    //iForce.N  += 0;
                    iForce.Mx = mx ;
                    iForce.Vy = vx ;
                    iForce.N = 0;
                }

            }
            // checa se tem a posição pedida no vetor


            // se nao tiver, interpola os valores

            return iForce;
        }
        /// <summary>
        /// set lateral bracing on beam
        /// </summary>
        /// <param name="position"></param>
        public void                         setLateralBracing(double position, bool top, bool bottom)
        {
            if (top)
            {
                toplateralBracing.Add(position);
            }
            if (bottom)
            {
                bottomlateralBracing.Add(position);
            }

        }
        /// <summary>
        /// calculate cb
        /// </summary>
        /// <param name="position"></param>
        /// <param name="Lcase"></param>
        public double                       calculateCb(double position, clsLoadCombination lc, ref double Lb)
        {
            double x = position;
            var IF = this.calculateCombIntForces(lc);

            string k = lc.name;
            double Rm = 1;
            //double Lb;
            double inf = 0;
            double sup = 0;
            double Mx = this.getInternalForces(lc, position).Mx;
            var lbtop = toplateralBracing.OrderBy(d => d).ToList();
            var lbbot = bottomlateralBracing.OrderBy(d => d).ToList();
           
            if (Mx >= 0)
            {
                if (toplateralBracing.Count == 0) { Lb = Length; }
                else
                {
                    inf = lbtop.Where(c => c <= x).ToList().Last();
                    sup = lbtop.Where(c => c >= x).ToList().First();
                    Lb = sup - inf;
                }
            }
            else
            {
                if (bottomlateralBracing.Count == 0) { Lb = Length; }
                else
                {
                    inf = lbbot.Where(c => c <= x).ToList().Last();
                    sup = lbbot.Where(c => c >= x).ToList().First();
                    Lb = sup - inf;
                }
            }

            var M = IF.Where(c => c.Key >= inf && c.Key <= sup).ToList();
            var Mmax = M.Max(c => Math.Abs(c.Value.Mx));
            double MA = Math.Abs(this.getInternalForces(lc, inf + 0.25 * Lb).Mx);
            double MB = Math.Abs(this.getInternalForces(lc, inf + 0.50 * Lb).Mx);
            double MC = Math.Abs(this.getInternalForces(lc, inf + 0.75 * Lb).Mx);

            var Mpos = IF.Where(c => c.Value.Mx > 0).ToList();
            var Mneg = IF.Where(c => c.Value.Mx < 0).ToList();

            double Iyc = 0;

            // checa se o perfil é assimetrico e se tem curvatura reversa
            #region assimetrico
            if (CS.profCode == 102)
            {
                if (Mpos.Count() > 0 && Mneg.Count() > 0)
                {
                    double bfs = CS.bfs;
                    double tfs = CS.tfs;
                    double bfi = CS.bfi;
                    double tfi = CS.tfi;
                    double M1 = getInternalForces(k, x).Mx;

                    // top flange in compression
                    if (M1 >= 0)
                    {
                        Iyc = tfs * bfs * bfs * bfs / 12;
                    }
                    // bottom flange in compression
                    else
                    {
                        Iyc = tfi * bfi * bfi * bfi / 12;
                    }
                }
                Rm = 0.5 + 2 * Math.Pow((Iyc / CS.Iy), 2);
            }
            #endregion

            double cb = ((12.5 * Mmax) / (2.5 * Mmax + 3 * MA + 4 * MB + 3 * MC)) * Rm;
            if (cb > 3) { cb = 3; }

            return cb;
        }
        /// <summary>
        /// Generate possible load classes
        /// </summary>
        private void                        generateLoadCombinations()
        {
           
            this.LClass = new List<clsLoadClass>();
            // generate load class
            clsLoadClass lc1 = new clsLoadClass(1, "PP",  1.25,  1.0,   1.0,   1.0,   false);
            clsLoadClass lc2 = new clsLoadClass(2, "CP",  1.25,  1.0,   1.0,   1.0,   false);
            clsLoadClass lc3 = new clsLoadClass(3, "SCC", 1.50,  0.8,   0.7,   0.6,   true);
            clsLoadClass lc4 = new clsLoadClass(4, "SCP", 1.50,  0.7,   0.6,   0.4,   true);
            clsLoadClass lc5 = new clsLoadClass(5, "V",   1.40,  0.6,   0.3,   0.0,   true);
            lc5.isWind       = true;

            LClass.Add(lc1);
            LClass.Add(lc2);
            LClass.Add(lc3);
            LClass.Add(lc4);
            LClass.Add(lc5);

            // generate load cases
            clsLoadCase lcs1 = new clsLoadCase(1, "Peso Proprio",           lc1);
            clsLoadCase lcs2 = new clsLoadCase(2, "Carga Permanente",       lc2);
            clsLoadCase lcs3 = new clsLoadCase(3, "Sobrecarga de Cobertura",lc3);
            clsLoadCase lcs4 = new clsLoadCase(4, "Sobrecarga de Piso",     lc4);
            clsLoadCase lcs5 = new clsLoadCase(5, "Vento",                  lc5);

            LCase = new List<clsLoadCase>();
            LCase.Add(lcs1);
            LCase.Add(lcs2);
            LCase.Add(lcs3);
            LCase.Add(lcs4);
            LCase.Add(lcs5);

            // generating ULS combinations
            clsLoadCombination lco1 = new clsLoadCombination(1,"ELU: 1.25CP + 1.50SCC + 1.05SCP + 0.84V", combType.ULS,  lc1.gama,  lc3.gama,            lc4.gama*lc4.psi0,   lc5.gama * lc5.psi0);
            clsLoadCombination lco2 = new clsLoadCombination(2,"ELU: 1.25CP + 1.20SCC + 1.50SCP + 0.84V", combType.ULS,  lc1.gama,  lc3.gama*lc3.psi0,   lc4.gama ,           lc5.gama * lc5.psi0);
            clsLoadCombination lco3 = new clsLoadCombination(3,"ELU: 1.25CP + 1.20SCC + 1.05SCP + 1.40V", combType.ULS,  lc1.gama,  lc3.gama*lc3.psi0,   lc4.gama * lc4.psi0, lc5.gama);
            clsLoadCombination lco4 = new clsLoadCombination(4,"ELU: 1.00CP + 1.40V",                     combType.ULS,  1.00,      0,                   0,                   lc5.gama);

            // generating SLS - QP
            clsLoadCombination lco5 = new clsLoadCombination(5, "ELS QP: 1.00CP + 0.60SCC + 0.40SCP "  , combType.SLS, 1, lc3.psi2, lc4.psi2, lc5.psi2);

            // generating SLS - FREQ
            clsLoadCombination lco6 = new clsLoadCombination(6, "ELS FREQ: 1.00CP + 0.70SCC + 0.40SCP ",         combType.SLS, 1.00, lc3.psi1, lc4.psi2, lc5.psi2);
            clsLoadCombination lco7 = new clsLoadCombination(7, "ELS FREQ: 1.00CP + 0.60SCC + 0.60SCP ",         combType.SLS, 1.00, lc3.psi2, lc4.psi1, lc5.psi2);
            clsLoadCombination lco8 = new clsLoadCombination(8, "ELS FREQ: 1.00CP + 0.60SCC + 0.40SCP + 0.30V ", combType.SLS, 1.00, lc3.psi2, lc4.psi2, lc5.psi1);

            // generating SLS - RARA
            clsLoadCombination lco9  = new clsLoadCombination (9,  "ELS RARA: 1.00CP + 1.00SCC + 0.60SCP + 0.30V ", combType.SLS, 1.00,  1.00,      lc4.psi1,  lc5.psi1);
            clsLoadCombination lco10 = new clsLoadCombination (10, "ELS RARA: 1.00CP + 0.70SCC + 1.00SCP + 0.30V ", combType.SLS, 1.00,  lc3.psi1,  1.00,      lc5.psi1);
            clsLoadCombination lco11 = new clsLoadCombination (11, "ELS RARA: 1.00CP + 0.70SCC + 0.60SCP + 1.00V ", combType.SLS, 1.00,  lc3.psi1,  lc4.psi1,  1.0       );

            LCombination = new List<clsLoadCombination>();
            LCombination.Add(lco1);
            LCombination.Add(lco2);
            LCombination.Add(lco3);
            LCombination.Add(lco4);
            LCombination.Add(lco5);
            LCombination.Add(lco6);
            LCombination.Add(lco7);
            LCombination.Add(lco8);
            LCombination.Add(lco9);
            LCombination.Add(lco10);
            LCombination.Add(lco11);

            clsIOManager io = new clsIOManager();
            io.printCombinations(LCombination);
        }
        /// <summary>
        /// Calculate beam, generate nodal internal forces and span internal forces , generate support reactions
        /// </summary>
        private void                        generateSelfWeightLoad()
        {
            double pp = this.CS.wgt * 0.01;
            clsLoad swLoad = new clsLoad(5, "Peso Proprio", 0, -pp, 0, MainWin.DesignConfigs.LoadCases[0], LoadType.D, 0);
            this.addLineLoad(swLoad);
        }
        /// <summary>
        /// Proceed to beam structural analisys
        /// </summary>
        public void                         CalculateBeam()
        {
            this.generateSelfWeightLoad();
            this.AssembleModel();
            this.solveEquation();
            this.calculateInternalForces();
            this.calculateReactions();
            this.calculeSpanInternalForces();
            this.calculateSpanDisplacements();
            //var cb = this.calculateCb(3, this.LCombination.First());
            //var teste = this.calculateCombIntForces(this.LCombination.First());
            
        }
        /// <summary>
        /// gets maximum deflection for an specific direction and for all SLS combinations
        /// </summary>
        /// <param name="direction">direction: down or uplift </param>
        /// <returns></returns>
        public Dictionary<string,Dictionary<double, double>> GetMaxCombDeflections(string direction)
        {
            Dictionary<string, Dictionary<double, double>>  result = new Dictionary<string, Dictionary<double, double>>();
            Dictionary<string, Dictionary<double, double>> result_aux = new Dictionary<string, Dictionary<double, double>>();

            var ELScomb = LCombination.Where(c => c.cbType == combType.SLS).ToList();

            foreach(var dsp in ELScomb)
            {
                var aux = calculateCombDisplacements(dsp);
                result_aux.Add(dsp.name, aux);
            }

            if (direction.CompareTo("down") == 0)
            {
                foreach (var r in result_aux)
                {
                    string k = r.Key;

                    var a = result_aux.Values.Min();

                    result.Add(k, a);
                }
            }
            else if (direction.CompareTo("uplift") == 0)
            {
                foreach (var r in result_aux)
                {
                    string k = r.Key;

                    var a = result_aux.Values.Max();

                    result.Add(k, a);
                }
            }

            return result;
        }
    }
}
