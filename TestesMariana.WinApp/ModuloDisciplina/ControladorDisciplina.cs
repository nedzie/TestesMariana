using FluentValidation.Results;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.ModuloMateria;
using TestesMariana.Infra.BancoDeDados;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        //private RepositorioDisciplinaEmArquivo _repositorioDisciplina;
        private RepositorioMateriaEmArquivo _repositorioMateria;

        private RepositorioDiscplinaEmBancoDeDados _repositorioDisciplinaBD;

        private TabelaDisciplinasControl? tabelaDisciplinas;

        public ControladorDisciplina(RepositorioDiscplinaEmBancoDeDados repositorioDisciplina, RepositorioMateriaEmArquivo repositorioMateria)
        {
            this._repositorioDisciplinaBD = repositorioDisciplina;
            this._repositorioMateria = repositorioMateria;
        }

        public override void Inserir()
        {
            TelaCadastroDisciplinaForm tela = new();
            tela.Disciplina = new();

            tela.GravarRegistro = _repositorioDisciplinaBD.Inserir;

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

            tela.Disciplina = disciplinaSelecionada.Clone();

            tela.GravarRegistro = _repositorioDisciplinaBD.Editar;

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
            List<Materia> materias = _repositorioMateria.ObterRegistros();
            foreach (var item in materias)
            {
                if (item.Disciplina == disciplinaSelecionada)
                {
                    TelaPrincipalForm.Instancia!.AtualizarRodape("Esta disciplina não pode ser excluída pois está atrelada a alguma matéria");
                    return;
                }
            }

            DialogResult res = MessageBox.Show("Excluir disciplina?",
                "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                ValidationResult deuCerto = _repositorioDisciplinaBD.Excluir(disciplinaSelecionada);
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

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = _repositorioDisciplinaBD.SelecionarTodos();
            tabelaDisciplinas!.AtualizarRegistros(disciplinas);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {disciplinas.Count} disciplina(s)");
        }

        private Disciplina ObtemDisciplinaSelecionada()
        {
            var numero = tabelaDisciplinas!.ObtemNumeroTarefaSelecionada();
            return _repositorioDisciplinaBD.SelecionarPorNumero(numero);
        }
    }
}
