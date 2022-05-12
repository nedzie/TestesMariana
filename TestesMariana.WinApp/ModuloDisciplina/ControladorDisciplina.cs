using FluentValidation.Results;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        #region Atributos
        private RepositorioDisciplinaEmArquivo _repositorioDisciplina;
        private TabelaDisciplinasControl? tabelaDisciplinas;
        #endregion


        #region CTOR
        public ControladorDisciplina(RepositorioDisciplinaEmArquivo repositorioDisciplina)
        {
            this._repositorioDisciplina = repositorioDisciplina;
        }
        #endregion


        #region Métodos públicos
        public override void Inserir()
        {
            TelaCadastroDisciplinaForm tela = new();
            tela.Disciplina = new();

            tela.GravarRegistro = _repositorioDisciplina.Inserir;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if (res == DialogResult.OK)
                CarregarDisciplinas();
        }

        public override void Editar()
        {
            TelaCadastroDisciplinaForm tela = new();

            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Seleciona uma disciplina!");
                return;
            }

            tela.Disciplina = (Disciplina)disciplinaSelecionada.Clone();

            tela.GravarRegistro = _repositorioDisciplina.Editar;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if (res == DialogResult.OK)
                CarregarDisciplinas();
        }
        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Seleciona uma disciplina!");
                return;
            }

            DialogResult res = MessageBox.Show("Excluir disciplina?",
                "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                ValidationResult deuCerto = _repositorioDisciplina.Excluir(disciplinaSelecionada);
                if (deuCerto.IsValid)
                    CarregarDisciplinas();
            }

        }

        public override ConfigToolboxBase ObtemConfiguracaoToolbox() // Responsável por carregar o padrão da tela
        {
            return new ConfigToolboxDisciplina();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaDisciplinas == null)
                tabelaDisciplinas = new TabelaDisciplinasControl();

            CarregarDisciplinas();

            return tabelaDisciplinas;
        }

        #endregion


        #region Métodos privados

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = _repositorioDisciplina.SelecionarTodos();
            tabelaDisciplinas!.AtualizarRegistros(disciplinas);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {disciplinas.Count} disciplina(s)");
        }

        private Disciplina ObtemDisciplinaSelecionada()
        {
            var numero = tabelaDisciplinas!.ObtemNumeroTarefaSelecionada();
            return _repositorioDisciplina.SelecionarPorNumero(numero);
        }

        #endregion
    }
}
