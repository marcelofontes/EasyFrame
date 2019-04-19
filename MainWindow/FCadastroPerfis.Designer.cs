namespace MainWin
{
    partial class FCadastroPerfis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgCadPerfil = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtR = new System.Windows.Forms.TextBox();
            this.txttfi = new System.Windows.Forms.TextBox();
            this.txtbfi = new System.Windows.Forms.TextBox();
            this.txttfs = new System.Windows.Forms.TextBox();
            this.txtbfs = new System.Windows.Forms.TextBox();
            this.txttw = new System.Windows.Forms.TextBox();
            this.txtd = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.cSTableDataSet = new MainWin.CSTableDataSet();
            this.cSTableDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCadPerfil)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSTableDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSTableDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgCadPerfil);
            this.panel1.Location = new System.Drawing.Point(231, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 828);
            this.panel1.TabIndex = 0;
            // 
            // dgCadPerfil
            // 
            this.dgCadPerfil.AllowUserToResizeRows = false;
            this.dgCadPerfil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCadPerfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCadPerfil.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCadPerfil.Location = new System.Drawing.Point(0, 0);
            this.dgCadPerfil.MultiSelect = false;
            this.dgCadPerfil.Name = "dgCadPerfil";
            this.dgCadPerfil.ReadOnly = true;
            this.dgCadPerfil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCadPerfil.Size = new System.Drawing.Size(1197, 828);
            this.dgCadPerfil.TabIndex = 0;
            this.dgCadPerfil.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCadPerfil_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtR);
            this.panel2.Controls.Add(this.txttfi);
            this.panel2.Controls.Add(this.txtbfi);
            this.panel2.Controls.Add(this.txttfs);
            this.panel2.Controls.Add(this.txtbfs);
            this.panel2.Controls.Add(this.txttw);
            this.panel2.Controls.Add(this.txtd);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.cbTable);
            this.panel2.Location = new System.Drawing.Point(2, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 828);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 579);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "R [mm]:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 553);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "tfi  [mm]:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 527);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "bfi  [mm]:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 501);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "tf/tfs [mm]:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "bf ou bfs [mm]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "tw [mm]:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "d [mm]:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Tabela de Perfis:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome:";
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(118, 579);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(100, 20);
            this.txtR.TabIndex = 8;
            this.txtR.Text = "0";
            this.txtR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttfi
            // 
            this.txttfi.Location = new System.Drawing.Point(118, 553);
            this.txttfi.Name = "txttfi";
            this.txttfi.Size = new System.Drawing.Size(100, 20);
            this.txttfi.TabIndex = 7;
            this.txttfi.Text = "0";
            this.txttfi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbfi
            // 
            this.txtbfi.Location = new System.Drawing.Point(118, 527);
            this.txtbfi.Name = "txtbfi";
            this.txtbfi.Size = new System.Drawing.Size(100, 20);
            this.txtbfi.TabIndex = 6;
            this.txtbfi.Text = "0";
            this.txtbfi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttfs
            // 
            this.txttfs.Location = new System.Drawing.Point(118, 501);
            this.txttfs.Name = "txttfs";
            this.txttfs.Size = new System.Drawing.Size(100, 20);
            this.txttfs.TabIndex = 5;
            this.txttfs.Text = "0";
            this.txttfs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbfs
            // 
            this.txtbfs.Location = new System.Drawing.Point(118, 475);
            this.txtbfs.Name = "txtbfs";
            this.txtbfs.Size = new System.Drawing.Size(100, 20);
            this.txtbfs.TabIndex = 4;
            this.txtbfs.Text = "0";
            this.txtbfs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttw
            // 
            this.txttw.Location = new System.Drawing.Point(118, 449);
            this.txttw.Name = "txttw";
            this.txttw.Size = new System.Drawing.Size(100, 20);
            this.txttw.TabIndex = 3;
            this.txttw.Text = "0";
            this.txttw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtd
            // 
            this.txtd.Location = new System.Drawing.Point(118, 423);
            this.txtd.Name = "txtd";
            this.txtd.Size = new System.Drawing.Size(100, 20);
            this.txtd.TabIndex = 2;
            this.txtd.Text = "0";
            this.txtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 397);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "0";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(7, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 265);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 265);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Items.AddRange(new object[] {
            "C",
            "CS",
            "CVS",
            "PS",
            "PSa",
            "VS",
            "VSM",
            "W"});
            this.cbTable.Location = new System.Drawing.Point(10, 54);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(213, 21);
            this.cbTable.TabIndex = 0;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
            // 
            // cSTableDataSet
            // 
            this.cSTableDataSet.DataSetName = "CSTableDataSet";
            this.cSTableDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cSTableDataSetBindingSource
            // 
            this.cSTableDataSetBindingSource.DataSource = this.cSTableDataSet;
            this.cSTableDataSetBindingSource.Position = 0;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(231, 856);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 2;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(312, 856);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 2;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(393, 856);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1353, 856);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FCadastroPerfis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1440, 891);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FCadastroPerfis";
            this.Text = "Cadastro de Perfis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FCadastroPerfis_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCadPerfil)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSTableDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSTableDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgCadPerfil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource cSTableDataSetBindingSource;
        private CSTableDataSet cSTableDataSet;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.TextBox txttfi;
        private System.Windows.Forms.TextBox txtbfi;
        private System.Windows.Forms.TextBox txttfs;
        private System.Windows.Forms.TextBox txtbfs;
        private System.Windows.Forms.TextBox txttw;
        private System.Windows.Forms.TextBox txtd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
    }
}