namespace TestesMariana.WinApp.ModuloTeste
{
    partial class TelaCadastroTesteForm
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
            this.comboBoxMaterias = new System.Windows.Forms.ComboBox();
            this.labelMateria = new System.Windows.Forms.Label();
            this.labelDisciplina = new System.Windows.Forms.Label();
            this.comboBoxDisciplinas = new System.Windows.Forms.ComboBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textBoxQtdeQuestoes = new System.Windows.Forms.TextBox();
            this.labelQtdQuestoes = new System.Windows.Forms.Label();
            this.listBoxQuestoes = new System.Windows.Forms.ListBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.maskedTextBoxData = new System.Windows.Forms.MaskedTextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.checkBoxRecuperacao = new System.Windows.Forms.CheckBox();
            this.buttonQuestoes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxMaterias
            // 
            this.comboBoxMaterias.Enabled = false;
            this.comboBoxMaterias.FormattingEnabled = true;
            this.comboBoxMaterias.Location = new System.Drawing.Point(72, 66);
            this.comboBoxMaterias.Name = "comboBoxMaterias";
            this.comboBoxMaterias.Size = new System.Drawing.Size(147, 23);
            this.comboBoxMaterias.TabIndex = 40;
            this.comboBoxMaterias.SelectedValueChanged += new System.EventHandler(this.comboBoxMaterias_SelectedValueChanged);
            // 
            // labelMateria
            // 
            this.labelMateria.AutoSize = true;
            this.labelMateria.Location = new System.Drawing.Point(16, 69);
            this.labelMateria.Name = "labelMateria";
            this.labelMateria.Size = new System.Drawing.Size(50, 15);
            this.labelMateria.TabIndex = 39;
            this.labelMateria.Text = "Matéria:";
            // 
            // labelDisciplina
            // 
            this.labelDisciplina.AutoSize = true;
            this.labelDisciplina.Location = new System.Drawing.Point(5, 37);
            this.labelDisciplina.Name = "labelDisciplina";
            this.labelDisciplina.Size = new System.Drawing.Size(61, 15);
            this.labelDisciplina.TabIndex = 38;
            this.labelDisciplina.Text = "Disciplina:";
            // 
            // comboBoxDisciplinas
            // 
            this.comboBoxDisciplinas.FormattingEnabled = true;
            this.comboBoxDisciplinas.Location = new System.Drawing.Point(72, 34);
            this.comboBoxDisciplinas.Name = "comboBoxDisciplinas";
            this.comboBoxDisciplinas.Size = new System.Drawing.Size(147, 23);
            this.comboBoxDisciplinas.TabIndex = 37;
            this.comboBoxDisciplinas.SelectedValueChanged += new System.EventHandler(this.comboBoxDisciplinas_SelectedValueChanged);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.FlatAppearance.BorderSize = 0;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Location = new System.Drawing.Point(246, 568);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 36;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // buttonGravar
            // 
            this.buttonGravar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.FlatAppearance.BorderSize = 0;
            this.buttonGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravar.Location = new System.Drawing.Point(163, 568);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 35;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = false;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Enabled = false;
            this.textBoxNumero.Location = new System.Drawing.Point(72, 6);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(55, 23);
            this.textBoxNumero.TabIndex = 34;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(12, 9);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(54, 15);
            this.labelNumero.TabIndex = 33;
            this.labelNumero.Text = "Número:";
            // 
            // textBoxQtdeQuestoes
            // 
            this.textBoxQtdeQuestoes.Location = new System.Drawing.Point(120, 157);
            this.textBoxQtdeQuestoes.Name = "textBoxQtdeQuestoes";
            this.textBoxQtdeQuestoes.Size = new System.Drawing.Size(80, 23);
            this.textBoxQtdeQuestoes.TabIndex = 42;
            // 
            // labelQtdQuestoes
            // 
            this.labelQtdQuestoes.AutoSize = true;
            this.labelQtdQuestoes.Location = new System.Drawing.Point(12, 160);
            this.labelQtdQuestoes.Name = "labelQtdQuestoes";
            this.labelQtdQuestoes.Size = new System.Drawing.Size(102, 15);
            this.labelQtdQuestoes.TabIndex = 41;
            this.labelQtdQuestoes.Text = "Qtde de questões:";
            // 
            // listBoxQuestoes
            // 
            this.listBoxQuestoes.FormattingEnabled = true;
            this.listBoxQuestoes.ItemHeight = 15;
            this.listBoxQuestoes.Location = new System.Drawing.Point(12, 197);
            this.listBoxQuestoes.Name = "listBoxQuestoes";
            this.listBoxQuestoes.Size = new System.Drawing.Size(309, 364);
            this.listBoxQuestoes.TabIndex = 43;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(72, 95);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(249, 23);
            this.textBoxNome.TabIndex = 45;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(23, 98);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 44;
            this.labelNome.Text = "Nome:";
            // 
            // maskedTextBoxData
            // 
            this.maskedTextBoxData.Location = new System.Drawing.Point(75, 124);
            this.maskedTextBoxData.Mask = "00/00/0000";
            this.maskedTextBoxData.Name = "maskedTextBoxData";
            this.maskedTextBoxData.Size = new System.Drawing.Size(89, 23);
            this.maskedTextBoxData.TabIndex = 46;
            this.maskedTextBoxData.ValidatingType = typeof(System.DateTime);
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(32, 127);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(34, 15);
            this.labelData.TabIndex = 47;
            this.labelData.Text = "Data:";
            // 
            // checkBoxRecuperacao
            // 
            this.checkBoxRecuperacao.AutoSize = true;
            this.checkBoxRecuperacao.Location = new System.Drawing.Point(222, 159);
            this.checkBoxRecuperacao.Name = "checkBoxRecuperacao";
            this.checkBoxRecuperacao.Size = new System.Drawing.Size(99, 19);
            this.checkBoxRecuperacao.TabIndex = 48;
            this.checkBoxRecuperacao.Text = "Recuperação?";
            this.checkBoxRecuperacao.UseVisualStyleBackColor = true;
            // 
            // buttonQuestoes
            // 
            this.buttonQuestoes.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonQuestoes.FlatAppearance.BorderSize = 0;
            this.buttonQuestoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuestoes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonQuestoes.Location = new System.Drawing.Point(12, 568);
            this.buttonQuestoes.Name = "buttonQuestoes";
            this.buttonQuestoes.Size = new System.Drawing.Size(92, 23);
            this.buttonQuestoes.TabIndex = 49;
            this.buttonQuestoes.Text = "Povoar";
            this.buttonQuestoes.UseVisualStyleBackColor = false;
            this.buttonQuestoes.Click += new System.EventHandler(this.buttonQuestoes_Click);
            // 
            // TelaCadastroTesteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 603);
            this.Controls.Add(this.buttonQuestoes);
            this.Controls.Add(this.checkBoxRecuperacao);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.maskedTextBoxData);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.listBoxQuestoes);
            this.Controls.Add(this.textBoxQtdeQuestoes);
            this.Controls.Add(this.labelQtdQuestoes);
            this.Controls.Add(this.comboBoxMaterias);
            this.Controls.Add(this.labelMateria);
            this.Controls.Add(this.labelDisciplina);
            this.Controls.Add(this.comboBoxDisciplinas);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.textBoxNumero);
            this.Controls.Add(this.labelNumero);
            this.Name = "TelaCadastroTesteForm";
            this.Text = "TelaCadastroTesteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMaterias;
        private System.Windows.Forms.Label labelMateria;
        private System.Windows.Forms.Label labelDisciplina;
        private System.Windows.Forms.ComboBox comboBoxDisciplinas;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.TextBox textBoxNumero;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.TextBox textBoxQtdeQuestoes;
        private System.Windows.Forms.Label labelQtdQuestoes;
        private System.Windows.Forms.ListBox listBoxQuestoes;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxData;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.CheckBox checkBoxRecuperacao;
        private System.Windows.Forms.Button buttonQuestoes;
    }
}