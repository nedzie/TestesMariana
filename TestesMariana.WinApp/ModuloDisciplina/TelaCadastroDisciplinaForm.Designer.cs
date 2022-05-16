namespace TestesMariana.WinApp.ModuloDisciplina
{
    partial class TelaCadastroDisciplinaForm
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
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(47, 52);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(96, 48);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(109, 23);
            this.textBoxNome.TabIndex = 1;
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Enabled = false;
            this.textBoxNumero.Location = new System.Drawing.Point(96, 19);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(55, 23);
            this.textBoxNumero.TabIndex = 3;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(36, 22);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(54, 15);
            this.labelNumero.TabIndex = 2;
            this.labelNumero.Text = "Número:";
            // 
            // buttonGravar
            // 
            this.buttonGravar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.FlatAppearance.BorderSize = 0;
            this.buttonGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravar.Location = new System.Drawing.Point(47, 95);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 4;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = false;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(130, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // TelaCadastroDisciplinaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 139);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.textBoxNumero);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
            this.Name = "TelaCadastroDisciplinaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Disciplina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxNumero;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button button1;
    }
}