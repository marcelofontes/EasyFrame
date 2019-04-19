using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Beam;
using DATAACCESS;
using FEM;
using WeifenLuo.WinFormsUI.Docking;
using MainWin;
using System.IO;
using NBR8800;



namespace MainWin
{
    public partial class FViga : DockContent
    {

        private static List<float> Lbtop;
        private static List<float> Lbbottom;    
        private static List<Load>  loads;     // lista de cargas
        List<float>    v;                              // lista de vaos
        double      Length;
        string      name;
        string      table;
        string      profile;
        string      steel;
        

        public FViga()
        {
            InitializeComponent();
        }

        private void FViga_Load                         (object sender, EventArgs e)
        {

            this.gridVao.RowCount = 1;
            this.gridVao.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
            this.gridCC.Rows[0].Cells[0].Value = this.gridCC.RowCount;
            
            // preenche a combo com os nomes dos perfis
            this.cbTabela.SelectedIndex = 7;
            string tb = cbTabela.Text;
            preencheComboPerfil(tb);
            preencheComboMaterial();
            preencheGridCCcbList();

        }

        private void btnAtualizar_Click                 (object sender, EventArgs e)
        {
            if(validaDados())
            {
                
            }

        }

        private void dwgPanel1_Paint_1                  (object sender, PaintEventArgs e)
        {
            //PointF p1 = new PointF(50, 50);
            //PointF p2 = new PointF(1000, 50);
            //this.dwgPanel1.drawBeam(p1, p2);
            
        }

        private void dwgView_Paint                      (object sender, PaintEventArgs e)
        {
            
            //PointF p1 = new PointF(0, 50);
            //PointF p2 = new PointF(13.75f, 50);
            //this.dwgView.drawBeam(p1, p2);
        }

        private void preencheComboPerfil                (string table)
        {
            cbPerfil.DataSource = null;
            switch (table)
            {
                case "C":
                    this.cbPerfil.DisplayMember = "nome";
                    this.cbPerfil.DataSource = new PerfilC().getCSTable();
                    break;
                case "CS":
                    this.cbPerfil.DisplayMember = "nome";
                    this.cbPerfil.DataSource = new PerfilCS().getCSTable();
                    break;
                case "CVS":
                    this.cbPerfil.DisplayMember = "nome";
                    this.cbPerfil.DataSource = new PerfilCVS().getCSTable();
                    break;
                case "VS":
                    this.cbPerfil.DisplayMember = "nome";
                    this.cbPerfil.DataSource = new PerfilVS().getCSTable();
                    break;
                case "VSM":
                    this.cbPerfil.DisplayMember = "nome";
                    this.cbPerfil.DataSource = new PerfilVSM().getCSTable();
                    break;
                case "W":
                    this.cbPerfil.DisplayMember = "nome";
                    this.cbPerfil.DataSource = new PerfilW().getCSTable();
                    break;
                case "PS":
                    this.cbPerfil.DisplayMember = "nome";
                    this.cbPerfil.DataSource = new PerfilPS().getCSTable();
                    break;
                case "PSa":
                    this.cbPerfil.DisplayMember = "nome";
                    this.cbPerfil.DataSource = new PerfilPSa().getCSTable();
                    break;
            }
        }

        private void preencheComboMaterial()
        {
            cbAco.DataSource = null;
            cbAco.DisplayMember = "name";
            cbAco.DataSource = new Materials().getMaterialTable();

        }

        private void cbTabela_SelectedIndexChanged      (object sender, EventArgs e)
        {
            preencheComboPerfil(cbTabela.Text);
        }

        private void gridLb_CellValueChanged            (object sender, DataGridViewCellEventArgs e)
        {
            int nr = gridLb.RowCount;
           
            for ( int i = 0; i < nr; i++)
            {
                gridLb.Rows[i].Cells[0].Value = i+1;
            }
           
        }

        private void gridCC_CellValueChanged            (object sender, DataGridViewCellEventArgs e)
        {
            int nr = gridCC.RowCount;

            for (int i = 0; i < nr; i++)
            {
                gridCC.Rows[i].Cells[0].Value = i + 1;
            }

        }

