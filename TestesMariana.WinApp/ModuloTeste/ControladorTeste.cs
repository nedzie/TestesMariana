using FluentValidation.Results;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloTeste;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.ModuloMateria;
using TestesMariana.Infra.Arquivos.ModuloQuestao;
using TestesMariana.Infra.Arquivos.ModuloTeste;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private RepositorioTesteEmArquivo _repositorioTeste;
        private RepositorioDisciplinaEmArquivo _repositorioDisciplina;
        private RepositorioMateriaEmArquivo _repositorioMateria;
        private RepositorioQuestaoEmArquivo _repositorioQuestao;

        private TabelaTesteControl _tabelaTeste;

        public ControladorTeste(RepositorioTesteEmArquivo rt,RepositorioDisciplinaEmArquivo rd, RepositorioMateriaEmArquivo rm, RepositorioQuestaoEmArquivo rq)
        {
            this._repositorioTeste = rt;
            this._repositorioDisciplina = rd;
            this._repositorioMateria = rm;
            this._repositorioQuestao = rq;
        }

        public override void Inserir()
        {
            TelaCadastroTesteForm tela = new(_repositorioTeste, _repositorioDisciplina, _repositorioMateria, _repositorioQuestao);

            tela.Teste = new();
            tela.GravarRegistro = _repositorioTeste.Inserir;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroQuestaoForm'

            if (res == DialogResult.OK)
                CarregarQuestoes();
        }

        public override void Editar()
        {
            List<Teste> testes = _repositorioTeste.ObterRegistros();
            TelaCadastroTesteForm tela = new(_repositorioTeste, _repositorioDisciplina, _repositorioMateria, _repositorioQuestao);

            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Selecione uma questão!");
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
                TelaPrincipalForm.Instancia!.AtualizarRodape("Selecione uma questão!");
                return;
            }

            DialogResult res = MessageBox.Show("Excluir questão?",
                "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                ValidationResult deuCerto = _repositorioTeste.Excluir(testeSelecionado);
                if (deuCerto.IsValid)
                    CarregarQuestoes();
            }

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

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {questoes.Count} questão(ões)");
        }

        private Teste ObtemTesteSelecionado()
        {
            var numero = _tabelaTeste!.ObtemNumeroMateriaSelecionada();
            return _repositorioTeste.SelecionarPorNumero(numero);
        }
    }
}
