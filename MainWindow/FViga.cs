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

using FEM;
using WeifenLuo.WinFormsUI.Docking;
using MainWin;
using System.IO;
using NBR6118_2014;




namespace MainWin
{
    public partial class FViga : DockContent
    {

   
        private static List<Load>  loads;     // lista de cargas
        List<float>    v;                     // lista de vaos
        double      Length;
        string      name;
        string      profile;
        string      concrete;
        double b;
        double h;
        double c;
        string rebar;
       
        

        public FViga()
        {
            InitializeComponent();
        }

        private void FViga_Load                         (object sender, EventArgs e)
        {

            this.gridVao.RowCount = 1;
            this.gridVao.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
            this.gridCC.Rows[0].Cells[0].Value = this.gridCC.RowCount;
            this.btn_relatorio.Enabled = false; 
            
            preencheGridCCcbList();
            loadMaterialList();

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
                
                // faz a leitura das características da viga e do concreto
                if(  string.IsNullOrEmpty(txt_b.Text)
                    || string.IsNullOrEmpty(txt_h.Text)
                    || string.IsNullOrEmpty(txt_c.Text)
                    || !double.TryParse(txt_b.Text, out aux)
                    || !double.TryParse(txt_h.Text, out aux)
                    || !double.TryParse(txt_c.Text, out aux)
                    )
                {
                    throw new IndexOutOfRangeException("As dimensões da seçao precisam ser valores numéricos.");
                }
                else
                {
                    this.b = double.Parse(txt_b.Text);
                    this.h = double.Parse(txt_h.Text);
                    this.c = double.Parse(txt_c.Text);
                    
                }
                if(string.IsNullOrEmpty(txt_nome_secao.Text) || string.IsNullOrEmpty(CbConcreto.Text))
                {
                    throw new IndexOutOfRangeException("Os valores dos campos nome e concreto nao podem ser vazios.");
                }
                else
                {
                    this.profile = txt_nome_secao.Text;
                    this.concrete = CbConcreto.Text;

                }
                // para evitar que o metodo drawbeam altere o valor das variaveis
          
                
                this.dwgView.drawBeam(PL);
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
                io.createBeamInputFile(name, v, loads, profile, concrete,b,h,c);
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
                    io.createBeamInputFile(name, v,  loads, profile, concrete,this.b,h,c);
                    clsBeam b = io.readBeamInputFile(txtnomeviga.Text + ".cdv");
                        io.DesignBeam(ref b);
                        b.GeraDetalhamento();
                    
                    List<clsBeam> ListaVigas = new List<clsBeam>();
                    ListaVigas.Add(b);
                    BOM Bom = new BOM(ListaVigas, "BOM_Detalhado_" + b.Name + ".txt", "BOM_Resumo_" + b.Name + ".txt");
                    ReportOptionDialog RD = new ReportOptionDialog("Resumo de Materiais da viga", "Relatório de Cáculo da viga", "VIGA",b.Name);
                    MessageBox.Show("Dimesnionamento Concluído");
                    RD.ShowDialog();
                }
                this.btn_relatorio.Enabled = true;
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
                        txt_CP.Text = (-1*l.Py).ToString();
                        break;
                    case "Sobrecarga de Cobertura":
                        txt_SCC.Text = (-1*l.Py).ToString();
                        break;
                    case "Sobrecarga de Piso":
                        txt_SCP.Text = (-1* l.Py).ToString();
                        break;
                    case "Vento":
                        txt_V.Text = (-1*l.Py).ToString();
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
                gridCC.Rows[i].Cells[4].Value = (-1*l.Py).ToString();
                i++;
            }

            //preenche informações do perfil
            // TODO - AVALIAR AS 3 LINHAS ABAIXO
            this.txt_b.Text = beam.CS.b.ToString();
            this.txt_h.Text = beam.CS.h.ToString();
            this.txt_c.Text = beam.CS.cover.ToString();
            this.txt_nome_secao.Text = beam.CS.Name;
            this.CbConcreto.Text = beam.CS.material.Name;
           // cbTabela.Text = beam.CS.table;
            //cbAco.Text = beam.CS.material.Name;
            //cbPerfil.Text = beam.CS.Name;

            // preenche tabela de travamentos
         

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

        private void loadMaterialList()
        {
            clsIOManager io = new clsIOManager();
            io.ReadMaterialTable();
            List<string> matnames = new List<string>();

            foreach( var m in io.concreteMaterial)
            {
                matnames.Add(m.Name);
            }
            this.CbConcreto.DataSource = matnames;
    

        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
           
                string NomeViga = this.txtnomeviga.Text;
                ReportOptionDialog RD = new ReportOptionDialog("Resumo de materiais da viga", "Relatório de cálculo da viga", "VIGA", NomeViga);
                RD.ShowDialog();                         


        }

        private void txt_CP_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void txt_SCC_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void txt_SCP_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void txt_V_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void gridCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridCC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void gridVao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void txt_nome_secao_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void txt_b_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void txt_h_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void txt_c_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void CbConcreto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }

        private void txtnomeviga_TextChanged(object sender, EventArgs e)
        {
            this.btn_relatorio.Enabled = false;
        }
    }
}

