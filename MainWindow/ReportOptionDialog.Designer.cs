
namespace MainWin
{
    partial class ReportOptionDialog
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
            this.Rb_RelatorioA = new System.Windows.Forms.RadioButton();
            this.Rb_RelatorioB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Gerar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rb_RelatorioA
            // 
            this.Rb_RelatorioA.AutoSize = true;
            this.Rb_RelatorioA.Location = new System.Drawing.Point(13, 69);
            this.Rb_RelatorioA.Name = "Rb_RelatorioA";
            this.Rb_RelatorioA.Size = new System.Drawing.Size(85, 17);
            this.Rb_RelatorioA.TabIndex = 0;
            this.Rb_RelatorioA.TabStop = true;
            this.Rb_RelatorioA.Text = "radioButton1";
            this.Rb_RelatorioA.UseVisualStyleBackColor = true;
            // 
            // Rb_RelatorioB
            // 
            this.Rb_RelatorioB.AutoSize = true;
            this.Rb_RelatorioB.Location = new System.Drawing.Point(13, 104);
            this.Rb_RelatorioB.Name = "Rb_RelatorioB";
            this.Rb_RelatorioB.Size = new System.Drawing.Size(85, 17);
            this.Rb_RelatorioB.TabIndex = 1;
            this.Rb_RelatorioB.TabStop = true;
            this.Rb_RelatorioB.Text = "radioButton2";
            this.Rb_RelatorioB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escolha o tipo de Relatótio";
            // 
            // btn_Gerar
            // 
            this.btn_Gerar.Location = new System.Drawing.Point(270, 140);
            this.btn_Gerar.Name = "btn_Gerar";
            this.btn_Gerar.Size = new System.Drawing.Size(75, 23);
            this.btn_Gerar.TabIndex = 3;
            this.btn_Gerar.Text = "Gerar";
            this.btn_Gerar.UseVisualStyleBackColor = true;
            this.btn_Gerar.Click += new System.EventHandler(this.btn_Gerar_Click);
            // 
            // ReportOptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 175);
            this.Controls.Add(this.btn_Gerar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rb_RelatorioB);
            this.Controls.Add(this.Rb_RelatorioA);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportOptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios";
            this.Load += new System.EventHandler(this.ReportOptionDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Rb_RelatorioA;
        private System.Windows.Forms.RadioButton Rb_RelatorioB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Gerar;
    }
}