using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        
        private RepositorioDisciplinaEmArquivo _repositorioDisciplina;
        private TabelaDisciplinasControl? tabelaDisciplinas;


        public ControladorDisciplina(RepositorioDisciplinaEmArquivo repositorioDisciplina)
        {
            this._repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            TelaCadastroDisciplinaForm tela = new();
            tela.Disciplina = new();

            tela.GravarRegistro = _repositorioDisciplina.Inserir;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if(res == DialogResult.OK)
                CarregarDisciplinas();

        }


        public override void Editar()
        {
            Disciplina temp = new();
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            temp.Numero = disciplinaSelecionada.Numero;
            temp.Nome = disciplinaSelecionada.Nome;

            TelaCadastroDisciplinaForm tela = new(temp);

            tela.GravarRegistro = _repositorioDisciplina.Editar;

            DialogResult res = tela.ShowDialog(); // Daqui vai para os códigos da 'TelaCadastroDisciplinaForm'

            if (res == DialogResult.OK)
                CarregarDisciplinas();
        }
        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            if(disciplinaSelecionada != null)
            {
                DialogResult res = MessageBox.Show("Excluir disciplina?",
                "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                    _repositorioDisciplina.Excluir(disciplinaSelecionada);
            }
        }
        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = _repositorioDisciplina.SelecionarTodos();
            tabelaDisciplinas!.AtualizarRegistros(disciplinas);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {disciplinas.Count} disciplina(s)");
        }

        private Disciplina ObtemDisciplinaSelecionada()
        {
            var numero = tabelaDisciplinas!.ObtemNumeroTarefaSelecionada();
            return _repositorioDisciplina.SelecionarPorNumero(numero);
        }


        public override ConfigToolboxBase ObtemConfiguracaoToolbox() // Responsável por carregar o padrão da tela
        {
            return new ConfigToolboxDisciplina();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaDisciplinas == null)
                tabelaDisciplinas = new TabelaDisciplinasControl();

            CarregarDisciplinas();

            return tabelaDisciplinas;
        }
    }
}
