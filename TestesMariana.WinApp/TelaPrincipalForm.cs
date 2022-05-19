using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Infra.Arquivos.Compartilhado;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.ModuloMateria;
using TestesMariana.Infra.Arquivos.ModuloQuestao;
using TestesMariana.Infra.Arquivos.ModuloTeste;
using TestesMariana.Infra.BancoDeDados;
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
            var repositorioDisciplina = new RepositorioDiscplinaEmBancoDeDados();
            var repositorioMateria = new RepositorioMateriaEmBancoDeDados();
            var repositorioQuestao = new RepositorioQuestaoEmArquivo(contextoDados);
            var repositorioTeste = new RepositorioTesteEmArquivo(contextoDados);

            // AQUI
            var repositorioDisciplina2 = new RepositorioDiscplinaEmBancoDeDados();
            //

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Disciplinas", new ControladorDisciplina(repositorioDisciplina2, repositorioMateria));
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
        }

        private void ConfigurarTooltips(ConfigToolboxBase config) //Pega status de cada config das classes específicas [TOOLTIP]
        {
            buttonInserir.ToolTipText = config.toolStripButtonInserir;
            buttonEditar.ToolTipText = config.toolStripButtonEditar;
            buttonExcluir.ToolTipText = config.toolStripButtonExcluir;
            buttonExportarPDF.ToolTipText = config.toolStripButtonExportarPDF;
            buttonDuplicar.ToolTipText = config.toolStripButtonDuplicar;
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

        }
        private void buttonDuplicar_ButtonClick(object sender, EventArgs e)
        {

        }


        #endregion

    }
}
