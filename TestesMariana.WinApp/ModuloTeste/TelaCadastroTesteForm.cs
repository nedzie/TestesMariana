using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;
using TestesMariana.Dominio.ModuloTeste;
using TestesMariana.Infra.BancoDeDados.ModuloDisciplina;
using TestesMariana.Infra.BancoDeDados.ModuloMateria;
using TestesMariana.Infra.BancoDeDados.ModuloQuestao;
using TestesMariana.Infra.BancoDeDados.ModuloTeste;

namespace TestesMariana.WinApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        private Teste _teste;
        private RepositorioTesteEmBancoDeDados _repositorioTeste;
        private RepositorioDisciplinaEmBancoDeDados _repositorioDisciplina;
        List<Disciplina> Disciplinas;
        List<Materia> Materias;
        List<Questao> Questoes;
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
                if (_teste.Disciplina != null)
                    comboBoxDisciplinas.SelectedItem = Disciplinas.Where(x => x.Nome == _teste.Disciplina.Nome).Single();

                if (_teste.Materia != null)
                    comboBoxMaterias.SelectedItem = Materias.Where(x => x.Nome == _teste.Materia.Nome).Single();

                if (_teste.Data != DateTime.MinValue)
                    maskedTextBoxData.Text = _teste.Data.ToString();
                else
                    maskedTextBoxData.Text = DateTime.Now.ToString();

                textBoxQtdeQuestoes.Text = _teste.QtdeQuestoes.ToString();
            }
        }

        public TelaCadastroTesteForm(List<Disciplina> disciplinas, List<Materia> materias, List<Questao> questoes)
        {
            InitializeComponent();
            Disciplinas = disciplinas;
            Materias = materias;
            Questoes = questoes;
            PovoarDisciplinas();
        }

        public Func<Teste, ValidationResult>? GravarRegistro { get; set; }

        public void PovoarDisciplinas()
        {
            foreach (var item in Disciplinas)
                comboBoxDisciplinas.Items.Add(item);
        }

        public void PovoarMaterias(Disciplina disc)
        {
            foreach (var item in Materias)
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

            int qtde = int.Parse(textBoxQtdeQuestoes.Text);
            Disciplina disciplinaSelecionada = (Disciplina)comboBoxDisciplinas.SelectedItem;

            int questoes = Questoes.FindAll(x => x.Disciplina.Nome == disciplinaSelecionada.Nome).Count;

            if (qtde > questoes)  //TODO: Encontrar uma solução melhor pra isso
            {
                MessageBox.Show("O número escolhido de questões excede o número de questões cadastradas para essa situação!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random rnd = new();
            if (!checkBoxRecuperacao.Checked)
            {
                Materia m = (Materia)comboBoxMaterias.SelectedItem;

                List<Questao> perm = Questoes.FindAll(x => x.Materia.Nome == m.Nome);

                for (int i = 0; i < qtde; i++)
                {
                    int y = rnd.Next(0, perm.Count - 1);

                    if (Teste.Questoes.Exists(x => x.Equals(perm[y]) == false) && Teste.Questoes.Count > 1)
                        Teste.Questoes.Add(perm[y]);
                    else if (Teste.Questoes.Count == 0)
                        Teste.Questoes.Add(perm[y]);
                    else
                        i--;
                }
            }
            else
            {
                for (int i = 0; i < qtde; i++)
                {
                    int y = rnd.Next(0, Questoes.Count - 1);

                    if (Teste.Questoes.Count < 1) // Se for o primeiro registro
                        Teste.Questoes.Add(Questoes[y]);
                    else if (Teste.Questoes.Contains(Questoes[y])) // Se não for, verifica se já existe
                    {
                        i--;
                        continue;
                    }
                    else
                        Teste.Questoes.Add(Questoes[y]); // Se não existe, adiciona
                }
            }

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

            //List<Questao> temp = _repositorioQuestao.SelecionarTodos();

            List<Questao> perm = Questoes.FindAll(x => x.Materia.Nome == comboBoxMaterias.SelectedItem.ToString());

            foreach (var item in perm)
                listBoxQuestoes.Items.Add(item);

        }
    }
}
