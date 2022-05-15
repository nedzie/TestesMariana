using FluentValidation.Results;
using System;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;

namespace TestesMariana.WinApp.ModuloDisciplina
{
    public partial class TelaCadastroDisciplinaForm : Form
    {
        private Disciplina? _disciplina;
        public Disciplina Disciplina
        {
            get
            {
                return _disciplina!;
            }
            set
            {
                _disciplina = value;
                textBoxNumero.Text = _disciplina.Numero.ToString();
                textBoxNome.Text = _disciplina.Nome;
            }
        }

        public TelaCadastroDisciplinaForm()
        {
            InitializeComponent();
        }

        public Func<Disciplina, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Disciplina.Nome = textBoxNome.Text;

            var resultadoValidacao = GravarRegistro!(Disciplina); // _repositorioDisciplina.Inserir();

            if (!resultadoValidacao.IsValid)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
