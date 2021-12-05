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
using System.IO;
using Beam;

namespace MainWin
{
    public partial class TreeForm : DockContent
    {
        private string appPath;
        public TreeNode nodeBeam ;
        //public TreeNode nodeElement;
        public ImageList il = new ImageList();

        public TreeForm()
        {
            InitializeComponent();
            this.appPath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
        }

        private void TreeForm_Load                  (object sender, EventArgs e)
        {
            CarregaArvare(); 
           
        }

        private void treeView1_NodeMouseClick       (object sender, TreeNodeMouseClickEventArgs e)
        {
           
            if (e.Button == MouseButtons.Right)
            {
                popupMenu.Items.Clear();
                
                if (this.treeView1.SelectedNode.Level == 0)
                {
                    if (e.Node.Text == "Vigas")
                    {
                        popupMenu.Items.Add("Nova Viga");
                    }
                    else if (e.Node.Text == "Elementos")
                    {
                        popupMenu.Items.Add("Novo Elemento");
                    }
                }
                else
                {
                    popupMenu.Items.Add("Copiar");
                    popupMenu.Items.Add("Apagar");
                }
               
                popupMenu.Show(this.PointToScreen( new Point(e.X,e.Y)));
                
            }
        }

        private void CreateContextMenu              (string item)
        {

        }

        private void popupMenu_ItemClicked          (object sender, ToolStripItemClickedEventArgs e)
        {
            // MessageBox.Show(e.ClickedItem.Text + "-" + this.treeView1.SelectedNode.Text);
            int i = this.nodeBeam.Nodes.Count;
            string UltimaViga = this.nodeBeam.Nodes[i-1].Text;

            if (e.ClickedItem.Text == "Copiar")
            {
                
                InputForm InpForm = new InputForm(this.treeView1.SelectedNode.Text,UltimaViga);
                
                
                InpForm.ShowDialog();
                string NovaViga = InpForm.NomeNovaViga;
                this.insertChildBeamNode(NovaViga);
               
            }
            if (e.ClickedItem.Text == "Apagar")
            {
                clsIOManager io = new clsIOManager();
                string Viga = this.treeView1.SelectedNode.Text;
                if (MessageBox.Show("Apagar Viga?", "Apagar Viga", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    io.removeBeamFromProject(Viga);
                    this.removeBeamChildNode(Viga);
                }
            }
               

        }

        private void treeView1_AfterSelect          (object sender, TreeViewEventArgs e)
        {

        }

        public void insertChildBeamNode             (string name)
        {
            TreeNode beam = this.nodeBeam.Nodes.Add(name);
            beam.Name = name;

            beam.TreeView.ImageIndex = 2;
            beam.TreeView.SelectedImageIndex = 2;
            beam.Name = name;
            this.treeView1.ExpandAll();
        }

        private void treeView1_NodeMouseDoubleClick (object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
            
            if (e.Button == MouseButtons.Left)
            {
               if(this.treeView1.SelectedNode.Level==1)
                {
                    if (treeView1.SelectedNode.Parent.Text == "Vigas")
                    {
                        string beamName = treeView1.SelectedNode.Text;

                        // verifica se a janela desta viga já está aberta
                        List<string> frmtitle = new List<string>();
                        if (Application.OpenForms.OfType<FViga>().Count() > 0)
                        {
                            var f = Application.OpenForms.OfType<FViga>().ToList();
                            //MessageBox.Show(f.First().Text);
                            foreach (var fm in f)
                            {
                                frmtitle.Add(fm.Text);
                            }
                        }

                        if (frmtitle.Find(c => c == beamName) == null)
                        {
                            Beam.clsIOManager io = new Beam.clsIOManager();
                            Beam.clsBeam b = new Beam.clsBeam();

                            if (( b=io.readBeamInputFile(beamName + ".cdv"))!= null)
                            {

                            FViga fv = new FViga();
                            fv.Text = beamName;
                            fv.Show(this.DockPanel, DockState.Document);
                            fv.FillScreen(b);
                            }
                            else
                            {
                                File.Delete(ProjectInfo.projectPath + @"\Beams\" + beamName + ".cdv");
                                removeBeamChildNode(beamName);
                                io.removeBeamFromProject(beamName);
                            }
                        }

                       else
                        {
                            MessageBox.Show("A Janela desta viga já está aberta!");
                        }
                    }
                    else if (treeView1.SelectedNode.Parent.Text == "Elementos")
                    {
                        
                    }
                }
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

        }

        public void CarregaArvare()
        {
            il.Images.Add(new Icon(@"img\closedfolder.ico"));
            il.Images.Add(new Icon(@"img\openfolder.ico"));
            il.Images.Add(new Icon(@"img\beamico.ico"));
            il.Images.Add(new Icon(@"img\profile.ico"));
            this.treeView1.ImageList = il;

            nodeBeam = new TreeNode();
            //nodeElement = new TreeNode();
            
            nodeBeam = this.treeView1.Nodes.Add("Vigas");  // pasta vigas na arvore do projeto
            this.treeView1.Nodes[0].Name = "Vigas";
            nodeBeam.ImageIndex = 0;
            nodeBeam.SelectedImageIndex = 1;

            //nodeElement.Name = "Elementos";
        //     nodeElement = this.treeView1.Nodes.Add("Elementos"); 
         //   this.treeView1.Nodes[0].Name = "Elementos";
         //   nodeElement.ImageIndex = 0;
         //   nodeElement.SelectedImageIndex = 1;

            
        }

        public void removeBeamChildNode             (string nodeName)
        {
           var node =  nodeBeam.Nodes.Find(nodeName, false).SingleOrDefault();
            nodeBeam.Nodes.Remove(node);
        }
        
    }
}
