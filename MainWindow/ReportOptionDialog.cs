using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;


namespace MainWin
{
    public partial class ReportOptionDialog : DockContent
    {
        string TipoRelatorio1;
        string TipoRelatorio2;
        string NomeViga;
        string Caso;
        public ReportOptionDialog( string _TipoRelatorio1, string _TipoRelatorio2, string _Caso, string _NomeViga)
        {
            this.TipoRelatorio1 = _TipoRelatorio1;
            this.TipoRelatorio2 = _TipoRelatorio2;
            this.NomeViga = _NomeViga;
            this.Caso = _Caso;
            


            InitializeComponent();
        }
        public ReportOptionDialog(string _TipoRelatorio1, string _TipoRelatorio2, string _Caso)
        {
            this.TipoRelatorio1 = _TipoRelatorio1;
            this.TipoRelatorio2 = _TipoRelatorio2;
            this.Caso = _Caso;



            InitializeComponent();
        }
        private void ReportOptionDialog_Load(object sender, EventArgs e)
        {
            this.Rb_RelatorioA.Text = TipoRelatorio1;
            this.Rb_RelatorioB.Text = TipoRelatorio2;
            this.Text = "Gerar Relatório de Cálculo";
           
        }

        private void btn_Gerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Caso == "VIGA")
                {
                    if (this.Rb_RelatorioA.Checked)
                    {
                        string file = ProjectInfo.projectPath + "\\Beams\\BOM_Detalhado_" + NomeViga + ".txt";
                        Process.Start(file);
                    }
                    if (this.Rb_RelatorioB.Checked)
                    {
                        string file = ProjectInfo.projectPath + "\\Beams\\" + NomeViga + ".txt";

                        Process.Start(file);
                    }
                }
                if (this.Caso == "GERAL")
                {
                    if (this.Rb_RelatorioA.Checked)
                    {
                        string file = ProjectInfo.projectPath + "\\Beams\\BOM_GERAL.TXT";
                        Process.Start(file);
                    }
                    if (this.Rb_RelatorioB.Checked)
                    {
                        string file = ProjectInfo.projectPath + "\\Beams\\RESUMO_MATERIAIS.TXT";

                        Process.Start(file);
                    }
                }
            }
            catch(Win32Exception )
            {
                MessageBox.Show("Calcule a viga Primeiro para gerar o relatório individualizado");
            }
          
            
        }
    }
}
