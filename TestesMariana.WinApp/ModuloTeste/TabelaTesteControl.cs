using eAgenda.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloTeste;

namespace TestesMariana.WinApp.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade", HeaderText = "Quantidade questões"}
            };

            return colunas;
        }

        public int ObtemNumeroMateriaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();

            foreach (Teste teste in testes)
            {
                grid.Rows.Add(teste.Numero, teste.Nome, teste.Disciplina, teste.Materia, teste.QtdeQuestoes);
            }

        }
    }
}