        private void gridVao_CellValueChanged           (object sender, DataGridViewCellEventArgs e)
        {
            int nr = gridVao.RowCount;

            for (int i = 0; i < nr; i++)
            {
                gridVao.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private bool validaDados()
        {
            int n = gridVao.RowCount - 1;

            List<PointF> PL = new List<PointF>();
            v = new List<float>();
            Lbtop = new List<float>();
            Lbbottom = new List<float>();
            loads = new List<Load>();

            //Lbtop.Clear();
            //Lbbottom.Clear();
            //loads.Clear();
            //v.Clear();

            try
            {
                // faz a leitura dos dados geometricos da viga
                #region geometria
                double aux;
                if (n <= 0)
                {
                    throw new IndexOutOfRangeException("O número de vãos deve ser maior que 0");
                }

                for (int i = 0; i < n; i++)
                {
                    if (this.gridVao.Rows[i].Cells[1].Value == null || !double.TryParse(gridVao.Rows[i].Cells[1].Value.ToString(), out aux)
                        || double.Parse(gridVao.Rows[i].Cells[1].Value.ToString().Replace(",", ".")) <= 0)
                    {
                        throw new IndexOutOfRangeException("Tabela de vãos nao preenchida corretamente! linha " + (i + 1).ToString());
                    }
                }
                if (txtnomeviga.Text == "")
                {
                    throw new IndexOutOfRangeException("Preencha o nome da viga!");
                }
                else { name = txtnomeviga.Text; }

                for (int i = 0; i < n; i++)
                {
                    //v[i] = float.Parse(gridVao.Rows[i].Cells[1].Value.ToString());
                    v.Add(float.Parse(gridVao.Rows[i].Cells[1].Value.ToString()));
                }

                PointF p = new PointF(0, 0);
                PL.Add(p);


                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        PointF p1 = new PointF(v[i], 0);
                        PL.Add(p1);
                    }
                    else
                    {
                        PointF p1 = new PointF(v[i] + PL.Last().X, 0);
                        PL.Add(p1);
                    }
                }
                this.Length = PL.Last().X;
                #endregion

                // faz a leitura dos carregamentos
                #region Carregamentos

                // faz a leitura das cargas distribuidas
                if(string.IsNullOrEmpty(txt_CP.Text)
                    || string.IsNullOrEmpty(txt_SCC.Text)
                    || string.IsNullOrEmpty(txt_SCP.Text)
                    || string.IsNullOrEmpty(txt_V.Text)
                    || !double.TryParse(txt_CP.Text, out aux)
                    || !double.TryParse(txt_SCC.Text, out aux)
                    || !double.TryParse(txt_SCP.Text, out aux)
                    || !double.TryParse(txt_V.Text, out aux)
                    )
                {
                    throw new IndexOutOfRangeException("Valores incorretos para cargas distribuídas.");
                }
                else
                {
                    Load l1 = new MainWin.Load(1, "Carga Permanente",       float.Parse(txt_CP.Text),   "Carga Permanente");
                    Load l2 = new MainWin.Load(2, "Sobrecarga de Cobertura",float.Parse(txt_SCC.Text),  "Sobrecarga de Cobertura");
                    Load l3 = new MainWin.Load(3, "Sobrecarga de Piso",     float.Parse(txt_SCP.Text),  "Sobrecarga de Piso");
                    Load l4 = new MainWin.Load(4, "Vento",                  float.Parse(txt_V.Text),    "Vento");

                    loads.Add(l1);
                    loads.Add(l2);
                    loads.Add(l3);
                    loads.Add(l4);

                }

                int j = gridCC.RowCount - 1;
                for (int i = 0; i < j; i++)
                {
                    PointF pt = new PointF();

                    if (  !double.TryParse(gridCC.Rows[i].Cells[3].Value.ToString().Replace(",", "."), out aux)
                        || double.Parse(gridCC.Rows[i].Cells[3].Value.ToString()) < 0
                        || double.Parse(gridCC.Rows[i].Cells[3].Value.ToString()) > Length
                        || !double.TryParse(gridCC.Rows[i].Cells[4].Value.ToString().Replace(",", "."), out aux)
                        || double.Parse(gridCC.Rows[i].Cells[4].Value.ToString().Replace(",", ".")) == 0
                        || string.IsNullOrEmpty((string)gridCC.Rows[i].Cells[4].Value)
                        || string.IsNullOrEmpty((string)gridCC.Rows[i].Cells[2].Value))
                    {
                        throw new Exception("Dados incorretos de carregamento na linha " + (i + 1).ToString());
                    }
                    else
                    {
                        pt.X = float.Parse(gridCC.Rows[i].Cells[3].Value.ToString());
                        pt.Y = 0;
                        //float vl    = float.Parse(gridCC.Rows[i].Cells[4].Value.ToString());

                        // faz a leitura das cargas concentradas
                        string desc = gridCC.Rows[i].Cells[1].Value.ToString();
                        string tl   = gridCC.Rows[i].Cells[2].Value.ToString();
                        double pos  = double.Parse(gridCC.Rows[i].Cells[3].Value.ToString());
                        double vlr  = double.Parse(gridCC.Rows[i].Cells[4].Value.ToString());
                        
                        Load ld = new Load(i+5,desc,pos,vlr,tl);
                        loads.Add(ld);
                    }
                }

                #endregion

                // faz a leitura dos travamentos
                #region Travamento

                int m = gridLb.RowCount - 1;
                float test;

                for (int i = 0; i < m; i++)
                {
                    if (!float.TryParse((string)this.gridLb.Rows[i].Cells[1].Value, out test))
                    {
                        throw new IndexOutOfRangeException(" Lb - Digite um valor válido para a Posição x");
                    }
                    if (float.Parse(this.gridLb.Rows[i].Cells[1].Value.ToString()) > this.Length)
                    {
                        throw new IndexOutOfRangeException(" Lb - A Posição x deve ser menor que o comprimento total da viga");
                    }
                    else if (string.IsNullOrEmpty((string)this.gridLb.Rows[i].Cells[1].Value) || float.Parse(this.gridLb.Rows[i].Cells[1].Value.ToString()) < 0)
                    {
                        throw new IndexOutOfRangeException(" Lb - Digite um valor válido para a Posição x");
                    }
                    else if (float.Parse(this.gridLb.Rows[i].Cells[1].Value.ToString()) > 0 && float.Parse(this.gridLb.Rows[i].Cells[1].Value.ToString()) <= this.Length)
                    {
                        if (Convert.ToBoolean(this.gridLb.Rows[i].Cells[2].Value))
                        {
                            Lbtop.Add(float.Parse(this.gridLb.Rows[i].Cells[1].Value.ToString()));
                        }
                        if (Convert.ToBoolean(this.gridLb.Rows[i].Cells[3].Value))
                        {
                            Lbbottom.Add(float.Parse(this.gridLb.Rows[i].Cells[1].Value.ToString()));
                        }
                    }
                }
                #endregion

                #region informações de perfil e aço
                if (string.IsNullOrEmpty(cbTabela.Text) || string.IsNullOrEmpty(cbPerfil.Text)|| string.IsNullOrEmpty(cbAco.Text))
                {
                    throw new Exception("Verifique os dados do perfil e do tipo de aço.");
                }
                #endregion
                else
                {
                    table   = cbTabela.Text;
                    profile = cbPerfil.Text;
                    steel   = cbAco.Text;
                }

                // para evitar que o metodo drawbeam altere o valor das variaveis
                float[] a = new float[Lbtop.Count];
                Lbtop.CopyTo(a);
                List<float> top = a.ToList();

                float[] b = new float[Lbbottom.Count];
                Lbbottom.CopyTo(b);
                List<float> bot = b.ToList(); ;
               
                this.dwgView.drawBeam(PL, top, bot);
                return true;
            }

            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Preenchimento incorreto da tabela de cargas!\n" + ex.Message);
                return false;
            }
        }

