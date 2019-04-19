using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEM;
using System.IO;
using MainWin;
using DATAACCESS;
using NBR8800;


namespace Beam
{
    public struct bar
    {
        public clsNode pt1, pt2;
        public int ID;
        public clsCsSection profile;
    }

    class clsIOManager
    {
        List<clsNode>       nodes       = new List<clsNode>();
        List<double>        vaos;
        List<bar>           bars        = new List<bar>();
        List<clsCsSection>  profileList = new List<clsCsSection>();
        List<clsLoadCase>   loadCases;
        List<clsLoad>       loads       = new List<clsLoad>();
        List<clsSupport>    supports    = new List<clsSupport>();
        string              appPath;
        double              coordY      = 0.0f;
        int                 nVao;
        string              ID;


        public                  clsIOManager(List<double> _vaos, List<clsLoad> _load)
        {

            vaos = _vaos;
            nVao = vaos.Count();
            loads = _load;
            generatenodes();
            generateSupports();

        }

        public                  clsIOManager()
        {
           
        }

        /// <summary>
        /// generate list os nodes
        /// </summary>
        public void             generatenodes()
        {
            clsPoint pt1 = new clsPoint(0, 0, coordY);
            double coord = 0;

            for (int i = 0; i < nVao; i++)
            {
                if (i == 0)
                {
                    clsNode nd1 = new clsNode(i, pt1);
                    Console.WriteLine("gerando nos");
                    clsPoint pt2 = new clsPoint(i + 1, vaos[i], coordY);
                    clsNode nd2 = new clsNode(i + 1, pt2);

                    nodes.Add(nd1);
                    nodes.Add(nd2);
                    coord += vaos[i];
                }
                else
                {
                    Console.WriteLine("gerando nos");
                    double L = vaos[i] + coord;
                    coord += vaos[i];
                    clsPoint pt = new clsPoint(i, L, coordY);
                    clsNode nd = new clsNode(i + 1, pt);

                    nodes.Add(nd);

                }
            }
        }

        /// <summary>
        /// generate bar list
        /// </summary>
        public void             generateBars(clsCsSection _profile)
        {
            this.sortnodesByCoord();
            for (int i = 0; i < nodes.Count() - 1; i++)
            {
                Console.WriteLine("gerando barras");
                if (i == 0)
                {
                    bar b = new bar();
                    b.pt1 = nodes[i];
                    b.pt2 = nodes[i + 1];
                    b.ID = i;
                    b.profile = _profile;
                    bars.Add(b);

                }

                else
                {
                    bar b = new bar();
                    b.ID = i;
                    b.pt1 = nodes[i];
                    b.pt2 = nodes[i + 1];
                    b.profile = _profile;
                    bars.Add(b);

                }

            }
            this.sortnodesByID();
        }

        /// <summary>
        /// generate supports
        /// </summary>
        public void             generateSupports()
        {

            int n = nodes.Count();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("gerando suportes");
                if (i == 0)
                {
                    clsSupport s = new clsSupport(i, 1, 1, 0, nodes[i].ID);
                    nodes[i].AddSupport(s);
                }
                else
                {
                    clsSupport s = new clsSupport(i, 0, 1, 0, nodes[i].ID);
                    nodes[i].AddSupport(s);
                }
            }
        }

        public void             addNode(clsPoint pt)
        {
            clsNode nd = new clsNode(this.nodes.Count(), pt);
            this.nodes.Add(nd);

        }

        public void             sortnodesByCoord()
        {
            IEnumerable<clsNode> orderedList = this.nodes.OrderBy(coord => coord.GetCoord().x);
            this.nodes = orderedList.ToList();
        }

        public void             sortnodesByID()
        {
            IEnumerable<clsNode> orderedList = this.nodes.OrderBy(coord => coord.ID);
            this.nodes = orderedList.ToList();
        }

        public List<clsNode>    getnodes() { return this.nodes; }

        public List<bar>        getBars() { return this.bars; }

