using FluentValidation.Results;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;
using TestesMariana.Dominio.ModuloTeste;
using TestesMariana.Infra.BancoDeDados.ModuloDisciplina;
using TestesMariana.Infra.BancoDeDados.ModuloMateria;
using TestesMariana.Infra.BancoDeDados.ModuloQuestao;
using TestesMariana.Infra.BancoDeDados.ModuloTeste;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private RepositorioTesteEmBancoDeDados _repositorioTeste;
        private RepositorioDisciplinaEmBancoDeDados _repositorioDisciplina;
        private RepositorioMateriaEmBancoDeDados _repositorioMateria;
        private RepositorioQuestaoEmBancoDeDados _repositorioQuestao;

        private TabelaTesteControl _tabelaTeste;

        public ControladorTeste(RepositorioTesteEmBancoDeDados rt, RepositorioDisciplinaEmBancoDeDados rd, RepositorioMateriaEmBancoDeDados rm, RepositorioQuestaoEmBancoDeDados rq)
        {
            this._repositorioTeste = rt;
            this._repositorioDisciplina = rd;
            this._repositorioMateria = rm;
            this._repositorioQuestao = rq;
        }

        public override void Inserir()
        {
            List<Disciplina> Disciplinas = _repositorioDisciplina.SelecionarTodos();
            List<Materia> Materias = _repositorioMateria.SelecionarTodos();
            List<Questao> Questoes = _repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new(Disciplinas, Materias, Questoes);

            tela.Teste = new();
            tela.GravarRegistro = _repositorioTeste.Inserir;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroQuestaoForm'

            if (res == DialogResult.OK)
                CarregarQuestoes();
        }

        public override void Editar()
        {
            List<Teste> testes = _repositorioTeste.SelecionarTodos();
            List<Disciplina> Disciplinas = _repositorioDisciplina.SelecionarTodos();
            List<Materia> Materias = _repositorioMateria.SelecionarTodos();
            List<Questao> Questoes = _repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new(Disciplinas, Materias, Questoes);

            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Selecione um teste!");
                return;
            }
            tela.Teste = testeSelecionado.Clone();

            tela.GravarRegistro = _repositorioTeste.Editar;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if (res == DialogResult.OK)
                CarregarQuestoes();
        }
        public override void Excluir()
        {
            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Selecione um teste!");
                return;
            }

            DialogResult res = MessageBox.Show("Excluir teste?",
                "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                ValidationResult deuCerto = _repositorioTeste.Excluir(testeSelecionado);
                if (deuCerto.IsValid)
                    CarregarQuestoes();
            }

        }

        public override void Duplicar()
        {
            Teste testeParaDuplicar = ObtemTesteSelecionado();

            _repositorioTeste.Duplicar(testeParaDuplicar);
        }

        public override ConfigToolboxBase ObtemConfiguracaoToolbox() // Responsável por carregar o padrão da tela
        {
            return new ConfigToolboxTeste();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaTeste == null)
                _tabelaTeste = new TabelaTesteControl();

            CarregarQuestoes();

            return _tabelaTeste;
        }

        private void CarregarQuestoes()
        {
            List<Teste> questoes = _repositorioTeste.SelecionarTodos();
            _tabelaTeste!.AtualizarRegistros(questoes);

            TelaPrincipalForm.Instancia!.AtualizarRodape(questoes.Count > 1 ? $"Visualizando {questoes.Count} testes." : $"Visualizando {questoes.Count} testes.");
        }

        private Teste ObtemTesteSelecionado()
        {
            var numero = _tabelaTeste!.ObtemNumeroMateriaSelecionada();
            return _repositorioTeste.SelecionarPorNumero(numero);
        }
    }
}
