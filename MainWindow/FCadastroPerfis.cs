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
using System.IO;


namespace MainWin
{
    public partial class FCadastroPerfis : DockContent
    {
        
        string appPath;
        int SelectedItemId;

        public FCadastroPerfis()
        {
            InitializeComponent();
        }

        private void FCadastroPerfis_Load           (object sender, EventArgs e)
        {
            this.cbTable.SelectedIndex = 7;
            PreencheDataGrid(cbTable.Text);
            appPath = Directory.GetCurrentDirectory();

            setPictureBox(this.cbTable.Text);
           
        }

        private void PreencheDataGrid               (string table)
        {

            switch (table)
            {
                case "C":
                    this.dgCadPerfil.DataSource = new PerfilC().getCSTable();
                    break;
                case "CS":
                    this.dgCadPerfil.DataSource = new PerfilCS().getCSTable();
                    break;
                case "CVS":
                    this.dgCadPerfil.DataSource = new PerfilCVS().getCSTable();
                    break;
                case "VS":
                    this.dgCadPerfil.DataSource = new PerfilVS().getCSTable();
                    break;
                case "VSM":
                    this.dgCadPerfil.DataSource = new PerfilVSM().getCSTable();
                    this.dgCadPerfil.Columns["tfs"].DisplayIndex = 8;
                    this.dgCadPerfil.Columns["tfi"].DisplayIndex = 9;
                    this.dgCadPerfil.Columns["Ix"].DisplayIndex = 10;
                    this.dgCadPerfil.Columns["Wxs"].DisplayIndex = 11;
                    this.dgCadPerfil.Columns["Wxi"].DisplayIndex = 12;
                    break;
                case "W":
                    this.dgCadPerfil.DataSource = new PerfilW().getCSTable();
                    break;
                case "PS":
                    this.dgCadPerfil.DataSource = new PerfilPS().getCSTable();
                    break;
                case "PSa":
                    this.dgCadPerfil.DataSource = new PerfilPSa().getCSTable();
                    this.dgCadPerfil.Columns["tfs"].DisplayIndex = 8;
                    this.dgCadPerfil.Columns["tfi"].DisplayIndex = 9;
                    this.dgCadPerfil.Columns["Ix"].DisplayIndex = 10;
                    this.dgCadPerfil.Columns["Wxs"].DisplayIndex = 11;
                    this.dgCadPerfil.Columns["Wxi"].DisplayIndex = 12;
                    break;
            }
        }

        private void cbTable_SelectedIndexChanged   (object sender, EventArgs e)
        {
            PreencheDataGrid(this.cbTable.Text);
            setPictureBox(this.cbTable.Text);
            limpacampos();
        }