        public bool             createBeamInputFile(
                                                    string name, 
                                                    List<float> vaos, 
                                                    List<float>lbTop,
                                                    List<float>lbBottom, 
                                                    List<Load> loads,
                                                    string CStable,
                                                    string CSSection,
                                                    string Steel)
        {
            try
            {
            
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath+@"\Beams\"+ name +".cdv",false);

            using (fl)
            {
                fl.WriteLine("#CADIFEM V1.0");
                fl.WriteLine("#NAME");
                fl.WriteLine(name);

                fl.WriteLine("#SPANS");   
                foreach(var v in vaos)
                {
                    fl.WriteLine(v);
                }
                fl.WriteLine("#END");

                fl.WriteLine("#SECTION");
                fl.WriteLine("{0};{1};{2}",CStable, CSSection, Steel);

                fl.WriteLine("#LATERAL_SUPPORT_POSITION");
                for(int i = 0; i < lbTop.Count(); i++)
                {
                    fl.WriteLine("{0};{1}", "top", lbTop[i]);
                }
                for(int i = 0; i < lbBottom.Count(); i++)
                {
                    fl.WriteLine("{0};{1}", "bottom", lbBottom[i]);
                }
                fl.WriteLine("#END");
                
                fl.WriteLine("#DISTLOADS");
                var pl = from p in loads where (p.type == "D") select p;
                foreach(var p in pl)
                {
                    fl.WriteLine("{0};{1};{2};{3}", p.ID, p.description, p.Py, p.loadCase);
                }
                fl.WriteLine("#END");

                fl.WriteLine("#POINTLOADS");
                var pp = from p in loads where (p.type == "P") select p;
                foreach (var p in pp)
                {
                    fl.WriteLine("{0};{1};{2};{3};{4}", p.ID, p.description, p.position, p.Py, p.loadCase);
                }
                fl.WriteLine("#END");
                fl.WriteLine("#ENDALL");
            }
                fl.Close();
            return true;
            }
            catch(IOException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                
                return false;
            }
        }

