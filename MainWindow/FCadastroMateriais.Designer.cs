namespace MainWin
{
    partial class FCadastroMateriais
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
            this.dgMateriais = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtE = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtFy = new System.Windows.Forms.TextBox();
            this.txtFu = new System.Windows.Forms.TextBox();
            this.txtGama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInseir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgMateriais)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMateriais
            // 
            this.dgMateriais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMateriais.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgMateriais.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgMateriais.Location = new System.Drawing.Point(0, 196);
            this.dgMateriais.MultiSelect = false;
            this.dgMateriais.Name = "dgMateriais";
            this.dgMateriais.ReadOnly = true;
            this.dgMateriais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMateriais.Size = new System.Drawing.Size(770, 616);
            this.dgMateriais.TabIndex = 0;
            this.dgMateriais.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMateriais_CellClick);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(169, 81);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(169, 116);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(145, 20);
            this.txtE.TabIndex = 2;
            this.txtE.Text = "200000";
            this.txtE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(169, 155);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(145, 20);
            this.txtG.TabIndex = 3;
            this.txtG.Text = "77000";
            this.txtG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFy
            // 
            this.txtFy.Location = new System.Drawing.Point(460, 81);
            this.txtFy.Name = "txtFy";
            this.txtFy.Size = new System.Drawing.Size(145, 20);
            this.txtFy.TabIndex = 4;
            this.txtFy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFu
            // 
            this.txtFu.Location = new System.Drawing.Point(460, 116);
            this.txtFu.Name = "txtFu";
            this.txtFu.Size = new System.Drawing.Size(145, 20);
            this.txtFu.TabIndex = 5;
            this.txtFu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGama
            // 
            this.txtGama.Location = new System.Drawing.Point(460, 155);
            this.txtGama.Name = "txtGama";
            this.txtGama.Size = new System.Drawing.Size(145, 20);
            this.txtGama.TabIndex = 6;
            this.txtGama.Text = "7850";
            this.txtGama.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mód. Elasticidade E [MPa]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mód. Elast. Transv. G [MPa]:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fy[kN/cm2]:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fu[kN/cm2]:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Peso Esp. [kgf/m3]";
            // 
            // btnInseir
            // 
            this.btnInseir.Location = new System.Drawing.Point(683, 94);
            this.btnInseir.Name = "btnInseir";
            this.btnInseir.Size = new System.Drawing.Size(75, 23);
            this.btnInseir.TabIndex = 7;
            this.btnInseir.Text = "Inserir";
            this.btnInseir.UseVisualStyleBackColor = true;
            this.btnInseir.Click += new System.EventHandler(this.btnInseir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(683, 123);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 8;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(683, 152);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(75, 23);
            this.btnApagar.TabIndex = 9;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(238, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 29);
            this.label7.TabIndex = 10;
            this.label7.Text = "Biblioteca de Materiais";
            // 
            // FCadastroMateriais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(770, 812);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnInseir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGama);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtFu);
            this.Controls.Add(this.txtFy);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dgMateriais);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "FCadastroMateriais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca de Materiais";
            this.Load += new System.EventHandler(this.FCadastroMateriais_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMateriais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMateriais;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtFy;
        private System.Windows.Forms.TextBox txtFu;
        private System.Windows.Forms.TextBox txtGama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnInseir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}