        private void btnInserir_Click               (object sender, EventArgs e)
        {
            double aux;
            int aux2;
            try
            {
                if(txtName.Text=="" || txtName.Text == "0"||txtName.Text.Length<3)
                {
                    throw new Exception("Valor inválido para o nome do perfil. O valor nao pode ser nulo, negativo ou possuir menos de 3 caracteres");
                }
                else if(txtd.Text=="0"|| txtd.Text==""||!int.TryParse((string)txtd.Text,out aux2) || int.Parse(txtd.Text)<=0)
                {
                    throw new Exception("Valor inválido para a dimensão 'd'");
                }
                else if (txttw.Text == "0" || txttw.Text == "" || !double.TryParse((string)txttw.Text.Replace(",", "."), out aux) || double.Parse(txttw.Text.Replace(",", ".")) <= 0)
                {
                    throw new Exception("Valor inválido para a dimensão 'tw'");
                }
                else if (txtbfs.Text == "0" || txtbfs.Text == "" || !int.TryParse((string)txtbfs.Text, out aux2) || int.Parse(txtbfs.Text) <= 0)
                {
                    throw new Exception("Valor inválido para a dimensão 'bfs'");
                }
                else if (txttfs.Text == "0" || txttfs.Text == "" || !double.TryParse((string)txttfs.Text.Replace(",", "."), out aux) || double.Parse(txttfs.Text.Replace(",", ".")) <= 0)
                {
                    throw new Exception("Valor inválido para a dimensão 'tfs'");
                }
                else if (txtbfi.Text == "0" || txtbfi.Text == "" || !int.TryParse((string)txtbfi.Text, out aux2) || int.Parse(txtbfi.Text) <= 0)
                {
                    throw new Exception("Valor inválido para a dimensão 'bfi'");
                }
                else if (txttfi.Text == "0" || txttfi.Text == "" || !double.TryParse((string)txttfi.Text.Replace(",", "."), out aux) || double.Parse(txttfi.Text.Replace(",", ".")) <= 0)
                {
                    throw new Exception("Valor inválido para a dimensão 'tfi'");
                }
                else if (txtR.Text == "" || !int.TryParse((string)txtR.Text, out aux2) || int.Parse(txtR.Text) < 0)
                {
                    throw new Exception("Valor inválido para a dimensão 'R'");
                }
                else
                {
                    // tirar este comentário para gravar no banco de dados
                    string name = txtName.Text;
                    var dim = readProfileDimensions();
                    SetProfileProperties(cbTable.Text, name, dim, "insert");
                    PreencheDataGrid(cbTable.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetProfileProperties           (string ProfTable, string name, List<double> dim, string action)
        {
            double A = 0;
            double Ix = 0;
            double Iy = 0;
            double Wxs = 0;
            double Wxi = 0;
            double Wyr = 0;
            double Wyl = 0;
            double Zx = 0;
            double Zy = 0;
            double rx = 0;
            double ry = 0;
            double rT = 0;
            double It = 0;
            double Cw = 0;
            double ycg;
            double xcg;
            int R;
            int d, bfs, bfi;
            double tw, tfs, tfi, h;
            
            #region comentario
            /*
             * dim:
             * 0 = d
             * 1 = tw
             * 2 = bfs
             * 3 = tfs
             * 4 = bfi
             * 5 = tfi
             * 6 = R
             */
            #endregion

            d = int.Parse(dim[0].ToString());
            tw  = dim[1];
            bfs = int.Parse(dim[2].ToString());
            tfs = dim[3];
            bfi = int.Parse(dim[4].ToString());
            tfi = dim[5];
            R   = int.Parse(dim[6].ToString());

            #region if
            if (ProfTable == "C")
            {

            }
            else if (ProfTable == "CS" || ProfTable == "CVS" || ProfTable == "PS" || ProfTable == "VS" || ProfTable == "W" || ProfTable == "VSM" || ProfTable == "PSa")
            {
                h = d - 2 * tfs;
                ycg = (bfs * tfs * (d - 0.5 * tfs) + (d - tfs - tfi) * tw * (0.5*(d - tfs-tfi)+tfs) + 0.5* bfi * tfi * tfi) / (bfs * tfs + (d - tfs - tfi) * tw + bfi * tfi);
                xcg = 0;
                //Ix = bfs * Math.Pow(tfs, 3) / 12 + bfs * tfs * Math.Pow((d - ycg - tfs * 0.5), 2) + Math.Pow((d - tfs - tfi), 3) * tw / 12 + (d - tfs - tfi) * tw * Math.Pow(((d - tfs - tfi) * 0.5 - ycg), 2) + bfi * tfi * tfi * tfi / 12 + bfi * tfi * Math.Pow(ycg - 0.5 * tfi, 2);
                Ix = bfs * tfs * tfs * tfs / 12 + bfs * tfs * Math.Pow((d - ycg - 0.5 * tfs), 2) + 
                    tw * Math.Pow( (d - tfs - tfi), 3) / 12 + (d - tfs - tfi) * tw * (Math.Pow((0.5 * (d - tfs-tfi) - ycg + tfi), 2)) +
                    bfi*tfi*tfi*tfi/12 + bfi*tfi*Math.Pow(ycg-0.5*tfi,2);

                Iy = tfs * Math.Pow(bfs, 3) / 12 + tfi * Math.Pow(bfi, 3) / 12 + (d - tfs - tfi) * Math.Pow(tw, 3) / 12;
                double ys, yi;
                ys = d - ycg;
                yi = d - ys;
                Wxs = Ix / ys;
                Wxi = Ix / yi;
                Wyr = Iy / (Math.Max(bfs / 2, bfi / 2));
                Wyl = Wyr;
                A = bfs * tfs + bfi * tfi + (d - tfs - tfi) * tw;
                rx = Math.Sqrt(Ix / A);
                ry = Math.Sqrt(Iy / A);
                
                Zx = bfs * tfs * (d - ycg - tfs * 0.5) + (d - tfs - ycg) * tw + (d - tfs - ycg) * 0.5 + (ycg - tfi) * tw * (ycg - tfi * 0.5) + bfi * tfi * (ycg - tfi * 0.5);
                Zy = 2 * bfs * 0.5 * tfs * bfs * 0.25 + 2 * bfi * 0.5 * tfi * bfi * 0.25 + 0.5 * tw * (d - tfs - tfi) * 0.25 * tw * 2;
                It = bfs * tfs * tfs * tfs / 3 + (d - tfs - tfi) * tw * tw * tw / 3 + bfi * tfi * tfi * tfi / 3;
                /* rT deve ser calculado em função da parte comprimida, sendo dado pelo raio de giro em Y da mesa comprimida
                 *  + 1/6 da alma
                 *  */
                double Ih = ((d - tfs - tfi) / 6)*tw*tw*tw / 12;
                rT = Math.Sqrt((tfs*bfs*bfs*bfs/12 + Ih) / (bfs * tfs + ((d - tfs - tfi)/6) * tw));

                double dl = d - (tfs + tfi) / 2;
                double alpha = 1 / (1 + (Math.Pow(bfs / bfi, 3) * (tfs / tfi)));
                Cw = dl * dl * bfs * bfs * bfs * tfs * alpha / 12;
            }
            #endregion

            #region switch

            switch (ProfTable)
                {
                    case "C":
                        {
                        C p = new C();
                        PerfilC pf = new PerfilC();
                        if (action.CompareTo("insert") == 0)
                        {
                            if (!pf.insertProfile(p))
                            {
                                MessageBox.Show("Problema ao inserir perfil!");
                            }
                        }
                        else if (action.CompareTo("update") == 0)
                        {
                            p.ID = SelectedItemId;
                            if (!pf.updateProfile(p))
                            {
                                MessageBox.Show("Problema ao atualizar perfil!");
                            }
                        }
                        PreencheDataGrid(cbTable.Text);
                        break;
                    }
                    case "CS":
                        {
                        CS p = new CS();
                        p.nome = name;
                        p.d = d;
                        p.tw = tw;
                        p.bf = bfs;
                        p.tf = tfs;
                        p.A = A*1E-2;
                        p.Ix = Ix*1E-4;
                        p.Wx = Wxs*1E-3;
                        p.rx = rx*0.1;
                        p.Zx = Zx*1E-3;
                        p.Iy = Iy*1E-4;
                        p.Wy = Wyr*1E-3;
                        p.Zy = Zy*1E-3;
                        p.ry = ry*0.1;
                        p.IT = It*1E-4;
                        p.rT = rT*0.1;
                        p.Cw = Cw*1E-6;
                        p.peso = p.A * 7850*1E-4;
                        p.Fabrication = 1;
                        p.ProfCode = 100;
                        p.R = R;
                        PerfilCS pf = new PerfilCS();
                        if (action.CompareTo("insert") == 0)
                        {
                            if (!pf.insertProfile(p))
                            {
                                MessageBox.Show("Problema ao inserir perfil!");
                            }
                        }
                        else if (action.CompareTo("update") == 0)
                        {
                            p.ID = SelectedItemId;
                            if (!pf.updateProfile(p))
                            {
                                MessageBox.Show("Problema ao atualizar perfil!");
                            }
                        }
                        PreencheDataGrid(cbTable.Text);
                        break;
                    }
                    case "CVS":
                        {
                        CVS p = new CVS();
                        p.nome = name;
                        p.d = d;
                        p.tw = tw;
                        p.bf = bfs;
                        p.tf = tfs;
                        p.A = A * 1E-2;
                        p.Ix = Ix * 1E-4;
                        p.Wx = Wxs * 1E-3;
                        p.rx = rx * 0.1;
                        p.Zx = Zx * 1E-3;
                        p.Iy = Iy * 1E-4;
                        p.Wy = Wyr * 1E-3;
                        p.Zy = Zy * 1E-3;
                        p.ry = ry * 0.1;
                        p.IT = It * 1E-4;
                        p.rT = rT * 0.1;
                        p.Cw = Cw * 1E-6;
                        p.peso = p.A * 7850 * 1E-4;
                        p.Fabrication = 1;
                        p.ProfCode = 100;
                        p.R = R;
                        PerfilCVS pf = new PerfilCVS();
                        if (action.CompareTo("insert") == 0)
                        {
                            if (!pf.insertProfile(p))
                            {
                                MessageBox.Show("Problema ao inserir perfil!");
                            }
                        }
                        else if (action.CompareTo("update") == 0)
                        {
                            p.ID = SelectedItemId;
                            if (!pf.updateProfile(p))
                            {
                                MessageBox.Show("Problema ao atualizar perfil!");
                            }
                        }
                        PreencheDataGrid(cbTable.Text);
                        break;
                    }
                    case "PS":
                        {
                        PS p = new PS();
                        p.nome = name;
                        p.d = d;
                        p.tw = tw;
                        p.bf = bfs;
                        p.tf = tfs;
                        p.A = A * 1E-2;
                        p.Ix = Ix * 1E-4;
                        p.Wx = Wxs * 1E-3;
                        p.rx = rx * 0.1;
                        p.Zx = Zx * 1E-3;
                        p.Iy = Iy * 1E-4;
                        p.Wy = Wyr * 1E-3;
                        p.Zy = Zy * 1E-3;
                        p.ry = ry * 0.1;
                        p.IT = It * 1E-4;
                        p.rT = rT * 0.1;
                        p.Cw = Cw * 1E-6;
                        p.peso = p.A * 7850 * 1E-4;
                        p.Fabrication = 1;
                        p.ProfCode = 100;
                        p.R = R;
                        PerfilPS pf = new PerfilPS();
                        if (action.CompareTo("insert") == 0)
                        {
                            if (!pf.insertProfile(p))
                            {
                                MessageBox.Show("Problema ao inserir perfil!");
                            }
                        }
                        else if (action.CompareTo("update") == 0)
                        {
                            p.ID = SelectedItemId;
                            if (!pf.updateProfile(p))
                            {
                                MessageBox.Show("Problema ao atualizar perfil!");
                            }
                        }
                        PreencheDataGrid(cbTable.Text);
                        break;
                    }
                    case "VS":
                        {
                        VS p = new VS();
                        p.nome = name;
                        p.d = d;
                        p.tw = tw;
                        p.bf = bfs;
                        p.tf = tfs;
                        p.A = A * 1E-2;
                        p.Ix = Ix * 1E-4;
                        p.Wx = Wxs * 1E-3;
                        p.rx = rx * 0.1;
                        p.Zx = Zx * 1E-3;
                        p.Iy = Iy * 1E-4;
                        p.Wy = Wyr * 1E-3;
                        p.Zy = Zy * 1E-3;
                        p.ry = ry * 0.1;
                        p.IT = It * 1E-4;
                        p.rT = rT * 0.1;
                        p.Cw = Cw * 1E-6;
                        p.peso = p.A * 7850 * 1E-4;
                        p.Fabrication = 1;
                        p.ProfCode = 100;
                        p.R = R;
                        PerfilVS pf = new PerfilVS();
                        if (action.CompareTo("insert") == 0)
                        {
                            if (!pf.insertProfile(p))
                            {
                                MessageBox.Show("Problema ao inserir perfil!");
                            }
                        }
                        else if (action.CompareTo("update") == 0)
                        {
                            p.ID = SelectedItemId;
                            if (!pf.updateProfile(p))
                            {
                                MessageBox.Show("Problema ao atualizar perfil!");
                            }
                        }
                        PreencheDataGrid(cbTable.Text);
                        break;
                    }
                    case "PSa":
                        {
                        PSa p = new PSa();
                        p.nome = name;
                        p.d = d;
                        p.tw = tw;
                        p.bfs = bfs;
                        p.tfs = tfs;
                        p.bfi = bfi;
                        p.tfi = tfi;
                        p.A = A*1E-2;
                        p.Ix = Ix*1E-4;
                        p.Wxs = Wxs*1E-3;
                        p.Wxi = Wxi*1E-3;
                        p.rx = rx*0.1;
                        p.Zx = Zx*1E-3;
                        p.Iy = Iy*1E-4;
                        p.Wy = Wyr*1E-3;
                        p.Zy = Zy*1E-3;
                        p.ry = ry*0.1;
                        p.IT = It*1E-4;
                        p.rT = rT*0.1;
                        p.Cw = Cw*1E-6;
                        p.peso = A * 7850*1E-4;
                        p.Fabrication = 1;
                        p.ProfCode = 100;
                        p.R = R;
                        PerfilPSa pf = new PerfilPSa();
                        if (action.CompareTo("insert") == 0)
                        {
                            if (!pf.insertProfile(p))
                            {
                                MessageBox.Show("Problema ao inserir perfil!");
                            }
                        }
                        else if (action.CompareTo("update") == 0)
                        {
                            p.ID = SelectedItemId;
                            if (!pf.updateProfile(p))
                            {
                                MessageBox.Show("Problema ao atualizar perfil!");
                            }
                        }
                        PreencheDataGrid(cbTable.Text);
                        break;
                    }
                    case "VSM":
                        {
                        VSM p = new VSM();
                        p.nome = name;
                        p.d = d;
                        p.tw = tw;
                        p.bfs = bfs;
                        p.tfs = tfs;
                        p.bfi = bfi;
                        p.tfi = tfi;
                        p.A = A * 1E-2;
                        p.Ix = Ix * 1E-4;
                        p.Wxs = Wxs * 1E-3;
                        p.Wxi = Wxi * 1E-3;
                        p.rx = rx * 0.1;
                        p.Zx = Zx * 1E-3;
                        p.Iy = Iy * 1E-4;
                        p.Wy = Wyr * 1E-3;
                        p.Zy = Zy * 1E-3;
                        p.ry = ry * 0.1;
                        p.IT = It * 1E-4;
                        p.rT = rT * 0.1;
                        p.Cw = Cw * 1E-6;
                        p.peso = A * 7850*1E-4;
                        p.Fabrication = 1;
                        p.ProfCode = 100;
                        p.R = R;
                        PerfilVSM pf = new PerfilVSM();
                        if (action.CompareTo("insert") == 0)
                        {
                            if (!pf.insertProfile(p))
                            {
                                MessageBox.Show("Problema ao inserir perfil!");
                            }
                        }
                        else if (action.CompareTo("update") == 0)
                        {
                            p.ID = SelectedItemId;
                            if (!pf.updateProfile(p))
                            {
                                MessageBox.Show("Problema ao atualizar perfil!");
                            }
                        }
                        PreencheDataGrid(cbTable.Text);
                        break;
                    }
                    case "W":
                        {
                        W p = new W();
                        p.nome = name;
                        p.d = d;
                        p.tw = tw;
                        p.bf = bfs;
                        p.tf = tfs;
                        p.A = A * 1E-2;
                        p.Ix = Ix * 1E-4;
                        p.Wx = Wxs * 1E-3;
                        p.rx = rx * 0.1;
                        p.Zx = Zx * 1E-3;
                        p.Iy = Iy * 1E-4;
                        p.Wy = Wyr * 1E-3;
                        p.Zy = Zy * 1E-3;
                        p.ry = ry * 0.1;
                        p.IT = It * 1E-4;
                        p.rT = rT * 0.1;
                        p.Cw = Cw * 1E-6;
                        p.peso = p.A * 7850 * 1E-4;
                        p.Fabrication = 2;
                        p.ProfCode = 101;
                        p.R = R;
                        PerfilW pf = new PerfilW();
                        if (action.CompareTo("insert") == 0)
                        {
                            if (!pf.insertProfile(p))
                            {
                                MessageBox.Show("Problema ao inserir perfil!");
                            }
                        }
                        else if (action.CompareTo("update") == 0)
                        {
                            p.ID = SelectedItemId;
                            if (!pf.updateProfile(p))
                            {
                                MessageBox.Show("Problema ao atualizar perfil!");
                            }
                        }
                        PreencheDataGrid(cbTable.Text);
                        break;
                    }
            }
            #endregion
           
        }

        private List<double> readProfileDimensions()
        {
            List<double> L = new List<double>();

            L.Add(int.Parse(txtd.Text));
            L.Add(double.Parse(txttw.Text.Replace(",", ".")));
            L.Add(int.Parse(txtbfs.Text));
            L.Add(double.Parse(txttfs.Text.Replace(",", ".")));
            L.Add(int.Parse(txtbfi.Text));
            L.Add(double.Parse(txttfi.Text.Replace(",", ".")));
            L.Add(int.Parse(txtR.Text));

            return L;
        }

        private void panel2_Paint                   (object sender, PaintEventArgs e)
        {

        }

        private void setPictureBox                  (string table)
        {
            switch (this.cbTable.Text)
            {
                case "C":
                    this.pictureBox1.ImageLocation = appPath + @"\img\U_lam.png";
                    this.pictureBox1.Padding = new Padding(25, 0, 15, 0);
                    break;
                case "CS":
                case "VS":
                case "PS":
                case "CVS":
                case "VSM":
                    this.pictureBox1.ImageLocation = appPath + @"\img\I_sold1.png";
                    this.pictureBox1.Padding = new Padding(25, 0, 15, 0);
                    break;
                case "PSa":
                    this.pictureBox1.ImageLocation = appPath + @"\img\I_sold2.png";
                    this.pictureBox1.Padding = new Padding(25, 0, 15, 0);
                    break;
                case "W":
                    this.pictureBox1.ImageLocation = appPath + @"\img\I_lam.png";
                    this.pictureBox1.Padding = new Padding(25, 0, 15, 0);
                    break;

            }
        }

        private void dgCadPerfil_CellClick          (object sender, DataGridViewCellEventArgs e)
        {
            int i = dgCadPerfil.CurrentRow.Index;
            SelectedItemId = int.Parse(dgCadPerfil.Rows[i].Cells[0].Value.ToString());
            string tb = cbTable.Text;
          
                switch (tb)
            {
                case "C":
                case "CS":
                case "VS":
                case "CVS":
                case "PS":
                case "W":
                    txtName.Text = dgCadPerfil.Rows[i].Cells[1].Value.ToString();
                    txtd.Text = dgCadPerfil.Rows[i].Cells[4].Value.ToString();
                    txttw.Text = dgCadPerfil.Rows[i].Cells[5].Value.ToString();
                    txtbfs.Text = dgCadPerfil.Rows[i].Cells[6].Value.ToString();
                    txttfs.Text = dgCadPerfil.Rows[i].Cells[7].Value.ToString();
                    txtbfi.Text = dgCadPerfil.Rows[i].Cells[6].Value.ToString();
                    txttfi.Text = dgCadPerfil.Rows[i].Cells[7].Value.ToString();
                    txtR.Text = dgCadPerfil.Rows[i].Cells[21].Value.ToString();
                    break;
                case "PSa":
                case "VSM":
                    txtName.Text = dgCadPerfil.Rows[i].Cells[1].Value.ToString();
                    txtd.Text = dgCadPerfil.Rows[i].Cells[4].Value.ToString();
                    txttw.Text = dgCadPerfil.Rows[i].Cells[5].Value.ToString();
                    txtbfs.Text = dgCadPerfil.Rows[i].Cells[6].Value.ToString();
                    txttfs.Text = dgCadPerfil.Rows[i].Cells[8].Value.ToString();
                    txtbfi.Text = dgCadPerfil.Rows[i].Cells[7].Value.ToString();
                    txttfi.Text = dgCadPerfil.Rows[i].Cells[9].Value.ToString();
                    txtR.Text = dgCadPerfil.Rows[i].Cells[24].Value.ToString();
                    break;
                    
            }
           // MessageBox.Show(dgCadPerfil.CurrentRow.Index.ToString());
        }

        private void limpacampos()
        {
            txtName.Text = "";
            txtd.Text = "0";
            txttw.Text = "0";
            txtbfs.Text = "0";
            txttfs.Text = "0";
            txtbfi.Text = "0";
            txttfi.Text = "0";
            txtR.Text = "0";
        }

        private void btnAlterar_Click               (object sender, EventArgs e)
        {
            List<double> L = readProfileDimensions();
            string tb = cbTable.Text;
            string name = txtName.Text;
            SetProfileProperties(tb, name, L, "update");
            PreencheDataGrid(tb);
        }

        private void btnExcluir_Click               (object sender, EventArgs e)
        {
            string tb = cbTable.Text;

            switch (tb)
            {
                case "C":
                    {
                        PerfilC p = new PerfilC();
                        if (!p.deleteProfile(SelectedItemId))
                        {
                            MessageBox.Show("Erro ao excluir perfil!");
                        }
                        break;
                    }
                case "CS":
                    {
                        PerfilCS p = new PerfilCS();
                        if (!p.deleteProfile(SelectedItemId))
                        {
                            MessageBox.Show("Erro ao excluir perfil!");
                        }
                        break;
                    }
                case "VS":
                    {
                        PerfilVS p = new PerfilVS();
                        if (!p.deleteProfile(SelectedItemId))
                        {
                            MessageBox.Show("Erro ao excluir perfil!");
                        }
                        break;
                    }
                case "CVS":
                    {
                        PerfilCVS p = new PerfilCVS();
                        if (!p.deleteProfile(SelectedItemId))
                        {
                            MessageBox.Show("Erro ao excluir perfil!");
                        }
                        break;
                    }
                case "VSM":
                    {
                        PerfilVSM p = new PerfilVSM();
                        if (!p.deleteProfile(SelectedItemId))
                        {
                            MessageBox.Show("Erro ao excluir perfil!");
                        }
                        break;
                    }
                case "PS":
                    {
                        PerfilPS p = new PerfilPS();
                        if (!p.deleteProfile(SelectedItemId))
                        {
                            MessageBox.Show("Erro ao excluir perfil!");
                        }
                        break;
                    }
                case "PSa":
                    {
                        PerfilPSa p = new PerfilPSa();
                        if (!p.deleteProfile(SelectedItemId))
                        {
                            MessageBox.Show("Erro ao excluir perfil!");
                        }
                        break;
                    }
                case "W":
                    {
                        PerfilW p = new PerfilW();
                        if (!p.deleteProfile(SelectedItemId))
                        {
                            MessageBox.Show("Erro ao excluir perfil!");
                        }
                        break;
                    }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
