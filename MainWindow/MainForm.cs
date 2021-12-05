using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2015;
using System.IO;
using Microsoft.VisualBasic;
using MainWin;
using FEM;
using Beam;


namespace MainWin
{

    public partial class MainForm : DockContent
    {
        private int childFormNumber = 0;
        private TreeForm treeform = new TreeForm();
        private List<string> ListaVigas;


        public MainForm()
        {
            InitializeComponent();
            treeform.Show(dockPanel1, DockState.DockLeft);
            treeform.CloseButton = false;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            if (CreateProject())
            {
                this.itemToolStripMenuItem.Enabled = true;
                //  this.elementoToolStripMenuItem.Enabled = true;
            }
        }
        /// <summary>
        /// abre um arquivo de projeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.cdp)|*.cdp|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                OpenProject(FileName);
            }
            this.itemToolStripMenuItem.Enabled = true;
           // this.elementoToolStripMenuItem.Enabled = true;
            this.toolStripButton2.Enabled = true;
            this.btn_CalcularTodos.Enabled = true;
            this.saveToolStripButton.Enabled = true;

            atualizaStatusStrip();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Selecione o Local para criar o projeto";

            if (fb.ShowDialog() == DialogResult.OK)
            {
                clsIOManager io = new clsIOManager();
                io.SaveProjectAs(ProjectInfo.projectPath, fb.SelectedPath);
      
                this.btn_CalcularTodos.Enabled = false;
               
                OpenProject(ProjectInfo.projectPath+"\\Projeto.CDP");
            }
            this.itemToolStripMenuItem.Enabled = true;
           // this.elementoToolStripMenuItem.Enabled = true;
            this.toolStripButton2.Enabled = true;
            this.btn_CalcularTodos.Enabled = true;
            this.saveToolStripButton.Enabled = true;

            
            atualizaStatusStrip();
             


            
        }

          private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.treeViewToolStripMenuItem.Checked = true;
            itemToolStripMenuItem.Enabled = false;
            //elementoToolStripMenuItem.Enabled = false;
            this.saveToolStripButton.Enabled = false;

            dockPanel1.DockLeftPortion = 250;

            atualizaStatusStrip();
            loadDesignConfigs();
            LoadAppInfo();
        }
        /// <summary>
        ///  botao que aciona a criaçao de novo projeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void projetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateProject())
            {
                this.itemToolStripMenuItem.Enabled = true;
              //  this.elementoToolStripMenuItem.Enabled = true;
            }
        }

        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeform.IsActivated)
            {
                this.treeform.Hide();
                this.treeViewToolStripMenuItem.Checked = false;
            }
            else
            {
                this.treeform.Show();
                this.treeViewToolStripMenuItem.Checked = true;
            }


        }
        /// <summary>
        /// cria novo projeto
        /// </summary>
        /// <returns></returns>
        private bool CreateProject()
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Selecione o Local para criar o projeto";

            if (fb.ShowDialog() == DialogResult.OK)
            {
                ProjectInfo.projectFileName = "Projeto.CDP";
                ProjectInfo.projectPath = fb.SelectedPath;
                ProjectInfo.projectDescription = Interaction.InputBox("Descrição do projeto", "Informações do projeto", "Projeto 1", -1, -1);
                StreamWriter sw = new StreamWriter(ProjectInfo.projectPath + @"\Projeto.CDP", false);
                using (sw)
                {
                    sw.WriteLine("[DESCRIPTION]");
                    sw.WriteLine(ProjectInfo.projectDescription);
                    sw.WriteLine("[END_DESCRIPTION]");
                    sw.WriteLine("[BEAMS]");
                    sw.WriteLine("[END_BEAMS]");
                    sw.WriteLine("[ELEMENTS]");
                    sw.WriteLine("[END_ELEMENTS]");
                    sw.Close();
                }
                if (Directory.Exists(ProjectInfo.projectPath))
                {
                    Directory.CreateDirectory(ProjectInfo.projectPath + @"\Beams");
                    Directory.CreateDirectory(ProjectInfo.projectPath + @"\Elements");
                }
                else
                {
                    MessageBox.Show("Pasta do projeto não existe");
                }
                this.btn_CalcularTodos.Enabled = false;
                clearTreeForm();
                atualizaStatusStrip();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// cria nova viga no projeto
        /// </summary>
        private void CreateNewBeam()
        {

            string beamName = Interaction.InputBox("Nome da Viga", "Nome da Viga", "VigaXX", -1, -1);
            TreeNode node = this.treeform.treeView1.Nodes[0];

            // verifica se o nome nao foi vazio
            if (beamName.CompareTo("") != 0)
            {
                int n = int.Parse(node.GetNodeCount(true).ToString());
                List<string> names = new List<string>();

                // pega a lista de nomes das vigas
                for (int i = 0; i < n; i++)
                {
                    names.Add(node.Nodes[i].Text);
                }

                // verifica se o nome digitado está na lista
                var res = (from a in names where a == beamName select a).SingleOrDefault();

                if (res != null)
                {
                    MessageBox.Show("já existe uma viga com este nome!");
                }

                // se nao existe, acrescenta na treeview
                else
                {

                    FViga fv = new FViga();
                    fv.txtnomeviga.Text = beamName;
                    fv.Text = beamName;
                    fv.Show(dockPanel1, DockState.Document);

                    this.treeform.insertChildBeamNode(beamName);
                    try
                    {
                        clsIOManager io = new clsIOManager();
                        if (!io.InsertBeamOnProject(beamName))
                        {
                            throw new Exception("Erro ao gravar projeto!");
                        }
                        else
                        {
                            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\" + beamName + ".cdv", false);
                            fl.Close();
                        }
                        this.btn_CalcularTodos.Enabled = true;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("\n" + ex.Message);
                    }

                }
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void cadastroDeMateriaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// atualiza caminho na barra de status
        /// </summary>
        private void atualizaStatusStrip()
        {
            toolStripStatusLabel.Text = ProjectInfo.projectPath + ProjectInfo.projectFileName;
        }

        /// <summary>
        /// carrega as configurações de carregamento: LoadCases e LoadClasses
        /// </summary>
        private void loadDesignConfigs()
        {

            clsLoadClass lc1 = new clsLoadClass(1, "PP", 1.25, 1.0, 1.0, 1.0, false);
            clsLoadClass lc2 = new clsLoadClass(2, "CP", 1.25, 1.0, 1.0, 1.0, false);
            clsLoadClass lc3 = new clsLoadClass(3, "SCC", 1.50, 0.8, 0.7, 0.6, true);
            clsLoadClass lc4 = new clsLoadClass(4, "SCP", 1.50, 0.7, 0.6, 0.4, true);
            clsLoadClass lc5 = new clsLoadClass(5, "V", 1.40, 0.6, 0.3, 0.0, true);

            DesignConfigs.LoadClasses = new List<clsLoadClass>();
            DesignConfigs.LoadCases = new List<clsLoadCase>();

            DesignConfigs.LoadClasses.Add(lc1);
            DesignConfigs.LoadClasses.Add(lc2);
            DesignConfigs.LoadClasses.Add(lc3);
            DesignConfigs.LoadClasses.Add(lc4);
            DesignConfigs.LoadClasses.Add(lc5);

            clsLoadCase lcs1 = new clsLoadCase(1, "Peso Proprio", lc1);
            clsLoadCase lcs2 = new clsLoadCase(2, "Carga Permanente", lc2);
            clsLoadCase lcs3 = new clsLoadCase(3, "Sobrecarga de Cobertura", lc3);
            clsLoadCase lcs4 = new clsLoadCase(4, "Sobrecarga de Piso", lc4);
            clsLoadCase lcs5 = new clsLoadCase(5, "Vento", lc5);

            DesignConfigs.LoadCases.Add(lcs1);
            DesignConfigs.LoadCases.Add(lcs2);
            DesignConfigs.LoadCases.Add(lcs3);
            DesignConfigs.LoadCases.Add(lcs4);
            DesignConfigs.LoadCases.Add(lcs5);

            DesignConfigs.upliftDeflectionLimit = 180;
            DesignConfigs.gravityDeflectionLimit = 350;

        }

        private void LoadAppInfo()
        {
            AppInfo.appPath = Directory.GetCurrentDirectory();
            AppInfo.appDataPath = AppInfo.appPath + @"\Data\";
            AppInfo.appPath = AppInfo.appPath + @"\img\";
        }

        /// <summary>
        /// icone barra de ferramentas - cria nova viga no projeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

          
            try
            {
                if (ProjectInfo.projectFileName == null)
                {
                    throw new Exception ("Você deve criar um Projeto antes de inserir uma viga!");
                }
                else { CreateNewBeam(); }
            }
           catch ( Exception ex)
            {
                MessageBox.Show("\n" + ex.Message);
            }
            
        }

        /// <summary>
        /// open project and load items to the GUI
        /// </summary>
        /// <param name="PrjName"></param>
        private void OpenProject(string PrjName)
        {
            ProjectInfo.projectFileName = "Projeto.CDP";
            ProjectInfo.projectPath = PrjName.Remove(PrjName.IndexOf(ProjectInfo.projectFileName)-1);
            StreamReader fl = new StreamReader(PrjName, false);
            //List<string> file = new List<string>();

            clearTreeForm();

            clsIOManager io = new clsIOManager();
            this.ListaVigas = io.readProjectFile(PrjName);
            foreach( var f in ListaVigas)
            {
                this.treeform.insertChildBeamNode(f);
            }
            this.toolStripButton2.Enabled = true;

            fl.Close();
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {
           // this.toolStripButton2.Enabled=false;
           // this.btn_CalcularTodos.Enabled = false;
        }

        private void toolStrip_ItemClicked(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// dimensiona, de uma vez, todas as vigas do projeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            clsIOManager io = new clsIOManager();
            List<clsBeam> ListaVigas = new List<clsBeam>();
            try
            {
                List<string> listaArquivoVigas = io.readProjectFile(ProjectInfo.projectPath +"\\"+ ProjectInfo.projectFileName);



                foreach (var b in listaArquivoVigas)
                {
                    ListaVigas.Add(io.readBeamInputFile(b + ".CDV"));
                }

                foreach (var beam in ListaVigas)
                {
                    var b = beam;
                    io.DesignBeam(ref b);
                    b.GeraDetalhamento();
                }
                BOM Bom = new BOM(ListaVigas,"BOM_GERAL.TXT","RESUMO_MATERIAIS.TXT");
                MessageBox.Show("Dimensionamento concluído");
                var RD = this.CreateReportDialog("Relatório Por Viga", "Resumo de Materiais do Projeto", "GERAL");
                RD.ShowDialog();
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("\n" + ex.Message);//"Não existe nenhuma viga no Projeto!"
                this.btn_CalcularTodos.Enabled = true;

            }
        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {

        }

        private void viewMenu_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fecharProjetoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void clearTreeForm()
        {
            if (ListaVigas != null)
            {

           
            foreach (var viga in ListaVigas)
            {
                if (viga != null)
                {
                    treeform.removeBeamChildNode(viga);
                }
            }
            }
        }

        private ReportOptionDialog CreateReportDialog(string _TipoRelatório1, string _TipoRelatorio2, string _Caso)
        {
            ReportOptionDialog RD = new ReportOptionDialog(_TipoRelatório1,_TipoRelatorio2, _Caso);


            return RD;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
       
    }
}