        private void btnGravar_Click                    (object sender, EventArgs e)
        {
            if (validaDados())
            {
                clsIOManager io = new clsIOManager();
                io.createBeamInputFile(name, v, Lbtop, Lbbottom, loads, table, profile, steel);
            }
        }

        private void preencheGridCCcbList()
        {
            List<string> lcnames = new List<string>();
            foreach(var lc in DesignConfigs.LoadCases)
            {
                lcnames.Add(lc.Name);

            }
            lcnames.Remove("Peso Proprio");
            this.gridCC_TipoCarga.DataSource = lcnames;
        }

        private void btnCalcular_Click                  (object sender, EventArgs e)
        {
            try
            {

            if (validaDados())
            {
                clsIOManager io = new clsIOManager();
                io.createBeamInputFile(name, v, Lbtop, Lbbottom, loads, table, profile, steel);
                clsBeam b = io.readBeamInputFile(txtnomeviga.Text + ".cdv");
                b.CalculateBeam();

                double L = b.Length;
                double step = L / 108;
                double li = 0;
                double cb;
                double Lb=0;
                Dictionary<string,Dictionary<double, DsgResult>> results = new Dictionary<string, Dictionary<double, DsgResult>>();
                

                // check for ULS combination
                var lc = (from c in b.LCombination where c.cbType==combType.ULS select c).ToList();
                foreach(var lcase in lc)
                {
                    Dictionary<double, DsgResult> aux = new Dictionary<double, DsgResult>();
                    li = 0;
                    Lb = 0;
                    while (li <= L)
                    {
                        cb = b.calculateCb(li, lcase, ref Lb);
                        var iF = b.getInternalForces(lcase, li);
                        NBR8800Dsgn des = new NBR8800Dsgn(b.CS, iF, 0, cb, Lb, 0, 0, 0);
                        aux.Add(li,des.startDesign());

                        li += step;
                    }
                    results.Add(lcase.name, aux);
                }
                io.printDesignResults(this.txtnomeviga.Text, results);

                System.Windows.Forms.MessageBox.Show("Cálculo concluído com sucesso!");
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     /// <summary>
     /// preenche a tela de vigas
     /// </summary>
     /// <param name="beam">ClsBeam elemento to be filled in the screen</param>
     /// <returns></returns>
        public bool  FillScreen                         (clsBeam beam)
        {
            this.txtnomeviga.Text = beam.Name;
            int i = 0;
            // preenche tabela de vaos
           foreach( double v in beam.vaos)
            {
                gridVao.RowCount += 1;
                gridVao.Rows[i].Cells[1].Value = v.ToString();
                i++;
            }

            var ld = (from a in beam.Loads where a.lType == LoadType.D select a).ToList();
            // preenche campos de carga distribuida
           foreach (var l in ld)
            {
                switch (l.name)
                {
                    case "Carga Permanente":
                        txt_CP.Text = l.Py.ToString();
                        break;
                    case "Sobrecarga de Cobertura":
                        txt_SCC.Text = l.Py.ToString();
                        break;
                    case "Sobrecarga de Piso":
                        txt_SCP.Text = l.Py.ToString();
                        break;
                    case "Vento":
                        txt_V.Text = l.Py.ToString();
                        break;
                }
            }
            ld.Clear();
            ld = (beam.Loads.Where(a => a.lType == LoadType.P)).ToList();
            i = 0;
            //preenche tabela de cargas concentradas
            foreach(var l in ld)
            {
                gridCC.RowCount += 1;
                gridCC.Rows[i].Cells[1].Value = l.name;
                gridCC.Rows[i].Cells[2].Value = l.LoadCase.Name;
                gridCC.Rows[i].Cells[3].Value = l.a.ToString();
                gridCC.Rows[i].Cells[4].Value = l.Py.ToString();
                i++;
            }

            //preenche informações do perfil
            cbTabela.Text = beam.CS.table;
            cbAco.Text = beam.CS.material.Name;
            cbPerfil.Text = beam.CS.Name;

            // preenche tabela de travamentos
            Dictionary<double, string> lb = new Dictionary<double, string>();
            foreach(var l in beam.toplateralBracing)
            {
                if (!lb.ContainsKey(l))
                {
                    lb.Add(l, "Top");
                }
            }

            foreach(var l in beam.bottomlateralBracing)
            {
                if (lb.ContainsKey(l))
                {
                    lb[l] = "both";
                }
                else
                {
                    lb.Add(l, "bottom");
                }
            }
            i = 0;

            double pos = 0;
            lb.Remove(0);
            foreach ( var v in beam.vaos)
            {
                pos += v;
                if (lb.ContainsKey(pos))
                {
                    lb.Remove(pos);
                }
            }
            var lb1 = lb.OrderBy(c => c.Key).ToList();
            foreach(var l in lb1)
            {
                gridLb.RowCount += 1;
                if (l.Value.CompareTo("Top") == 0)
                {
                    gridLb.Rows[i].Cells[1].Value = l.Key.ToString();
                    gridLb.Rows[i].Cells[2].Value = true;
                }
                else if(l.Value.CompareTo("both") == 0)
                {
                    gridLb.Rows[i].Cells[1].Value = l.Key.ToString();
                    gridLb.Rows[i].Cells[2].Value = true;
                    gridLb.Rows[i].Cells[3].Value = true;
                }
                else if (l.Value.CompareTo("bottom") == 0)
                {
                    gridLb.Rows[i].Cells[1].Value = l.Key.ToString();
                    gridLb.Rows[i].Cells[3].Value = true;
                }

                i++;
            }
            validaDados();
            return true;
        }

        private void btnFechar_Click                    (object sender, EventArgs e)
        {
            this.Close();
        }

        private void FViga_FormClosed                   (object sender, FormClosedEventArgs e)
        {
            StreamReader fl = new StreamReader(ProjectInfo.projectPath + @"\Beams\" + this.Text + ".cdv", false);
            using (fl)
            {
                if (fl.ReadLine() == null)
                {
                    fl.Close();
                    File.Delete(ProjectInfo.projectPath + @"\Beams\" + this.Text + ".cdb");
                    clsIOManager io = new clsIOManager();
                    io.removeBeamFromProject(this.Text);
                    var a = Application.OpenForms.OfType<TreeForm>().ToList();
                    a.First().removeBeamChildNode(this.Text);
                    
                }
            }
        }
    }
}
