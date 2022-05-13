using FluentValidation.Results;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.ModuloMateria;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private RepositorioDisciplinaEmArquivo _repositorioDisciplina;
        private RepositorioMateriaEmArquivo _repositorioMateria;

        private TabelaDisciplinasControl? tabelaDisciplinas;

        public ControladorDisciplina(RepositorioDisciplinaEmArquivo repositorioDisciplina, RepositorioMateriaEmArquivo repositorioMateria)
        {
            this._repositorioDisciplina = repositorioDisciplina;
            this._repositorioMateria = repositorioMateria;
        }

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

            tela.Disciplina = disciplinaSelecionada.Clone();

            tela.GravarRegistro = _repositorioDisciplina.Editar;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if (res == DialogResult.OK)
                CarregarDisciplinas();
        }
        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            List<Materia> materias = _repositorioMateria.ObterRegistros();
            List<Disciplina> disciplinasComMaterias = new List<Disciplina>();
            foreach (var materia in materias)
            {
                disciplinasComMaterias.Add(materia.Disciplina);
            }
            foreach (var item in disciplinasComMaterias)
            {
                if (item == disciplinaSelecionada)
                {
                    TelaPrincipalForm.Instancia!.AtualizarRodape("Esta disciplina não pode ser excluída pois está atrelada a alguma matéria");
                    return;
                }
            }
            
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
    }
}
