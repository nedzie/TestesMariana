using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Infra.BancoDeDados.ModuloDisciplina;
using TestesMariana.Infra.BancoDeDados.ModuloMateria;
using TestesMariana.Infra.BancoDeDados.ModuloQuestao;
using TestesMariana.Infra.BancoDeDados.ModuloTeste;
using TestesMariana.WinApp.Compartilhado;
using TestesMariana.WinApp.ModuloDisciplina;
using TestesMariana.WinApp.ModuloMateria;
using TestesMariana.WinApp.ModuloQuestao;
using TestesMariana.WinApp.ModuloTeste;

namespace TestesMariana.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase? controlador;
        private Dictionary<string, ControladorBase>? controladores;
        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            toolStripLabelTipo.Text = string.Empty;

            InicializarControladores();
        }

        private void InicializarControladores()
        {
            var repositorioDisciplina = new RepositorioDisciplinaEmBancoDeDados();
            var repositorioMateria = new RepositorioMateriaEmBancoDeDados();
            var repositorioQuestao = new RepositorioQuestaoEmBancoDeDados();
            var repositorioTeste = new RepositorioTesteEmBancoDeDados(repositorioQuestao);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Disciplinas", new ControladorDisciplina(repositorioDisciplina, repositorioMateria));
            controladores.Add("Matérias", new ControladorMateria(repositorioMateria, repositorioDisciplina));
            controladores.Add("Questões", new ControladorQuestao(repositorioQuestao, repositorioMateria, repositorioDisciplina));
            controladores.Add("Testes", new ControladorTeste(repositorioTeste, repositorioDisciplina, repositorioMateria, repositorioQuestao));
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
        private void buttonDisciplinas_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void buttonMaterias_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void buttonQuestoes_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void buttonTestes_Click(object sender, EventArgs e)
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
            buttonExportarPDF.Enabled = config.statusPDF;
            buttonDuplicar.Enabled = config.StatusDuplicar;
            buttonExportarGabarito.Enabled = config.StatusGabarito;
        }

        private void ConfigurarTooltips(ConfigToolboxBase config) //Pega status de cada config das classes específicas [TOOLTIP]
        {
            buttonInserir.ToolTipText = config.toolStripButtonInserir;
            buttonEditar.ToolTipText = config.toolStripButtonEditar;
            buttonExcluir.ToolTipText = config.toolStripButtonExcluir;
            buttonExportarPDF.ToolTipText = config.toolStripButtonExportarPDF;
            buttonDuplicar.ToolTipText = config.toolStripButtonDuplicar;
            buttonExportarGabarito.ToolTipText = config.toolStripButtonExportarGabarito;
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            controlador!.Inserir();
        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            controlador!.Editar();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            controlador!.Excluir();
        }

        private void buttonExportarPDF_Click(object sender, EventArgs e)
        {
            controlador!.ExtrairPDF();
        }
        private void buttonExportarGabarito_Click(object sender, EventArgs e)
        {
            controlador!.Gabarito();
        }
        private void buttonDuplicar_Click(object sender, EventArgs e)
        {
            controlador!.Duplicar();
        }

        #endregion

    }
}
