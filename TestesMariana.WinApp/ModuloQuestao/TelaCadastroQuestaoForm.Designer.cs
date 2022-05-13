namespace TestesMariana.WinApp.ModuloQuestao
{
    partial class TelaCadastroQuestaoForm
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
            this.comboBoxSeries = new System.Windows.Forms.ComboBox();
            this.labelMateria = new System.Windows.Forms.Label();
            this.labelDisciplina = new System.Windows.Forms.Label();
            this.comboBoxDisciplinas = new System.Windows.Forms.ComboBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelEnunciado = new System.Windows.Forms.Label();
            this.checkedListBoxAlternativas = new System.Windows.Forms.CheckedListBox();
            this.labelAlternativas = new System.Windows.Forms.Label();
            this.labelCorreta = new System.Windows.Forms.Label();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxSeries
            // 
            this.comboBoxSeries.FormattingEnabled = true;
            this.comboBoxSeries.Items.AddRange(new object[] {
            "1ª Série",
            "2ª Série"});
            this.comboBoxSeries.Location = new System.Drawing.Point(94, 66);
            this.comboBoxSeries.Name = "comboBoxSeries";
            this.comboBoxSeries.Size = new System.Drawing.Size(147, 23);
            this.comboBoxSeries.TabIndex = 25;
            // 
            // labelMateria
            // 
            this.labelMateria.AutoSize = true;
            this.labelMateria.Location = new System.Drawing.Point(38, 69);
            this.labelMateria.Name = "labelMateria";
            this.labelMateria.Size = new System.Drawing.Size(50, 15);
            this.labelMateria.TabIndex = 24;
            this.labelMateria.Text = "Matéria:";
            // 
            // labelDisciplina
            // 
            this.labelDisciplina.AutoSize = true;
            this.labelDisciplina.Location = new System.Drawing.Point(27, 37);
            this.labelDisciplina.Name = "labelDisciplina";
            this.labelDisciplina.Size = new System.Drawing.Size(61, 15);
            this.labelDisciplina.TabIndex = 23;
            this.labelDisciplina.Text = "Disciplina:";
            // 
            // comboBoxDisciplinas
            // 
            this.comboBoxDisciplinas.FormattingEnabled = true;
            this.comboBoxDisciplinas.Location = new System.Drawing.Point(94, 34);
            this.comboBoxDisciplinas.Name = "comboBoxDisciplinas";
            this.comboBoxDisciplinas.Size = new System.Drawing.Size(147, 23);
            this.comboBoxDisciplinas.TabIndex = 22;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.FlatAppearance.BorderSize = 0;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Location = new System.Drawing.Point(99, 367);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 21;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // buttonGravar
            // 
            this.buttonGravar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.FlatAppearance.BorderSize = 0;
            this.buttonGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravar.Location = new System.Drawing.Point(16, 367);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 20;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = false;
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Enabled = false;
            this.textBoxNumero.Location = new System.Drawing.Point(94, 6);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(55, 23);
            this.textBoxNumero.TabIndex = 19;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(34, 9);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(54, 15);
            this.labelNumero.TabIndex = 18;
            this.labelNumero.Text = "Número:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(94, 98);
            this.textBoxNome.Multiline = true;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(147, 109);
            this.textBoxNome.TabIndex = 17;
            // 
            // labelEnunciado
            // 
            this.labelEnunciado.AutoSize = true;
            this.labelEnunciado.Location = new System.Drawing.Point(45, 98);
            this.labelEnunciado.Name = "labelEnunciado";
            this.labelEnunciado.Size = new System.Drawing.Size(43, 15);
            this.labelEnunciado.TabIndex = 16;
            this.labelEnunciado.Text = "Nome:";
            // 
            // checkedListBoxAlternativas
            // 
            this.checkedListBoxAlternativas.FormattingEnabled = true;
            this.checkedListBoxAlternativas.Location = new System.Drawing.Point(16, 239);
            this.checkedListBoxAlternativas.Name = "checkedListBoxAlternativas";
            this.checkedListBoxAlternativas.Size = new System.Drawing.Size(176, 94);
            this.checkedListBoxAlternativas.TabIndex = 26;
            // 
            // labelAlternativas
            // 
            this.labelAlternativas.AutoSize = true;
            this.labelAlternativas.Location = new System.Drawing.Point(16, 221);
            this.labelAlternativas.Name = "labelAlternativas";
            this.labelAlternativas.Size = new System.Drawing.Size(72, 15);
            this.labelAlternativas.TabIndex = 27;
            this.labelAlternativas.Text = "Alternativas:";
            // 
            // labelCorreta
            // 
            this.labelCorreta.AutoSize = true;
            this.labelCorreta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelCorreta.Location = new System.Drawing.Point(16, 336);
            this.labelCorreta.Name = "labelCorreta";
            this.labelCorreta.Size = new System.Drawing.Size(210, 15);
            this.labelCorreta.TabIndex = 28;
            this.labelCorreta.Text = "*Marque na caixa a alternativa correta";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAdicionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAdicionar.FlatAppearance.BorderSize = 0;
            this.buttonAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdicionar.Location = new System.Drawing.Point(198, 239);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(75, 23);
            this.buttonAdicionar.TabIndex = 29;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            // 
            // TelaCadastroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 407);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.labelCorreta);
            this.Controls.Add(this.labelAlternativas);
            this.Controls.Add(this.checkedListBoxAlternativas);
            this.Controls.Add(this.comboBoxSeries);
            this.Controls.Add(this.labelMateria);
            this.Controls.Add(this.labelDisciplina);
            this.Controls.Add(this.comboBoxDisciplinas);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.textBoxNumero);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelEnunciado);
            this.Name = "TelaCadastroQuestaoForm";
            this.Text = "TelaCadastroQuestaoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSeries;
        private System.Windows.Forms.Label labelMateria;
        private System.Windows.Forms.Label labelDisciplina;
        private System.Windows.Forms.ComboBox comboBoxDisciplinas;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.TextBox textBoxNumero;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelEnunciado;
        private System.Windows.Forms.CheckedListBox checkedListBoxAlternativas;
        private System.Windows.Forms.Label labelAlternativas;
        private System.Windows.Forms.Label labelCorreta;
        private System.Windows.Forms.Button buttonAdicionar;
    }
}