        public clsBeam          readBeamInputFile(string fileName)
        {
            try
            {
                StreamReader file = new StreamReader(ProjectInfo.projectPath + @"\Beams\" + fileName, false);

                string name = "";
                List<double> vaos = new List<double>();
                List<double> lbtop = new List<double>();
                List<double> lbbottom = new List<double>();
                List<clsLoad> loads = new List<clsLoad>();
                clsCsSection CS = new clsCsSection();
                clsMaterial Mat = new clsMaterial();
                string table = "";
                string csname = "";
                string aco = "";

                #region Leitura do arquivo

                string aux = file.ReadLine(); // Le a versao do software
                if (aux != null)
                {
                    while (aux.CompareTo("#ENDALL") != 0)
                    {
                        aux = file.ReadLine();

                        switch (aux)
                        {
                            case "#NAME":
                                aux = file.ReadLine();
                                name = aux;
                                break;
                            case "#SPANS":
                                {
                                    aux = file.ReadLine();

                                    while (aux.CompareTo("#END") != 0)
                                    {
                                        vaos.Add(double.Parse(aux));
                                        aux = file.ReadLine();
                                    }
                                }
                                break;
                            case "#SECTION":
                                {
                                    aux = file.ReadLine();
                                    var aux1 = aux.Split(';');
                                    table = aux1[0];
                                    csname = aux1[1];
                                    aco = aux1[2];
                                }
                                break;
                            case "#LATERAL_SUPPORT_POSITION":
                                {
                                    aux = file.ReadLine();
                                    while (aux.CompareTo("#END") != 0)
                                    {
                                        var aux1 = aux.Split(';');
                                        switch (aux1[0])
                                        {
                                            case "top":
                                                lbtop.Add(double.Parse(aux1[1]));
                                                break;
                                            case "bottom":
                                                lbbottom.Add(double.Parse(aux1[1]));
                                                break;
                                        }
                                        aux = file.ReadLine();
                                    }
                                }
                                break;
                            case "#DISTLOADS":
                                {
                                    aux = file.ReadLine();
                                    while (aux.CompareTo("#END") != 0)
                                    {
                                        clsLoad l = new clsLoad();
                                        var aux1 = aux.Split(';');
                                        l.ID = int.Parse(aux1[0]);
                                        l.name = aux1[1];
                                        l.Px = 0;
                                        l.Mz = 0;
                                        l.Py = double.Parse(aux1[2]);
                                        l.lType = LoadType.D;
                                        string lc = aux1[3];
                                        var lcase = (from lcs in DesignConfigs.LoadCases where lcs.Name == lc select lcs).SingleOrDefault();
                                        l.LoadCase = lcase;
                                        l.a = 0;

                                        loads.Add(l);

                                        aux = file.ReadLine();
                                    }
                                }
                                break;
                            case "#POINTLOADS":
                                {
                                    aux = file.ReadLine();
                                    while (aux.CompareTo("#END") != 0)
                                    {
                                        clsLoad l = new clsLoad();
                                        var aux1 = aux.Split(';');

                                        l.ID = int.Parse(aux1[0]);
                                        l.name = aux1[1];
                                        l.a = double.Parse(aux1[2]);
                                        l.Px = 0;
                                        l.Mz = 0;
                                        l.Py = double.Parse(aux1[3]);
                                        l.lType = LoadType.P;
                                        string lc = aux1[4];
                                        var lcase = (from lcs in DesignConfigs.LoadCases where lcs.Name == lc select lcs).SingleOrDefault();
                                        l.LoadCase = lcase;

                                        loads.Add(l);

                                        aux = file.ReadLine();
                                    }
                                }
                                break;
                        }
                        //aux = file.ReadLine(); 


                    }
                    #endregion

                    #region criação do elemento beam
                    // selecionando o perfil na respectiva tabela
                    MapeiaPerfil(table, csname, ref CS);
                    MapeiaAco(aco, ref Mat);
                    CS.material = Mat;

                    clsBeam beam = new clsBeam(name, vaos, CS);

                    // inserindo os carregamentos
                    var pl = from p in loads where p.lType == LoadType.P select p;
                    beam.Loads = loads;
                    foreach (var ld in pl)
                    {
                        beam.addPointLoadonBeam(ld);
                    }

                    var dl = from p in loads where p.lType == LoadType.D select p;
                    foreach (var ld in dl)
                    {
                        beam.addLineLoad(ld);
                    }

                    beam.CS = CS;
                    #endregion
                    #region Insere travamentos laterais
                    foreach (var a in lbtop)
                    {
                        beam.setLateralBracing(a, true, false);
                    }
                    foreach (var a in lbbottom)
                    {
                        beam.setLateralBracing(a, false, true);
                    }
                    #endregion
                    file.Close();
                    // System.Windows.Forms.MessageBox.Show("Leitura Completa");
                    return beam;

                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("Arquivo Vazio");
                    file.Close();
                    return null;
                }
            }
            catch(IOException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        //private List<clsNode>   readnodes(StreamReader file, string tag)
        //{
        //    Console.WriteLine("Lendo nós");
        //    List<clsNode> n = new List<clsNode>();
        //    string aux = tag;
        //    aux = file.ReadLine();
        //    int i = 0;
        //    while (aux.CompareTo("#END") != 0)
        //    {

        //        string[] aux2 = aux.Split(';');
        //        clsPoint pt = new clsPoint(i, double.Parse(aux2[1]), double.Parse(aux2[2]));
        //        clsNode nd = new clsNode(pt);
        //        nd.ID = int.Parse(aux2[0]);
        //        n.Add(nd);
        //        aux = file.ReadLine();
        //        i += i + 1;
        //    }
        //    Console.WriteLine("nós lidos");
        //    return n;
        //}

        //private List<bar>       readBars(StreamReader file, string tag)
        //{
        //    Console.WriteLine("lendo barras");
        //    List<bar> b = new List<bar>();
        //    string aux = tag;
        //    aux = file.ReadLine();
        //    while (aux.CompareTo("#END") != 0)
        //    {

        //       
        //        string[] aux2 = aux.Split(';');
        //        bar br = new bar();
        //        br.ID = int.Parse(aux2[0]);

        //        int pt1ID = int.Parse(aux2[1]);
        //        int pt2ID = int.Parse(aux2[2]);
        //        // int pID1  = int.Parse(aux2[3]);

        //        var pt1 = (from nd in nodes where (nd.ID) == pt1ID select nd).ToList();
        //        var pt2 = (from nd in nodes where (nd.ID) == pt2ID select nd).ToList();

        //        br.pt1 = pt1[0];
        //        br.pt2 = pt2[0];
        //        b.Add(br);
        //        aux = file.ReadLine();

        //    }
        //    Console.WriteLine("barras lidas");
        //    return b;

        //}

        //public List<clsSupport> readSupports(StreamReader file, string tag)
        //{
        //    Console.WriteLine("lendo suportes");
        //    string aux = tag;
        //    aux = file.ReadLine();
        //    List<clsSupport> lsp = new List<clsSupport>();

        //    while (aux.CompareTo("#END") != 0)
        //    {

        //        string[] aux2 = aux.Split(';');
        //        clsSupport sp = new clsSupport(int.Parse(aux2[0]), int.Parse(aux2[1]), int.Parse(aux2[2]), int.Parse(aux2[3]), int.Parse(aux2[4]));
        //        aux = file.ReadLine();
        //        this.supports.Add(sp);

        //        var n = (from nd in nodes where (nd.ID) == (sp.Owner) select nd).ToList();
        //        n[0].AddSupport(sp);


        //    }

        //    Console.WriteLine("suportes lidos");
        //    return lsp;
        //}

        public void             setLoadCases(List<clsLoadCase> _LCase)
        {
            this.loadCases = _LCase;
        }

        public void             printKGL(double[,] kgl, int n, int m)
        {

            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" +"KGL" + ".txt", false);

            using (fl)
            {
                for (int i = 0; i < n * 2; i++)
                {
                    for (int j = 0; j < m * 2; j++)
                    {
                        fl.Write("{0,15:f4}\t", kgl[i, j]);
                    }
                    fl.WriteLine();
                    fl.WriteLine();
                }


            }
        }

        public void             printNodes(List<clsNode> nd)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" +"Nos" + ".txt", false);
            int n = nd.Count();
            Console.WriteLine(n);

            using (fl)
            {
                // write nodes

                for (int i = 0; i < n; i++)
                {
                    fl.WriteLine(nd[i].ID + "; " + nd[i].GetCoord().x + ";" + nd[i].GetCoord().y);
                    Console.WriteLine(nd[i].ID + ";" + nd[i].GetCoord().x + ";" + nd[i].GetCoord().y);
                }
            }

        }

        public void             printLength(List<clsElement> L)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" +"Comprimentos" + ".txt", false);
            

            using (fl)
            {
                // write nodes

                foreach( clsElement n in L)
                {
                    fl.WriteLine(n.Length);
                }
            }
        }

        public void             printSupports(List<clsNode> nd)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" +"apoios" + ".txt", false);
            using (fl)
            {
                foreach (var n in nd)
            {
               
                    if (n.isSupport)
                    {
                        fl.WriteLine("Apoio no nó: {0}", n.ID);
                    }
                }
            }

        }

