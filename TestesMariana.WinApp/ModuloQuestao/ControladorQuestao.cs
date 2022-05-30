using FluentValidation.Results;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;
using TestesMariana.Infra.BancoDeDados.ModuloDisciplina;
using TestesMariana.Infra.BancoDeDados.ModuloMateria;
using TestesMariana.Infra.BancoDeDados.ModuloQuestao;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private RepositorioQuestaoEmBancoDeDados _repositorioQuestao;
        private RepositorioMateriaEmBancoDeDados _repositorioMateria;
        private RepositorioDisciplinaEmBancoDeDados _repositorioDisciplina;

        private TabelaQuestaoControl _tabelaQuestao;

        public ControladorQuestao(RepositorioQuestaoEmBancoDeDados repositorioQuestao, RepositorioMateriaEmBancoDeDados repositorioMateria, RepositorioDisciplinaEmBancoDeDados repositorioDisciplina)
        {
            this._repositorioQuestao = repositorioQuestao;
            this._repositorioMateria = repositorioMateria;
            this._repositorioDisciplina = repositorioDisciplina;
        }


        public override void Inserir()
        {
            List<Disciplina> disciplinas = _repositorioDisciplina.SelecionarTodos();
            List<Materia> materias = _repositorioMateria.SelecionarTodos();

            TelaCadastroQuestaoForm tela = new(disciplinas, materias);

            tela.Questao = new Questao();
            tela.GravarRegistro = _repositorioQuestao.Inserir;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroQuestaoForm'

            if (res == DialogResult.OK)
                CarregarQuestoes();
        }

        public override void Editar()
        {
            List<Disciplina> disciplinas = _repositorioDisciplina.SelecionarTodos();
            List<Materia> materias = _repositorioMateria.SelecionarTodos();

            TelaCadastroQuestaoForm tela = new(disciplinas, materias);

            Questao questaoSelecionada = ObtemQuestaoSelecionada();

            if (questaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Selecione uma questão!");
                return;
            }
            tela.Questao = questaoSelecionada.Clone();

            tela.GravarRegistro = _repositorioQuestao.Editar;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if (res == DialogResult.OK)
                CarregarQuestoes();
        }
        public override void Excluir()
        {
            Questao questaoSelecionada = ObtemQuestaoSelecionada();

            if (questaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Selecione uma questão!");
                return;
            }

            DialogResult res = MessageBox.Show("Excluir questão?",
                "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                ValidationResult deuCerto = _repositorioQuestao.Excluir(questaoSelecionada);
                if (deuCerto.IsValid)
                    CarregarQuestoes();
            }

        }

        public override ConfigToolboxBase ObtemConfiguracaoToolbox() // Responsável por carregar o padrão da tela
        {
            return new ConfigToolboxQuestao();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaQuestao == null)
                _tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return _tabelaQuestao;
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = _repositorioQuestao.SelecionarTodos();
            _tabelaQuestao!.AtualizarRegistros(questoes);

            TelaPrincipalForm.Instancia!.AtualizarRodape(questoes.Count > 1 ? $"Visualizando {questoes.Count} questões" : $"Visualizando {questoes.Count} questão");
        }

        private Questao ObtemQuestaoSelecionada()
        {
            var numero = _tabelaQuestao!.ObtemNumeroMateriaSelecionada();
            return _repositorioQuestao.SelecionarPorNumero(numero);
        }
    }
}
