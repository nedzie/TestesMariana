using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;

namespace TestesMariana.WinApp.ModuloMateria
{
    public partial class TelaCadastroMateriaForm : Form
    {
        private Materia _materia;
        public List<Disciplina> Disciplinas { get; set; }
        public Materia Materia
        {
            get
            {
                return _materia!;
            }
            set
            {
                _materia = value;
                textBoxNumero.Text = _materia.Numero.ToString();
                textBoxNome.Text = _materia.Nome;
                comboBoxSeries.SelectedItem = _materia.Serie;
                comboBoxDisciplinas.SelectedItem = _materia.Disciplina;
            }
        }

        public TelaCadastroMateriaForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();
            this.Disciplinas = disciplinas;
            CarregarDisciplinas();
            comboBoxSeries.SelectedIndex = 0;
        }

        private void CarregarDisciplinas()
        {
            foreach (var disciplina in Disciplinas)
            {
                comboBoxDisciplinas.Items.Add(disciplina);
            }
        }
        public Func<Materia, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Materia.Nome = textBoxNome.Text;
            Materia.Disciplina = (Disciplina)comboBoxDisciplinas.SelectedItem;
            Materia.Serie = (SerieEnum)comboBoxSeries.SelectedIndex;

            var resultadoValidacao = GravarRegistro!(Materia); // _repositorioDisciplina.Inserir();

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