        public void             printDisplacements(Dictionary<string,double[]> U)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath  + @"\Beams\" + "Deslocamentos" + ".txt", false);

            using (fl)
            {
                foreach(var u in U)
                {
                    var k = u.Key;
                    fl.WriteLine("Carregamento: {0}", k);

                    foreach (var i in u.Value)
                    {
                        fl.WriteLine("{0,7:f3}\t\t",i);
                        //fl.Write("{0}\t\t", i);
                    }

                }
            }

        }

        public void             printNodalInternalForces(List<clsNode> N)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath  + @"\Beams\" + "Esforços" + ".txt", false);

            var Lcases = DesignConfigs.LoadCases.ToList();

            using (fl)
            {
                fl.WriteLine("{0}\t{1,10:f2}{2,10:f2}{3,10:f2}", "No", "N[kN]", "Vy[kN]", "Mx[kN.m]");
                foreach (var lc in Lcases)
                {
                   
                    string k = lc.Name;
                    fl.WriteLine(k);
                    foreach (var n in N)
                    {
                        fl.WriteLine("{0}\t{1,10:f2}{2,10:f2}{3,10:f2}", n.ID,n.InternalForces[k].N, n.InternalForces[k].Vy, n.InternalForces[k].Mx);
                    }
                }
            }
        }

        public void             printEPVector(Dictionary<string, double[]> EP)
        {

            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" +"EP" + ".txt", false);
            

            using (fl)
            {
                foreach(var ep in EP)
                {
                    string k = ep.Key;
                    double[] f = EP[k];

                    for(int i = 0; i < 4; i++)
                    {
                        fl.WriteLine(f[i]);
                    }
                    fl.WriteLine("--------");

                }
            }
        }

        public void             printReactions(List<clsNode> nd)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" + "Reacoes" + ".txt", false);
            int n = nd.Count();
            var Lcases = DesignConfigs.LoadCases.ToList();

            using (fl)
            {
                fl.WriteLine("{0,10:f2} {1,10:f2} {2,10:f2} {3,10:f2}", "No", "Tx", "Ty", "Rz");
                foreach (var lc in Lcases)
                 {
                    fl.WriteLine(lc.Name);
                    string k = lc.Name;

                    // iterate throught each node
                    foreach(var node in nd)
                    {
                        if (node.isSupport)
                        {
                          //fl.WriteLine("{0,10} {1,10:f2} {2,10:f2} {3,10:f2}", node.ID, node.InternalForces[k].N, node.InternalForces[k].Vy, node.InternalForces[k].Mz);
                          fl.WriteLine("{0,10} {1,10:f2} {2,10:f2} {3,10:f2}", node.ID, node.Support.Reactions[k].Tx, node.Support.Reactions[k].Ty, node.Support.Reactions[k].Mz);
                        }
                    }
                }
            }
        }

        public void             printDiagrams(string DiagType, string lcase, Dictionary <string,Dictionary<double,IntForces>> forces)
        {
            string k =lcase;

            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" +"diagrama.txt", false);
            
            using (fl)
            {
                var F = forces[k];
                foreach(var x in F)
                {
                    if (DiagType == "M")
                    {
                        fl.WriteLine("{0,15:f5};{1,15:f5}", x.Key, -x.Value.Mx);
                    }
                    if (DiagType == "V")
                    {
                        fl.WriteLine("{0,15:f5};{1,15:f5}", x.Key, x.Value.Vy);
                    }
                }
            }
        }

        public void             printDispDiagram(Dictionary<string,Dictionary<double,double>> u, string lcase)
        {
            string k = lcase;
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" + "flecha.txt", false);

            using (fl)
            {

                var ul = u[k];
                foreach(var x in ul)
                {
                    fl.WriteLine("{0};{1}", x.Key, x.Value);
                }


            }
            
        }

        public void             printCombinations(List<clsLoadCombination> comb)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" +"Combinacoes.txt", false);

            using (fl)
            {
                fl.WriteLine("{0}\t{1,-50}{2,10:f2}\t{3,10:f2}\t{4,10:f2}\t{5,10:f2}\t{6,10:f2}", "ID","DESCRIÇÃO","PP","CP","SCC","SCP","V");
                foreach ( var lc in comb)
                {
                   
                    fl.WriteLine("{0}\t{1,-50}{2,10:f2}\t{3,10:f2}\t{4,10:f2}\t{5,10:f2}\t{6,10:f2}", lc.ID, lc.name, lc.CPfactor, lc.CPfactor, lc.SCCFactor, lc.SCPFactor, lc.VFactor);
                }
            }

        }

        public void             MapeiaPerfil(string table, string profile, ref clsCsSection Cs)
        {

            switch (table)
            {
                case "C":
                    break;
                case "CS":
                    {
                       CS c = new PerfilCS().getProfileByName(profile);
                        Cs.A = double.Parse(c.A.ToString());
                        Cs.alpha = 0;
                        Cs.bfi = double.Parse(c.bf.ToString());
                        Cs.bfs = Cs.bfi;
                        Cs.c = 0;
                        Cs.Cw = double.Parse(c.Cw.ToString());
                        Cs.d = int.Parse(c.d.ToString());
                        Cs.ID = int.Parse(c.ID.ToString());
                        Cs.It = double.Parse(c.IT.ToString());
                        Cs.Ix = double.Parse(c.Ix.ToString());
                        Cs.Iy = double.Parse(c.Iy.ToString());
                        Cs.Name = c.nome;
                        Cs.profCode = int.Parse(c.ProfCode.ToString());
                        Cs.R = int.Parse(c.R.ToString());
                        Cs.rT = double.Parse(c.rT.ToString());
                        Cs.rx = double.Parse(c.rx.ToString());
                        Cs.ry = double.Parse(c.ry.ToString());
                        Cs.table = "CS";
                        Cs.tfi = double.Parse(c.tf.ToString());
                        Cs.tfs = Cs.tfi;
                        Cs.tw = double.Parse(c.tw.ToString());
                        Cs.wgt = double.Parse(c.peso.ToString());
                        Cs.Wxi = double.Parse(c.Wx.ToString());
                        Cs.Wxs = Cs.Wxi;
                        Cs.Wy = double.Parse(c.Wy.ToString());
                        Cs.XCG = 0;
                        Cs.Zx = double.Parse(c.Zx.ToString());
                        Cs.Zy = double.Parse(c.Zy.ToString());
                        Cs.fabrication = int.Parse(c.Fabrication.ToString());
                        
                        Cs.defineCG();
                    }
                    break;
                case "VS":
                    {
                        VS c = new PerfilVS().getProfileByName(profile);
                        Cs.A = double.Parse(c.A.ToString());
                        Cs.alpha = 0;
                        Cs.bfi = double.Parse(c.bf.ToString());
                        Cs.bfs = Cs.bfi;
                        Cs.c = 0;
                        Cs.Cw = double.Parse(c.Cw.ToString());
                        Cs.d = int.Parse(c.d.ToString());
                        Cs.ID = int.Parse(c.ID.ToString());
                        Cs.It = double.Parse(c.IT.ToString());
                        Cs.Ix = double.Parse(c.Ix.ToString());
                        Cs.Iy = double.Parse(c.Iy.ToString());
                        Cs.Name = c.nome;
                        Cs.profCode = int.Parse(c.ProfCode.ToString());
                        Cs.R = int.Parse(c.R.ToString());
                        Cs.rT = double.Parse(c.rT.ToString());
                        Cs.rx = double.Parse(c.rx.ToString());
                        Cs.ry = double.Parse(c.ry.ToString());
                        Cs.table = "VS";
                        Cs.tfi = double.Parse(c.tf.ToString());
                        Cs.tfs = Cs.tfi;
                        Cs.tw = double.Parse(c.tw.ToString());
                        Cs.wgt = double.Parse(c.peso.ToString());
                        Cs.Wxi = double.Parse(c.Wx.ToString());
                        Cs.Wxs = Cs.Wxi;
                        Cs.Wy = double.Parse(c.Wy.ToString());
                        Cs.XCG = 0;
                        Cs.Zx = double.Parse(c.Zx.ToString());
                        Cs.Zy = double.Parse(c.Zy.ToString());
                        Cs.fabrication = int.Parse(c.Fabrication.ToString());
                        Cs.defineCG();
                    }
                    break;
                case "CVS":
                    {
                        CVS c = new PerfilCVS().getProfileByName(profile);
                        Cs.A = double.Parse(c.A.ToString());
                        Cs.alpha = 0;
                        Cs.bfi = double.Parse(c.bf.ToString());
                        Cs.bfs = Cs.bfi;
                        Cs.c = 0;
                        Cs.Cw = double.Parse(c.Cw.ToString());
                        Cs.d = int.Parse(c.d.ToString());
                        Cs.ID = int.Parse(c.ID.ToString());
                        Cs.It = double.Parse(c.IT.ToString());
                        Cs.Ix = double.Parse(c.Ix.ToString());
                        Cs.Iy = double.Parse(c.Iy.ToString());
                        Cs.Name = c.nome;
                        Cs.profCode = int.Parse(c.ProfCode.ToString());
                        Cs.R = int.Parse(c.R.ToString());
                        Cs.rT = double.Parse(c.rT.ToString());
                        Cs.rx = double.Parse(c.rx.ToString());
                        Cs.ry = double.Parse(c.ry.ToString());
                        Cs.table = "CVS";
                        Cs.tfi = double.Parse(c.tf.ToString());
                        Cs.tfs = Cs.tfi;
                        Cs.tw = double.Parse(c.tw.ToString());
                        Cs.wgt = double.Parse(c.peso.ToString());
                        Cs.Wxi = double.Parse(c.Wx.ToString());
                        Cs.Wxs = Cs.Wxi;
                        Cs.Wy = double.Parse(c.Wy.ToString());
                        Cs.XCG = 0;
                        Cs.Zx = double.Parse(c.Zx.ToString());
                        Cs.Zy = double.Parse(c.Zy.ToString());
                        Cs.fabrication = int.Parse(c.Fabrication.ToString());
                        Cs.defineCG();
                    }
                    break;
                case "PS":
                    {
                        PS c = new PerfilPS().getProfileByName(profile);
                        Cs.A = double.Parse(c.A.ToString());
                        Cs.alpha = 0;
                        Cs.bfi = double.Parse(c.bf.ToString());
                        Cs.bfs = Cs.bfi;
                        Cs.c = 0;
                        Cs.Cw = double.Parse(c.Cw.ToString());
                        Cs.d = int.Parse(c.d.ToString());
                        Cs.ID = int.Parse(c.ID.ToString());
                        Cs.It = double.Parse(c.IT.ToString());
                        Cs.Ix = double.Parse(c.Ix.ToString());
                        Cs.Iy = double.Parse(c.Iy.ToString());
                        Cs.Name = c.nome;
                        Cs.profCode = int.Parse(c.ProfCode.ToString());
                        Cs.R = int.Parse(c.R.ToString());
                        Cs.rT = double.Parse(c.rT.ToString());
                        Cs.rx = double.Parse(c.rx.ToString());
                        Cs.ry = double.Parse(c.ry.ToString());
                        Cs.table = "PS";
                        Cs.tfi = double.Parse(c.tf.ToString());
                        Cs.tfs = Cs.tfi;
                        Cs.tw = double.Parse(c.tw.ToString());
                        Cs.wgt = double.Parse(c.peso.ToString());
                        Cs.Wxi = double.Parse(c.Wx.ToString());
                        Cs.Wxs = Cs.Wxi;
                        Cs.Wy = double.Parse(c.Wy.ToString());
                        Cs.XCG = 0;
                        Cs.Zx = double.Parse(c.Zx.ToString());
                        Cs.Zy = double.Parse(c.Zy.ToString());
                        Cs.fabrication = int.Parse(c.Fabrication.ToString());
                        Cs.defineCG();
                    }
                    break;
                case "PSa":
                    {
                        PSa c = new PerfilPSa().getProfileByName(profile);
                        Cs.A = double.Parse(c.A.ToString());
                        Cs.alpha = 0;
                        Cs.bfi = double.Parse(c.bfi.ToString());
                        Cs.bfs = double.Parse(c.bfs.ToString());
                        Cs.c = 0;
                        Cs.Cw = double.Parse(c.Cw.ToString());
                        Cs.d = int.Parse(c.d.ToString());
                        Cs.ID = int.Parse(c.ID.ToString());
                        Cs.It = double.Parse(c.IT.ToString());
                        Cs.Ix = double.Parse(c.Ix.ToString());
                        Cs.Iy = double.Parse(c.Iy.ToString());
                        Cs.Name = c.nome;
                        Cs.profCode = int.Parse(c.ProfCode.ToString());
                        Cs.R = int.Parse(c.R.ToString());
                        Cs.rT = double.Parse(c.rT.ToString());
                        Cs.rx = double.Parse(c.rx.ToString());
                        Cs.ry = double.Parse(c.ry.ToString());
                        Cs.table = "PSa";
                        Cs.tfi = double.Parse(c.tfi.ToString());
                        Cs.tfs = double.Parse(c.tfs.ToString());
                        Cs.tw = double.Parse(c.tw.ToString());
                        Cs.wgt = double.Parse(c.peso.ToString());
                        Cs.Wxi = double.Parse(c.Wxi.ToString());
                        Cs.Wxs = double.Parse(c.Wxs.ToString());
                        Cs.Wy = double.Parse(c.Wy.ToString());
                        Cs.XCG = 0;
                        Cs.Zx = double.Parse(c.Zx.ToString());
                        Cs.Zy = double.Parse(c.Zy.ToString());
                        Cs.fabrication = int.Parse(c.Fabrication.ToString());
                        Cs.defineCG();
                    }
                    break;
                case "VSM":
                    {
                        VSM c = new PerfilVSM().getProfileByName(profile);
                        Cs.A = double.Parse(c.A.ToString());
                        Cs.alpha = 0;
                        Cs.bfi = double.Parse(c.bfi.ToString());
                        Cs.bfs = double.Parse(c.bfs.ToString());
                        Cs.c = 0;
                        Cs.Cw = double.Parse(c.Cw.ToString());
                        Cs.d = int.Parse(c.d.ToString());
                        Cs.ID = int.Parse(c.ID.ToString());
                        Cs.It = double.Parse(c.IT.ToString());
                        Cs.Ix = double.Parse(c.Ix.ToString());
                        Cs.Iy = double.Parse(c.Iy.ToString());
                        Cs.Name = c.nome;
                        Cs.profCode = int.Parse(c.ProfCode.ToString());
                        Cs.R = int.Parse(c.R.ToString());
                        Cs.rT = double.Parse(c.rT.ToString());
                        Cs.rx = double.Parse(c.rx.ToString());
                        Cs.ry = double.Parse(c.ry.ToString());
                        Cs.table = "VSM";
                        Cs.tfi = double.Parse(c.tfi.ToString());
                        Cs.tfs = double.Parse(c.tfs.ToString());
                        Cs.tw = double.Parse(c.tw.ToString());
                        Cs.wgt = double.Parse(c.peso.ToString());
                        Cs.Wxi = double.Parse(c.Wxi.ToString());
                        Cs.Wxs = double.Parse(c.Wxs.ToString());
                        Cs.Wy = double.Parse(c.Wy.ToString());
                        Cs.XCG = 0;
                        Cs.Zx = double.Parse(c.Zx.ToString());
                        Cs.Zy = double.Parse(c.Zy.ToString());
                        Cs.fabrication = int.Parse(c.Fabrication.ToString());
                        Cs.defineCG();
                    }
                    break;
                case "W":
                    {
                        W c = new PerfilW().getProfileByName(profile);
                        Cs.A = double.Parse(c.A.ToString());
                        Cs.alpha = 0;
                        Cs.bfi = double.Parse(c.bf.ToString());
                        Cs.bfs = Cs.bfi;
                        Cs.c = 0;
                        Cs.Cw = double.Parse(c.Cw.ToString());
                        Cs.d = int.Parse(c.d.ToString());
                        Cs.ID = int.Parse(c.ID.ToString());
                        Cs.It = double.Parse(c.IT.ToString());
                        Cs.Ix = double.Parse(c.Ix.ToString());
                        Cs.Iy = double.Parse(c.Iy.ToString());
                        Cs.Name = c.nome;
                        Cs.profCode = int.Parse(c.ProfCode.ToString());
                        Cs.R = int.Parse(c.R.ToString());
                        Cs.rT = double.Parse(c.rT.ToString());
                        Cs.rx = double.Parse(c.rx.ToString());
                        Cs.ry = double.Parse(c.ry.ToString());
                        Cs.table = "W";
                        Cs.tfi = double.Parse(c.tf.ToString());
                        Cs.tfs = Cs.tfi;
                        Cs.tw = double.Parse(c.tw.ToString());
                        Cs.wgt = double.Parse(c.peso.ToString());
                        Cs.Wxi = double.Parse(c.Wx.ToString());
                        Cs.Wxs = Cs.Wxi;
                        Cs.Wy = double.Parse(c.Wy.ToString());
                        Cs.XCG = 0;
                        Cs.Zx = double.Parse(c.Zx.ToString());
                        Cs.Zy = double.Parse(c.Zy.ToString());
                        Cs.fabrication = int.Parse(c.Fabrication.ToString());
                        Cs.defineCG();
                    }
                    break;
            }
        }

        public void             MapeiaAco(string SteelName, ref clsMaterial Mat)
        {
            Materials m = new Materials();
            var mt = m.getMaterialByName(SteelName);

            Mat.E = mt.E;
            Mat.G = mt.G;
            Mat.Fy = mt.Fy;
            Mat.Fu = mt.Fu;
            Mat.ID = mt.ID;
            Mat.Name = mt.name;
            Mat.uniWeight = mt.unitWeight;

        }

        public void             printDesignResults(string beamName, Dictionary<string,Dictionary<double,DsgResult>>res)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" + beamName + ".txt", false);

            using (fl)
            {
                fl.WriteLine("{0,-20:f2}\t{1,10:f2}\t{2,10:f2}\t{3,10:f2}\t{4,10:f2}\t{5,10:f2}\t{6,10:f2}\t{7,10:f2}", "POSIÇÃO", "Mdx", "Vdy", "Lb", "Mnx", "Vny", "Cb","Sd/Rd");
                foreach(var r in res)
                {
                    string k = r.Key;
                    fl.WriteLine(k);
                    var aux = res[k];
                    foreach(var r1 in aux)
                    {
                        fl.WriteLine("{0,-20:f2}\t{1,10:f2}\t{2,10:f2}\t{3,10:f2}\t{4,10:f2}\t{5,10:f2}\t{6,10:f2}\t{7,10:f2}", 
                                        r1.Key, 
                                        r1.Value.IF_Mx,
                                        r1.Value.IF_Vy, 
                                        r1.Value.Lb, 
                                        r1.Value.BendingX,
                                        r1.Value.ShearY, 
                                        r1.Value.Cb, 
                                        Math.Max(r1.Value.uc_BendingX,r1.Value.uc_ShearY));
                    }
                }
                fl.Close();
            }
        }

        public bool             removeBeamFromProject(string beamName)
        {
            try
            {
                StreamReader flr = new StreamReader(ProjectInfo.projectPath + @"\Projeto.CDP");
                List<string> file = new List<string>();

                // open file and stores it on a list<string>
                string line;
                while ((line = flr.ReadLine()) != null)
                {
                    file.Add(line);
                }

                flr.Close();
                int index = file.FindIndex(x => x == "[END_BEAMS]");
                file.Remove(beamName);

                StreamWriter flw = new StreamWriter(ProjectInfo.projectPath + @"\Projeto.CDP", false);
                using (flw)
                {
                    foreach (var item in file)
                    {
                        flw.WriteLine(item);
                    }
                }
                flw.Close();
                return true;
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }


        }

        public bool             InsertBeamOnProject(string beamName)
        {
            try
            {
                StreamReader flr = new StreamReader(ProjectInfo.projectPath + @"\Projeto.CDP");
                List<string> file = new List<string>();

                // open file and stores it on a list<string>
                string line;
                while ((line = flr.ReadLine()) != null)
                {
                    file.Add(line);
                }

                flr.Close();
                int index = file.FindIndex(x => x == "[END_BEAMS]");
                file.Insert(index, beamName);

                StreamWriter flw = new StreamWriter(ProjectInfo.projectPath + @"\Projeto.CDP", false);
                using (flw)
                {
                    foreach (var item in file)
                    {
                        flw.WriteLine(item);
                    }
                }
                flw.Close();
                return true;
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                
                return false;
            }
        }

    }
}
