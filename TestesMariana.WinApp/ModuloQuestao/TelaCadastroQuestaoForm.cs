﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
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
                textBoxNumero.Text = _questao.Numero.ToString();
                comboBoxDisciplinas.SelectedItem = _questao.Disciplina;
                comboBoxMaterias.SelectedItem = _questao.Materia;
                textBoxEnunciado.Text = _questao.Enunciado;
                /* List de questões 
                foreach(var item in checkedListBoxAlternativas.Items.Cast<Alternativa>().ToList()
                {
                if (Itens.Exists(x => x.Equals(item)) == false)
                    itens.Add(item);
                }
                */
            }
        }

        public TelaCadastroQuestaoForm()
        {
            InitializeComponent();
        }

        public Func<Questao, ValidationResult>? GravarRegistro { get; set; }

        public List<Alternativa> AlternativasAdicionadas
        {
            get
            {
                return checkedListBoxAlternativas.CheckedItems.Cast<Alternativa>().ToList();
            }
        }


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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (textBoxAlternativa.Text != string.Empty && textBoxAlternativa.Text != "")
            {
                if (checkedListBoxAlternativas.Items.Count < 4)
                {
                    List<string> titulos = AlternativasAdicionadas.Select(x => x.Opcao).ToList();

                    if (titulos.Count == 0 || titulos.Contains(textBoxAlternativa.Text) == false)
                    {
                        Alternativa alt = new();

                        alt.Opcao = textBoxAlternativa.Text;

                        checkedListBoxAlternativas.Items.Add(alt);
                        textBoxAlternativa.Clear();
                        textBoxAlternativa.Focus();
                    }
                }
            }
        }

        private void checkedListBoxAlternativas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxAlternativas.CheckedItems.Count > 0)
            {
                foreach (int i in checkedListBoxAlternativas.CheckedIndices)
                    checkedListBoxAlternativas.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}
