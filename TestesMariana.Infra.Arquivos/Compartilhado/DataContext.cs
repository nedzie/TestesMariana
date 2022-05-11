using System;
using System.Collections.Generic;
using System.Linq;
using TestesMariana.Dominio;
using TestesMariana.Infra.Arquivos.Compartilhado.Serializadores;

namespace TestesMariana.Infra.Arquivos.Compartilhado
{
    [Serializable]
    public class DataContext
    {
        private readonly ISerializador serializador;

        //public DataContext()
        //{
        //    Tarefas = new List<Tarefa>();

        //    Contatos = new List<Contato>();

        //    Compromissos = new List<Compromisso>();

        //    Despesas = new List<Despesa>();
        //}
        public DataContext()
        {

        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Disciplina> Tarefas { get; set; }

        //public List<Materia> Contatos { get; set; }

        //public List<Questao> Compromissos { get; set; }

        //public List<Teste> Despesas { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            //var ctx = serializador.CarregarDadosDoArquivo();

            //if (ctx.Tarefas.Any())
            //    this.Disciplina.AddRange(ctx.Disciplina);

            //if (ctx.Contatos.Any())
            //    this.Materia.AddRange(ctx.Materia);

            //if (ctx.Compromissos.Any())
            //    this.Questao.AddRange(ctx.Questao);

            //if (ctx.Despesas.Any())
            //    this.Teste.AddRange(ctx.Teste);
        }
    }
}
