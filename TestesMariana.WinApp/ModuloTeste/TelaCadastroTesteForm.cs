using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloTeste;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.ModuloMateria;
using TestesMariana.Infra.Arquivos.ModuloQuestao;
using TestesMariana.Infra.Arquivos.ModuloTeste;

namespace TestesMariana.WinApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        private Teste _teste;
        private RepositorioTesteEmArquivo _repositorioTeste;
        private RepositorioDisciplinaEmArquivo _repositorioDisciplina;
        private RepositorioMateriaEmArquivo _repositorioMateria;
        private RepositorioQuestaoEmArquivo _repositorioQuestao;

        public Teste Teste
        {
            get
            {
                return _teste;
            }
            set
            {
                _teste = value;
                textBoxNumero.Text = _teste.Numero.ToString();
                textBoxNome.Text = _teste.Nome;
                comboBoxDisciplinas.SelectedItem = _teste.Disciplina;
                comboBoxMaterias.SelectedItem = _teste.Materia;
                maskedTextBoxData.Text = _teste.Data.ToString();
                textBoxQtdeQuestoes.Text = _teste.QtdeQuestoes.ToString();
            }
        }
        public TelaCadastroTesteForm(RepositorioTesteEmArquivo rt, RepositorioDisciplinaEmArquivo rd, RepositorioMateriaEmArquivo rm, RepositorioQuestaoEmArquivo rq)
        {
            InitializeComponent();
            this._repositorioTeste = rt;
            this._repositorioDisciplina = rd;
            this._repositorioMateria = rm;
            this._repositorioQuestao = rq;
            PovoarDisciplinas();
        }

        public Func<Teste, ValidationResult>? GravarRegistro { get; set; }

        public void PovoarDisciplinas()
        {
            List<Disciplina> disciplinas = _repositorioDisciplina.SelecionarTodos();
            foreach (var item in disciplinas)
                comboBoxDisciplinas.Items.Add(item);
        }

        public void PovoarMaterias(Disciplina disc)
        {
            List<Materia> materias = _repositorioMateria.SelecionarTodos();
            List<Materia> materiasEspecificas = new();

            foreach (var item in materias)
                if (item.Disciplina == disc)
                    materiasEspecificas.Add(item);

            foreach (var item in materiasEspecificas)
                comboBoxMaterias.Items.Add(item);
        }

        private void comboBoxDisciplinas_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxMaterias.Items.Clear();
            comboBoxMaterias.ResetText();
            PovoarMaterias((Disciplina)comboBoxDisciplinas.SelectedItem);
            comboBoxMaterias.Enabled = true;
        }
    }
}
