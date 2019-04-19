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
using DATAACCESS;

namespace MainWin
{
    public partial class FCadastroMateriais : DockContent
    {
        int SelectedItemId;
        public FCadastroMateriais()
        {
            InitializeComponent();
        }

        private void FCadastroMateriais_Load    (object sender, EventArgs e)
        {
            dgMateriais.DataSource = null;
            Materials mt = new Materials();
            dgMateriais.DataSource = mt.getMaterialTable(); 
        }

        private void btnInseir_Click            (object sender, EventArgs e)
        {
           
            double aux;
            try
            {
                if(string.IsNullOrWhiteSpace(txtName.Text)
                    ||txtName.Text.Length< 3)
                {
                    throw new Exception("Nome inválido.");
                }
                else if(
                       !double.TryParse(txtE.Text, out aux)
                    || !double.TryParse(txtG.Text, out aux)
                    || !double.TryParse(txtFy.Text, out aux)
                    || !double.TryParse(txtFu.Text, out aux)
                    || !double.TryParse(txtGama.Text, out aux)
                    || double.Parse(txtE.Text)<=0
                    || double.Parse(txtG.Text)<=0
                    || double.Parse(txtFy.Text)<=0
                    || double.Parse(txtFu.Text)<=0
                    || double.Parse(txtGama.Text)<=0)
                    {
                    throw new Exception("Valores numéricos inválidos.");
                    }
                else
                {
                    Material m = new Material();
                    Materials mt = new Materials();
                    
                    m.name = txtName.Text;
                    m.E = double.Parse(txtE.Text);
                    m.G = double.Parse(txtE.Text);
                    m.unitWeight = double.Parse(txtGama.Text);
                    m.Fy = double.Parse(txtFy.Text);
                    m.Fu = double.Parse(txtFu.Text);
                    mt.insertMaterial(m);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click           (object sender, EventArgs e)
        {
            double aux;
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text)
                    || txtName.Text.Length < 3)
                {
                    throw new Exception("Nome inválido.");
                }
                else if (
                       !double.TryParse(txtE.Text, out aux)
                    || !double.TryParse(txtG.Text, out aux)
                    || !double.TryParse(txtFy.Text, out aux)
                    || !double.TryParse(txtFu.Text, out aux)
                    || !double.TryParse(txtGama.Text, out aux)
                    || double.Parse(txtE.Text) <= 0
                    || double.Parse(txtG.Text) <= 0
                    || double.Parse(txtFy.Text) <= 0
                    || double.Parse(txtFu.Text) <= 0
                    || double.Parse(txtGama.Text) <= 0)
                {
                    throw new Exception("Valores numéricos inválidos.");
                }
                else
                {
                    Material m = new Material();
                    Materials mt = new Materials();

                    m.ID = SelectedItemId;
                    m.name = txtName.Text;
                    m.E = double.Parse(txtE.Text);
                    m.G = double.Parse(txtG.Text);
                    m.unitWeight = double.Parse(txtGama.Text);
                    m.Fy = double.Parse(txtFy.Text);
                    m.Fu = double.Parse(txtFu.Text);
                    mt.updateMaterial(m);
                   
                    dgMateriais.DataSource = mt.getMaterialTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnApagar_Click            (object sender, EventArgs e)
        {
            Materials mt = new Materials();
            mt.deleteMaterial(SelectedItemId);
            dgMateriais.DataSource = mt.getMaterialTable();
        }

        private void dgMateriais_CellClick      (object sender, DataGridViewCellEventArgs e)
        {
            int i = dgMateriais.CurrentRow.Index;
            SelectedItemId = int.Parse(dgMateriais.Rows[i].Cells[0].Value.ToString());
            Materials mt = new Materials();

            Material m = new Material();
            m = mt.getMaterialByID(SelectedItemId);

            txtName.Text = m.name;
            txtE.Text = m.E.ToString();
            txtG.Text = m.G.ToString();
            txtFy.Text = m.Fy.ToString();
            txtFu.Text = m.Fu.ToString();
            txtGama.Text = m.unitWeight.ToString();
        }
    }
}
