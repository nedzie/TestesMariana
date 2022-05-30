using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;
using TestesMariana.Dominio.ModuloTeste;
using TestesMariana.Infra.Arquivos.ModuloTeste;
using TestesMariana.Infra.BancoDeDados;

namespace TestesMariana.WinApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        private Teste _teste;
        private RepositorioTesteEmBancoDeDados _repositorioTeste;
        private RepositorioDisciplinaEmBancoDeDados _repositorioDisciplina;
        private RepositorioMateriaEmBancoDeDados _repositorioMateria;
        private RepositorioQuestaoEmBancoDeDados _repositorioQuestao;

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
                if (_teste.Data != DateTime.MinValue)
                    maskedTextBoxData.Text = _teste.Data.ToString();
                else
                    maskedTextBoxData.Text = DateTime.Now.ToString();

                textBoxQtdeQuestoes.Text = _teste.QtdeQuestoes.ToString();
            }
        }
        public TelaCadastroTesteForm(RepositorioTesteEmBancoDeDados rt, RepositorioDisciplinaEmBancoDeDados rd, RepositorioMateriaEmBancoDeDados rm, RepositorioQuestaoEmBancoDeDados rq)
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

            foreach (var item in materias)
                if (item.Disciplina.Nome == disc.Nome)
                    comboBoxMaterias.Items.Add(item);
        }


        public List<Questao> QuestoesAdicionadas
        {
            get
            {
                return listBoxQuestoes.Items.Cast<Questao>().ToList();
            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Teste.Nome = textBoxNome.Text;
            Teste.Disciplina = (Disciplina)comboBoxDisciplinas.SelectedItem;
            Teste.Materia = (Materia)comboBoxMaterias.SelectedItem;
            Teste.Nome = textBoxNome.Text;
            Teste.Data = DateTime.Parse(maskedTextBoxData.Text);

            Teste.QtdeQuestoes = int.Parse(textBoxQtdeQuestoes.Text);

            List<Questao> questoes = QuestoesAdicionadas;

            Teste.AdicionarQuestoes(questoes);

            var resultadoValidacao = GravarRegistro!(Teste);

            if (!resultadoValidacao.IsValid)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
        private void comboBoxDisciplinas_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxMaterias.Items.Clear();
            listBoxQuestoes.Items.Clear();
            comboBoxMaterias.ResetText();
            PovoarMaterias((Disciplina)comboBoxDisciplinas.SelectedItem);
            comboBoxMaterias.Enabled = true;
        }

        private void comboBoxMaterias_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxQuestoes.Items.Clear();

            List<Questao> temp = _repositorioQuestao.SelecionarTodos();

            List<Questao> perm = temp.FindAll(x => x.Materia.Nome == comboBoxMaterias.SelectedItem.ToString());

            foreach (var item in perm)
                listBoxQuestoes.Items.Add(item);

        }

        private void buttonQuestoes_Click(object sender, EventArgs e)
        {
            int qtde = int.Parse(textBoxQtdeQuestoes.Text);

            if (qtde > listBoxQuestoes.Items.Count)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Quantia de questões excedida!");
                return;
            }

            Random rnd = new();
            if (!checkBoxRecuperacao.Checked)
            {
                Materia m = (Materia)comboBoxMaterias.SelectedItem;

                List<Questao> temp = _repositorioQuestao.SelecionarTodos();
                List<Questao> perm = temp.FindAll(x => x.Materia.Nome == m.Nome);

                for (int i = 0; i < qtde; i++)
                {
                    int y = rnd.Next(perm.Count - 1);
                    Teste.AdicionarQuestao(perm[y]);
                }
            }
        }

        private void checkBoxRecuperacao_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRecuperacao.Checked)
            {
                textBoxQtdeQuestoes.Clear();
                textBoxQtdeQuestoes.Enabled = false;
                buttonQuestoes.Enabled = false;
            }
            else
            {
                textBoxQtdeQuestoes.Enabled = true;
                buttonQuestoes.Enabled = true;
            }
        }
    }
}
