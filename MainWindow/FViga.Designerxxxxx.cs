namespace MainWin
{
    partial class FViga
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridVao = new System.Windows.Forms.DataGridView();
            this._ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnomeviga = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridCC = new System.Windows.Forms.DataGridView();
            this.gridCC_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCC_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCC_TipoCarga = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridCC_Posicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCC_ValorCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_V = new System.Windows.Forms.TextBox();
            this.txt_SCP = new System.Windows.Forms.TextBox();
            this.txt_SCC = new System.Windows.Forms.TextBox();
            this.txt_CP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dwgPanel2 = new MainWin.DWGPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVao)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCC)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridVao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtnomeviga);
            this.groupBox1.Location = new System.Drawing.Point(12, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 351);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Geometria";
            // 
            // gridVao
            // 
            this.gridVao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._ID,
            this.vao});
            this.gridVao.Location = new System.Drawing.Point(19, 100);
            this.gridVao.Name = "gridVao";
            this.gridVao.RowHeadersWidth = 51;
            this.gridVao.Size = new System.Drawing.Size(314, 241);
            this.gridVao.TabIndex = 2;
            this.gridVao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVao_CellContentClick);
            this.gridVao.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVao_CellValueChanged);
            // 
            // _ID
            // 
            this._ID.HeaderText = "ID";
            this._ID.MinimumWidth = 6;
            this._ID.Name = "_ID";
            this._ID.ReadOnly = true;
            this._ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._ID.Width = 50;
            // 
            // vao
            // 
            this.vao.HeaderText = "Vão[m]";
            this.vao.MinimumWidth = 6;
            this.vao.Name = "vao";
            this.vao.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vãos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome:";
            // 
            // txtnomeviga
            // 
            this.txtnomeviga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnomeviga.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnomeviga.Location = new System.Drawing.Point(60, 29);
            this.txtnomeviga.Name = "txtnomeviga";
            this.txtnomeviga.ReadOnly = true;
            this.txtnomeviga.Size = new System.Drawing.Size(273, 30);
            this.txtnomeviga.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(383, 438);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(880, 340);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.gridCC);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.txt_V);
            this.tabPage3.Controls.Add(this.txt_SCP);
            this.tabPage3.Controls.Add(this.txt_SCC);
            this.tabPage3.Controls.Add(this.txt_CP);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(872, 314);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Cargas";
            // 
            // gridCC
            // 
            this.gridCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridCC_ID,
            this.gridCC_Descricao,
            this.gridCC_TipoCarga,
            this.gridCC_Posicao,
            this.gridCC_ValorCarga});
            this.gridCC.Location = new System.Drawing.Point(224, 42);
            this.gridCC.Name = "gridCC";
            this.gridCC.RowHeadersWidth = 51;
            this.gridCC.Size = new System.Drawing.Size(630, 266);
            this.gridCC.TabIndex = 5;
            this.gridCC.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCC_CellValueChanged);
            // 
            // gridCC_ID
            // 
            this.gridCC_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gridCC_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridCC_ID.HeaderText = "ID";
            this.gridCC_ID.MinimumWidth = 6;
            this.gridCC_ID.Name = "gridCC_ID";
            this.gridCC_ID.ReadOnly = true;
            this.gridCC_ID.Width = 50;
            // 
            // gridCC_Descricao
            // 
            this.gridCC_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridCC_Descricao.HeaderText = "Descrição";
            this.gridCC_Descricao.MinimumWidth = 6;
            this.gridCC_Descricao.Name = "gridCC_Descricao";
            // 
            // gridCC_TipoCarga
            // 
            this.gridCC_TipoCarga.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.gridCC_TipoCarga.HeaderText = "Tipo de Carga";
            this.gridCC_TipoCarga.MinimumWidth = 6;
            this.gridCC_TipoCarga.Name = "gridCC_TipoCarga";
            this.gridCC_TipoCarga.Width = 150;
            // 
            // gridCC_Posicao
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gridCC_Posicao.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridCC_Posicao.HeaderText = "Posição x [m]";
            this.gridCC_Posicao.MinimumWidth = 6;
            this.gridCC_Posicao.Name = "gridCC_Posicao";
            this.gridCC_Posicao.Width = 125;
            // 
            // gridCC_ValorCarga
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gridCC_ValorCarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridCC_ValorCarga.HeaderText = "Valor da Carga [kN]";
            this.gridCC_ValorCarga.MinimumWidth = 6;
            this.gridCC_ValorCarga.Name = "gridCC_ValorCarga";
            this.gridCC_ValorCarga.Width = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Vento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Sobrecarga Piso:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sobrecarga Cob.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Carga Perm.:";
            // 
            // txt_V
            // 
            this.txt_V.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_V.Location = new System.Drawing.Point(110, 147);
            this.txt_V.Name = "txt_V";
            this.txt_V.Size = new System.Drawing.Size(91, 30);
            this.txt_V.TabIndex = 4;
            this.txt_V.Text = "0";
            this.txt_V.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_SCP
            // 
            this.txt_SCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SCP.Location = new System.Drawing.Point(110, 112);
            this.txt_SCP.Name = "txt_SCP";
            this.txt_SCP.Size = new System.Drawing.Size(91, 30);
            this.txt_SCP.TabIndex = 3;
            this.txt_SCP.Text = "0";
            this.txt_SCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_SCC
            // 
            this.txt_SCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SCC.Location = new System.Drawing.Point(110, 77);
            this.txt_SCC.Name = "txt_SCC";
            this.txt_SCC.Size = new System.Drawing.Size(91, 30);
            this.txt_SCC.TabIndex = 2;
            this.txt_SCC.Text = "0";
            this.txt_SCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_CP
            // 
            this.txt_CP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CP.Location = new System.Drawing.Point(110, 42);
            this.txt_CP.Name = "txt_CP";
            this.txt_CP.Size = new System.Drawing.Size(91, 30);
            this.txt_CP.TabIndex = 1;
            this.txt_CP.Text = "0";
            this.txt_CP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cargas Concentradas [kN]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cargas Distribuídas [kN/m]";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(872, 314);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Definições";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Dados da viga";
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnCalcular.Location = new System.Drawing.Point(1031, 791);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(113, 36);
            this.btnCalcular.TabIndex = 3;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(1150, 791);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(113, 36);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnGravar.Location = new System.Drawing.Point(912, 791);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(113, 36);
            this.btnGravar.TabIndex = 3;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnAtualizar.Location = new System.Drawing.Point(793, 791);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(113, 36);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "&Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.ForeColor = System.Drawing.Color.Yellow;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1145, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Geometria";
            // 
            // dwgPanel2
            // 
            this.dwgPanel2.Location = new System.Drawing.Point(12, 8);
            this.dwgPanel2.Name = "dwgPanel2";
            this.dwgPanel2.Size = new System.Drawing.Size(1258, 403);
            this.dwgPanel2.TabIndex = 5;
            // 
            // FViga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1270, 839);
            this.Controls.Add(this.dwgPanel2);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FViga";
            this.Text = "Vigas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FViga_FormClosed);
            this.Load += new System.EventHandler(this.FViga_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVao)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCC)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtnomeviga;
        private System.Windows.Forms.DataGridView gridVao;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_V;
        private System.Windows.Forms.TextBox txt_SCP;
        private System.Windows.Forms.TextBox txt_SCC;
        private System.Windows.Forms.TextBox txt_CP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.DataGridView gridCC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn vao;
        private DWGPanel dwgPanel1;
        private DWGPanel dwgView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCC_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCC_Descricao;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridCC_TipoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCC_Posicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCC_ValorCarga;
        private DWGPanel dwgPanel2;
    }
}

