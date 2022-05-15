using FluentValidation.Results;
using System;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;

namespace TestesMariana.WinApp.ModuloQuestao
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        private Questao _questao;

        public Questao Questao
        {
            get 
            { 
                return _questao; 
            }
            set
            {
                _questao = value;
                comboBoxDisciplinas.SelectedItem = _questao.Disciplina;
                comboBoxMaterias.SelectedItem = _questao.Materia;
                textBoxEnunciado.Text = _questao.Enunciado.ToString();
                /* List de questões */
            }
        }

        public TelaCadastroQuestaoForm()
        {
            InitializeComponent();
        }

        public Func<Questao, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Questao.Enunciado = textBoxEnunciado.Text.ToString();
            Questao.Disciplina = (Disciplina)comboBoxDisciplinas.SelectedItem;
            Questao.Materia = (Materia)comboBoxMaterias.SelectedItem;

            /* List questões */

            var resultadoValidacao = GravarRegistro!(Questao); // _repositorioDisciplina.Inserir();

            if (!resultadoValidacao.IsValid)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
