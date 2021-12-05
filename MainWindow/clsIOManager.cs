using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEM;
using System.IO;
using MainWin;
using NBR6118_2014;
using System.Globalization;
using System.Windows.Forms;

namespace Beam
{
    public struct bar
    {
        public clsNode pt1, pt2;
        public int ID;
        public CsSection profile;
    }

    class clsIOManager
    {
        List<clsNode>       nodes       = new List<clsNode>();
        List<double>        vaos;
        List<bar>           bars        = new List<bar>();
        List<CsSection>     profileList = new List<CsSection>();
        List<clsLoadCase>   loadCases;
        List<clsLoad>       loads       = new List<clsLoad>();
        List<clsSupport>    supports    = new List<clsSupport>();
        public List<Material>      concreteMaterial = new List<Material>();
        public List<RebarMaterial> rebarMaterial = new List<RebarMaterial>();
        public List<Rebar> rebar = new List<Rebar>();
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
        public void             generateBars(CsSection _profile)
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

        
        public bool createBeamInputFile(
                                                       string name,
                                                       List<float> vaos,
                                                       List<Load> loads,
                                                       string CSName,
                                                       string concrete,
                                                       double b,
                                                       double h,
                                                       double c
                                                               )
        {

            try
            {
            
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath+@"\Beams\"+ name +".cdv",false);

            using (fl)
            {
                fl.WriteLine("#EASYFRAME V1.0");
                fl.WriteLine("#NAME");
                fl.WriteLine(name);

                fl.WriteLine("#SPANS");   
                foreach(var v in vaos)
                {
                    fl.WriteLine(v);
                }
                fl.WriteLine("#END");

                    // TODO: atualizar as linhas para a seçao que serão gravadas

                fl.WriteLine("#SECTION");
                fl.WriteLine("{0};{1};{2};{3};{4}", CSName, b, h, c, concrete);

               /* fl.WriteLine("#LATERAL_SUPPORT_POSITION");
                for(int i = 0; i < lbTop.Count(); i++)
                {
                    fl.WriteLine("{0};{1}", "top", lbTop[i]);
                }
                for(int i = 0; i < lbBottom.Count(); i++)
                {
                    fl.WriteLine("{0};{1}", "bottom", lbBottom[i]);
                }
                fl.WriteLine("#END");*/
                
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

            string name = "";
            List<double> vaos = new List<double>();
            List<clsLoad> loads = new List<clsLoad>();
            //CsSection CS = new CsSection();
            Material Mat = new Material();
            string csname = "";
            double b=0;
            double h=0;
            double c=0;

            try
            {
                StreamReader file = new StreamReader(ProjectInfo.projectPath + "\\Beams\\" + fileName, false);
                             
                
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
                                    csname = aux1[0];
                                    b = double.Parse(aux1[1]);
                                    h = double.Parse(aux1[2]);
                                    c = double.Parse(aux1[3]);
                                    string trash = aux1[4];
                                    
                                    this.ReadMaterialTable();
                                    Mat = concreteMaterial.Find(m=>m.Name==trash);
   
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
                                        l.Py = -1*double.Parse(aux1[2]);
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
                                        l.Py = -1*double.Parse(aux1[3]);
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


                    CsSection CS = new CsSection(1, csname, b, h, Mat, c);
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

        public List<string>     readProjectFile(string ProjetcFilePath)
        {
            StreamReader fl = new StreamReader(ProjetcFilePath, false);
            List<string> file = new List<string>();
            List<string> beamList = new List<string>();


            using (fl)
            {
                string line;
                while ((line = fl.ReadLine()) != null)
                {
                    file.Add(line);
                }
            }
            fl.Close();

            int index = file.FindIndex(c => c == "[BEAMS]");
            index++;
            while (file[index] != "[END_BEAMS]")
            {
                beamList.Add(file[index]);

                index++;
            }


            return beamList;
        
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
      
        public void             printDesignResults(string beamName, Dictionary<string,Dictionary<double,DsgResult>>res)
        {
            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" + beamName + ".txt", false);

            using (fl)
            {
                fl.WriteLine("{0,-20:f2}\t{1,10:f2}\t{2,10:f2}\t{3,10:f2}\t{4,10:f2}\t{5,10:f2}\t{6,10:f2}\t{7,10:f2}", "POSIÇÃO", "Mdx", "Vdy", "As", "As`", "Asw", "Flecha","Status");
                foreach(var r in res)
                {
                    string k = r.Key;
                    fl.WriteLine(k);
                    var aux = res[k];
                    foreach(var r1 in aux)
                    {
                        fl.WriteLine("{0,-20:f2}\t{1,10:f2}\t{2,10:f2}\t{3,10:f2}\t{4,10:f2}\t{5,10:f2}\t{6,10:f2}\t{7,10:f2}",
                                        r1.Key,
                                        r1.Value.IF_Mdx,
                                        r1.Value.IF_Vdy,
                                        r1.Value.Asi,
                                        r1.Value.Ass,
                                        r1.Value.Asw,
                                        r1.Value.wtotal,
                                        r1.Value.status);
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
                File.Delete(ProjectInfo.projectPath + "\\Beams\\" + beamName + ".cdv");
                File.Delete(ProjectInfo.projectPath + "\\Beams\\" + beamName + ".txt");
                return true;
                
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }


        }

        public void             CopyBeam(string CpBeam, string NewBeam, string _UltimaViga)
        {
            string UltimaViga = _UltimaViga;
            try
            {
                File.Copy(CpBeam, NewBeam);

                // copia o arquivo
                string buffer = File.ReadAllText(NewBeam);
                var CpBeamName = CpBeam.Split('\\');
                var NewBeamName = NewBeam.Split('\\');

                var A = CpBeamName.Last().Split('.').First();
                var B = NewBeamName.Last().Split('.').First();
                buffer = buffer.Replace(A,B);
                File.WriteAllText(NewBeam, buffer);

                // Modifica o arquivo Projeto.CDP para incluir o nome da nova viga na lista
                string NomeProjeto = ProjectInfo.projectPath + "\\"+ ProjectInfo.projectFileName;
                string buffer2 = File.ReadAllText(NomeProjeto);
                int i = buffer2.IndexOf(UltimaViga);
                buffer2 = buffer2.Insert(i+UltimaViga.Length, "\r\n"+B);
                File.WriteAllText(NomeProjeto, buffer2);

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

        }

        public void SaveProjectAs(string ActualFolder, string DestinationFolder)
        {
            if (!Directory.Exists(DestinationFolder))
                Directory.CreateDirectory(DestinationFolder);
            string[] files = Directory.GetFiles(ActualFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(DestinationFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(ActualFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(DestinationFolder, name);
                SaveProjectAs(folder, dest);
            }
            ProjectInfo.projectPath = DestinationFolder;
            
        }
        public void             ReadMaterialTable()
        {
            StreamReader fileConcrete = new StreamReader(AppInfo.appDataPath + @"\Material.dat", false);
            string buffer;
            
            buffer = fileConcrete.ReadLine();

            buffer = fileConcrete.ReadLine();
            if (buffer.CompareTo("#BEGIN") == 0)
            {
                buffer = fileConcrete.ReadLine();
                while (buffer.CompareTo("#END") != 0)
                {
                    var aux = buffer.Split(';');
                    TipoAgregado ag;
                    switch (aux[3])
                    {
                        case "GRANITO":
                            ag = TipoAgregado.GRANITO;
                            break;

                        case "BASALTO":
                            ag = TipoAgregado.BASALTO;
                            break;
                        case "CALCARIO":
                            ag = TipoAgregado.CALCARIO;
                            break;
                        case "ARENITO":
                            ag = TipoAgregado.ARENITO;
                            break;
                        default:
                            ag = TipoAgregado.GRANITO;
                            break;
                    }
                    var mat = new Material(int.Parse(aux[0]), aux[1], double.Parse(aux[2]), ag);
                    concreteMaterial.Add(mat);
                    buffer = fileConcrete.ReadLine();
                  }

            }
            
        }
   
        public void             ReadRebarMaterialTable()
        {
            string buffer;
            StreamReader fileRebar = new StreamReader(AppInfo.appDataPath + @"\RebarMaterial.dat", false);
           
            buffer = fileRebar.ReadLine();
            buffer = fileRebar.ReadLine();
            if (buffer.CompareTo("#BEGIN") == 0)
            {
                buffer = fileRebar.ReadLine();
                while (buffer.CompareTo("#END") != 0)
                {
                    var aux = buffer.Split(';');
                    RebarMaterial rm = new RebarMaterial(aux[1], double.Parse(aux[2]));
                    rebarMaterial.Add(rm);
                    buffer = fileRebar.ReadLine();
                }
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

        public void             ReadRebarSectionTable()
        {
            
            string buffer;
            ReadRebarMaterialTable();
            
            StreamReader fileRebar = new StreamReader(AppInfo.appDataPath + @"\RebarSection.dat", false);

            buffer = fileRebar.ReadLine();
            buffer = fileRebar.ReadLine();
            if (buffer.CompareTo("#BEGIN") == 0)
            {
                buffer = fileRebar.ReadLine();
                while (buffer.CompareTo("#END") != 0)
                {
                    var aux = buffer.Split(';');
                    var fy = rebarMaterial.Where(c => c.Name == aux[3]).Select(c => c.Fy).SingleOrDefault();
                    Rebar rb = new Rebar(double.Parse(aux[0], CultureInfo.InvariantCulture),double.Parse(aux[1], CultureInfo.InvariantCulture),double.Parse(aux[2], CultureInfo.InvariantCulture),aux[3],fy); 
                    this.rebar.Add(rb);
                    buffer = fileRebar.ReadLine();
                }
            }

        }

        public void             DesignBeam(ref clsBeam beam)
        {

            beam.CalculateBeam();
            
          if (rebar.Count == 0) { ReadRebarSectionTable(); }

            double L = beam.Length;
          
            var coords = beam.getNodes().Select(c => c.GetCoord().x).ToList();

            Dictionary<double, double> IF_SLS = new Dictionary<double, double>(); // esforços para combinaçoes de serviço
            Dictionary<string, Dictionary<double, double>> Def_SLS = new Dictionary<string, Dictionary<double, double>>();     // deformaçoes para combinaçoes de serviço
            Dictionary<string, Dictionary<double, DsgResult>> results = new Dictionary<string, Dictionary<double, DsgResult>>();


            // GEt results for SLS combination
            var lc = (from c in beam.LCombination where c.cbType == combType.ULS select c).ToList();
            var lc_SLS = (from c in beam.LCombination where c.cbType == combType.SLS select c).ToList();

            // pegar esforços para verificaçoes SLS
            foreach (var lcase in lc_SLS)
            {
                if (lcase.name.Contains("FREQ"))
                {
                    
                    foreach( var li in coords)
                    {
                        if (!IF_SLS.ContainsKey(li))
                        {
                            IF_SLS.Add(li, beam.getInternalForces(lcase, li).Mx);
                        }
                        else
                        {
                            var aux = beam.getInternalForces(lcase, li).Mx;
                            IF_SLS[li] = IF_SLS[li] > aux ? IF_SLS[li] : beam.getInternalForces(lcase, li).Mx;

                        }

                        
                    }

                }
            }
            // pegar deslocamentos para verificaçao SLS   
            foreach (var lcase in lc_SLS)
            {
                
                foreach ( var li in coords)
                {
                    Dictionary<double, double> aux = new Dictionary<double, double>();
                    var teste = beam.getDisplacements(lcase, li);
                    aux.Add(li, beam.getDisplacements(lcase, li));
                    if (!Def_SLS.ContainsKey(lcase.name))
                    {

                        Def_SLS.Add(lcase.name, aux);
                    }
                    else
                    {
                        Def_SLS[lcase.name].Add(li, beam.getDisplacements(lcase, li));

                    }
                    
                }
            }

            // check for ULS combination
            foreach (var lcase in lc)
            {
                Dictionary<double, DsgResult> aux = new Dictionary<double, DsgResult>();
                

               foreach ( var li in coords)
                {

                    // pega esforços para verificacao dos ELU
                    var iF = beam.getInternalForces(lcase, li);

                    // pega o momento para verificaçao do SLS para a mesma posicao da viga
                    //double Mx = (from f in IF_SLS where f.Key == li select f.Value).SingleOrDefault();
                    double Mx = (from c in IF_SLS where c.Key == li select c.Value).SingleOrDefault();

                    // pega a flecha para cada combinaçao SLS no ponto li
                    Dictionary<string, double> Def = new Dictionary<string, double>();

                    foreach (var d in Def_SLS)
                    {
                        string aux1 = d.Key;
                        double aux2 = d.Value.Where(x => x.Key == li).Select(x => x.Value).SingleOrDefault();
                        Def.Add(aux1, aux2);

                    }


                    NBR6118 des = new NBR6118(beam.CS, iF, 2, this.rebar, Mx, beam.CS.material.E, Def, beam.vaos, li); ;
                    aux.Add(li, des.StartDegsign());

                    
                }
                results.Add(lcase.name, aux);
            }
            beam.results = results;
            printDesignResults(beam.Name, beam.results);
            
           
        }
    
           

        

    }
}
