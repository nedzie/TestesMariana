namespace TestesMariana.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripContextoGeral = new System.Windows.Forms.MenuStrip();
            this.menuStripCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDisciplinas = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonQuestoes = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTestes = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContextoGeral = new System.Windows.Forms.Panel();
            this.toolStripToolbox = new System.Windows.Forms.ToolStrip();
            this.buttonInserir = new System.Windows.Forms.ToolStripButton();
            this.buttonEditar = new System.Windows.Forms.ToolStripButton();
            this.buttonExcluir = new System.Windows.Forms.ToolStripButton();
            this.buttonExportarPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelTipo = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripContextoGeral.SuspendLayout();
            this.toolStripToolbox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripContextoGeral
            // 
            this.menuStripContextoGeral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripCadastros});
            this.menuStripContextoGeral.Location = new System.Drawing.Point(0, 0);
            this.menuStripContextoGeral.Name = "menuStripContextoGeral";
            this.menuStripContextoGeral.Size = new System.Drawing.Size(710, 24);
            this.menuStripContextoGeral.TabIndex = 2;
            this.menuStripContextoGeral.Text = "Menu";
            // 
            // menuStripCadastros
            // 
            this.menuStripCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDisciplinas,
            this.buttonMaterias,
            this.buttonQuestoes,
            this.buttonTestes});
            this.menuStripCadastros.Name = "menuStripCadastros";
            this.menuStripCadastros.Size = new System.Drawing.Size(50, 20);
            this.menuStripCadastros.Text = "Menu";
            // 
            // buttonDisciplinas
            // 
            this.buttonDisciplinas.Name = "buttonDisciplinas";
            this.buttonDisciplinas.Size = new System.Drawing.Size(130, 22);
            this.buttonDisciplinas.Text = "Disciplinas";
            this.buttonDisciplinas.Click += new System.EventHandler(this.toolStripMenuItemDisciplinas_Click);
            // 
            // buttonMaterias
            // 
            this.buttonMaterias.Name = "buttonMaterias";
            this.buttonMaterias.Size = new System.Drawing.Size(130, 22);
            this.buttonMaterias.Text = "Matérias";
            // 
            // buttonQuestoes
            // 
            this.buttonQuestoes.Name = "buttonQuestoes";
            this.buttonQuestoes.Size = new System.Drawing.Size(130, 22);
            this.buttonQuestoes.Text = "Questões";
            // 
            // buttonTestes
            // 
            this.buttonTestes.Name = "buttonTestes";
            this.buttonTestes.Size = new System.Drawing.Size(130, 22);
            this.buttonTestes.Text = "Testes";
            // 
            // panelContextoGeral
            // 
            this.panelContextoGeral.Location = new System.Drawing.Point(0, 58);
            this.panelContextoGeral.Name = "panelContextoGeral";
            this.panelContextoGeral.Size = new System.Drawing.Size(710, 457);
            this.panelContextoGeral.TabIndex = 3;
            // 
            // toolStripToolbox
            // 
            this.toolStripToolbox.Enabled = false;
            this.toolStripToolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonInserir,
            this.buttonEditar,
            this.buttonExcluir,
            this.buttonExportarPDF,
            this.toolStripLabelTipo});
            this.toolStripToolbox.Location = new System.Drawing.Point(0, 24);
            this.toolStripToolbox.Name = "toolStripToolbox";
            this.toolStripToolbox.Size = new System.Drawing.Size(710, 31);
            this.toolStripToolbox.TabIndex = 0;
            this.toolStripToolbox.Text = "toolStrip1";
            // 
            // buttonInserir
            // 
            this.buttonInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonInserir.Image = global::TestesMariana.WinApp.Properties.Resources.outline_add_box_black_24dp;
            this.buttonInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(28, 28);
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditar.Image = global::TestesMariana.WinApp.Properties.Resources.outline_edit_black_24dp;
            this.buttonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(28, 28);
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExcluir.Image = global::TestesMariana.WinApp.Properties.Resources.outline_delete_forever_black_24dp;
            this.buttonExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(28, 28);
            this.buttonExcluir.Text = "Deletar";
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonExportarPDF
            // 
            this.buttonExportarPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExportarPDF.Image = global::TestesMariana.WinApp.Properties.Resources.outline_picture_as_pdf_black_24dp;
            this.buttonExportarPDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonExportarPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExportarPDF.Name = "buttonExportarPDF";
            this.buttonExportarPDF.Size = new System.Drawing.Size(28, 28);
            this.buttonExportarPDF.Click += new System.EventHandler(this.toolStripButtonExportarPDF_Click);
            // 
            // toolStripLabelTipo
            // 
            this.toolStripLabelTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toolStripLabelTipo.Name = "toolStripLabelTipo";
            this.toolStripLabelTipo.Size = new System.Drawing.Size(106, 28);
            this.toolStripLabelTipo.Text = "[Tipo do cadastro]";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(710, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(118, 17);
            this.labelRodape.Text = "toolStripStatusLabel1";
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 546);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripToolbox);
            this.Controls.Add(this.panelContextoGeral);
            this.Controls.Add(this.menuStripContextoGeral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStripContextoGeral;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaPrincipalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testes - Mariana";
            this.menuStripContextoGeral.ResumeLayout(false);
            this.menuStripContextoGeral.PerformLayout();
            this.toolStripToolbox.ResumeLayout(false);
            this.toolStripToolbox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripContextoGeral;
        private System.Windows.Forms.ToolStripMenuItem menuStripCadastros;
        private System.Windows.Forms.ToolStripMenuItem buttonDisciplinas;
        private System.Windows.Forms.ToolStripMenuItem buttonMaterias;
        private System.Windows.Forms.ToolStripMenuItem buttonQuestoes;
        private System.Windows.Forms.ToolStripMenuItem buttonTestes;
        private System.Windows.Forms.Panel panelContextoGeral;
        private System.Windows.Forms.ToolStrip toolStripToolbox;
        private System.Windows.Forms.ToolStripButton buttonInserir;
        private System.Windows.Forms.ToolStripButton buttonEditar;
        private System.Windows.Forms.ToolStripButton buttonExcluir;
        private System.Windows.Forms.ToolStripButton buttonExportarPDF;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTipo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
    }
}
