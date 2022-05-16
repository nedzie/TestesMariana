namespace TestesMariana.WinApp.ModuloMateria
{
    partial class TelaCadastroMateriaForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.comboBoxDisciplinas = new System.Windows.Forms.ComboBox();
            this.labelDisciplina = new System.Windows.Forms.Label();
            this.labelSerie = new System.Windows.Forms.Label();
            this.comboBoxSeries = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(146, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // buttonGravar
            // 
            this.buttonGravar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.FlatAppearance.BorderSize = 0;
            this.buttonGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravar.Location = new System.Drawing.Point(63, 152);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 10;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = false;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Enabled = false;
            this.textBoxNumero.Location = new System.Drawing.Point(83, 22);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(55, 23);
            this.textBoxNumero.TabIndex = 9;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(23, 25);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(54, 15);
            this.labelNumero.TabIndex = 8;
            this.labelNumero.Text = "Número:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(83, 51);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(109, 23);
            this.textBoxNome.TabIndex = 7;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(34, 55);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 6;
            this.labelNome.Text = "Nome:";
            // 
            // comboBoxDisciplinas
            // 
            this.comboBoxDisciplinas.FormattingEnabled = true;
            this.comboBoxDisciplinas.Location = new System.Drawing.Point(83, 82);
            this.comboBoxDisciplinas.Name = "comboBoxDisciplinas";
            this.comboBoxDisciplinas.Size = new System.Drawing.Size(147, 23);
            this.comboBoxDisciplinas.TabIndex = 12;
            // 
            // labelDisciplina
            // 
            this.labelDisciplina.AutoSize = true;
            this.labelDisciplina.Location = new System.Drawing.Point(16, 85);
            this.labelDisciplina.Name = "labelDisciplina";
            this.labelDisciplina.Size = new System.Drawing.Size(61, 15);
            this.labelDisciplina.TabIndex = 13;
            this.labelDisciplina.Text = "Disciplina:";
            // 
            // labelSerie
            // 
            this.labelSerie.AutoSize = true;
            this.labelSerie.Location = new System.Drawing.Point(42, 117);
            this.labelSerie.Name = "labelSerie";
            this.labelSerie.Size = new System.Drawing.Size(35, 15);
            this.labelSerie.TabIndex = 14;
            this.labelSerie.Text = "Série:";
            // 
            // comboBoxSeries
            // 
            this.comboBoxSeries.FormattingEnabled = true;
            this.comboBoxSeries.Items.AddRange(new object[] {
            "1ª Série",
            "2ª Série"});
            this.comboBoxSeries.Location = new System.Drawing.Point(83, 114);
            this.comboBoxSeries.Name = "comboBoxSeries";
            this.comboBoxSeries.Size = new System.Drawing.Size(147, 23);
            this.comboBoxSeries.TabIndex = 15;
            // 
            // TelaCadastroMateriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 196);
            this.Controls.Add(this.comboBoxSeries);
            this.Controls.Add(this.labelSerie);
            this.Controls.Add(this.labelDisciplina);
            this.Controls.Add(this.comboBoxDisciplinas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.textBoxNumero);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
            this.Name = "TelaCadastroMateriaForm";
            this.Text = "Cadastro Matéria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.TextBox textBoxNumero;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.ComboBox comboBoxDisciplinas;
        private System.Windows.Forms.Label labelDisciplina;
        private System.Windows.Forms.Label labelSerie;
        private System.Windows.Forms.ComboBox comboBoxSeries;
    }
}