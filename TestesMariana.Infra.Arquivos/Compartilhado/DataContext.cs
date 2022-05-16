using System;
using System.Collections.Generic;
using System.Linq;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;
using TestesMariana.Dominio.ModuloTeste;
using TestesMariana.Infra.Arquivos.Compartilhado.Serializadores;

namespace TestesMariana.Infra.Arquivos.Compartilhado
{
    [Serializable]
    public class DataContext
    {
        private readonly ISerializador serializador;

        public DataContext()
        {
            Disciplinas = new List<Disciplina>();
            Materias = new List<Materia>();
            Questoes = new List<Questao>();
            Testes = new List<Teste>();
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Disciplina> Disciplinas { get; set; }

        public List<Materia> Materias { get; set; }

        public List<Questao> Questoes { get; set; }

        public List<Teste> Testes { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Disciplinas.Any())
                this.Disciplinas.AddRange(ctx.Disciplinas);

            if (ctx.Materias.Any())
                this.Materias.AddRange(ctx.Materias);

            if (ctx.Questoes.Any())
                this.Questoes.AddRange(ctx.Questoes);

            if (ctx.Testes.Any())
                this.Testes.AddRange(ctx.Testes);
        }
    }
}
