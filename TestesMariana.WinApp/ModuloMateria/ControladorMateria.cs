using FluentValidation.Results;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.ModuloMateria;
using TestesMariana.WinApp.Compartilhado;
using TestesMariana.WinApp.ModuloDisciplina;

namespace TestesMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private RepositorioMateriaEmArquivo _repositorioMateria;
        private RepositorioDisciplinaEmArquivo _repositorioDisciplina;
        private TabelaMateriaControl tabelaMateria;

        public ControladorMateria(RepositorioMateriaEmArquivo repositorioMateria, RepositorioDisciplinaEmArquivo repositorioDisciplina)
        {
            this._repositorioMateria = repositorioMateria;
            this._repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            List<Disciplina> disciplinas = _repositorioDisciplina.ObterRegistros();
            TelaCadastroMateriaForm tela = new(disciplinas);

            tela.Materia = new();
            tela.GravarRegistro = _repositorioMateria.Inserir;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if (res == DialogResult.OK)
                CarregarMaterias();
        }

        public override void Editar()
        {
            List<Disciplina> disciplinas = _repositorioDisciplina.ObterRegistros();
            TelaCadastroMateriaForm tela = new(disciplinas);

            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Selecione uma matéria!");
                return;
            }
            tela.Materia = materiaSelecionada.Clone();

            tela.GravarRegistro = _repositorioMateria.Editar;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if (res == DialogResult.OK)
                CarregarMaterias();
        }
        public override void Excluir()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Selecione uma matéria!");
                return;
            }

            DialogResult res = MessageBox.Show("Excluir matéria?",
                "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                ValidationResult deuCerto = _repositorioMateria.Excluir(materiaSelecionada);
                if (deuCerto.IsValid)
                    CarregarMaterias();
            }

        }

        public override ConfigToolboxBase ObtemConfiguracaoToolbox() // Responsável por carregar o padrão da tela
        {
            return new ConfigToolboxDisciplina();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaMateria == null)
                tabelaMateria = new TabelaMateriaControl();

            CarregarMaterias();

            return tabelaMateria;
        }

        private List<Disciplina> CarregarDisciplinas()
        {
            return _repositorioDisciplina.ObterRegistros();
        }

        private void CarregarMaterias()
        {
            List<Materia> materias = _repositorioMateria.SelecionarTodos();
            tabelaMateria!.AtualizarRegistros(materias);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {materias.Count} materia(s)");
        }

        private Materia ObtemMateriaSelecionada()
        {
            var numero = tabelaMateria!.ObtemNumeroMateriaSelecionada();
            return _repositorioMateria.SelecionarPorNumero(numero);
        }
    }
}
