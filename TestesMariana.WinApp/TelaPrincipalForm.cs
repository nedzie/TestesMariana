using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Infra.Arquivos.Compartilhado;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.WinApp.Compartilhado;
using TestesMariana.WinApp.ModuloDisciplina;

namespace TestesMariana.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase? controlador;
        private Dictionary<string, ControladorBase>? controladores;
        private DataContext? contextoDados;
        public TelaPrincipalForm(DataContext contextoDados)
        {
            InitializeComponent();
            this.contextoDados = contextoDados;

            Instancia = this;

            labelRodape.Text = string.Empty;
            toolStripLabelTipo.Text = string.Empty;

            InicializarControladores();
        }

        private void InicializarControladores()
        {
            var repositorioDisciplina = new RepositorioDisciplinaEmArquivo(contextoDados);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Disciplinas", new ControladorDisciplina(repositorioDisciplina));
        }

        public static TelaPrincipalForm? Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }
        #region Alterações aqui precisam ser atualizadas no ConfigToolboxBase.cs
        private void toolStripMenuItemDisciplinas_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem escolha)
        {
            string tipo = escolha.Text;
            controlador = controladores![tipo];

            ConfigurarToolbox();
            ConfigurarListagem();
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador!.ObtemListagem();

            panelContextoGeral.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelContextoGeral.Controls.Add(listagemControl);
        }

        private void ConfigurarToolbox()
        {
            ConfigToolboxBase config = controlador!.ObtemConfiguracaoToolbox();
            if (config != null)
            {
                toolStripToolbox.Enabled = true;

                toolStripLabelTipo.Text = config.TipoCadastro;

                ConfigurarTooltips(config);

                ConfigurarBotoes(config);
            }
        }

        private void ConfigurarBotoes(ConfigToolboxBase config) // Pega status de cada config das classes específicas [BOTÕES]
        {
            buttonInserir.Enabled = config.StatusInserir;
            buttonEditar.Enabled = config.StatusEditar;
            buttonExcluir.Enabled = config.StatusExcluir;
        }

        private void ConfigurarTooltips(ConfigToolboxBase config) //Pega status de cada config das classes específicas [TOOLTIP]
        {
            buttonInserir.ToolTipText = config.toolStripButtonInserir;
            buttonEditar.ToolTipText = config.toolStripButtonEditar;
            buttonExcluir.ToolTipText = config.toolStripButtonExcluir;
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            controlador!.Inserir();
        }
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            controlador!.Editar();
        }

        private void toolStripButtonDeletar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonExportarPDF_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
