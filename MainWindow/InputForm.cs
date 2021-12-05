using Beam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MainWin
{
    public partial class InputForm : Form
    {
        private string NomeVigaCopiada;
        public string NomeNovaViga;
        private string UltimaViga;
        public InputForm(string _NomeVigaCopiada, string _UltimaViga)
        {
            this.NomeVigaCopiada = _NomeVigaCopiada;
            this.UltimaViga = _UltimaViga;

            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            NomeNovaViga = this.TxtNomeViga.Text;
            clsIOManager io = new clsIOManager();
            string VigaAtual = ProjectInfo.projectPath +"\\Beams\\"+ this.NomeVigaCopiada + ".cdv";
            string NovaViga = ProjectInfo.projectPath + "\\Beams\\" + NomeNovaViga + ".cdv";
            io.CopyBeam(VigaAtual, NovaViga, UltimaViga);
            this.Close();
             

            
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }
    }
}
