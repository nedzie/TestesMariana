using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public TelaCadastroDisciplinaForm(Disciplina temp)
        {
            InitializeComponent();
            Disciplina = temp;
        }
        public TelaCadastroDisciplinaForm()
        {
            InitializeComponent();
            if(_disciplina != null)
            {
                textBoxNumero.Text = Disciplina.Numero.ToString();
                textBoxNome.Text = Disciplina.Nome;
            }
        }

        public Func<Disciplina, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Disciplina.Nome = textBoxNome.Text;

            var resultadoValidacao = GravarRegistro!(Disciplina); // _repositorioDisciplina.Inserir();

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
