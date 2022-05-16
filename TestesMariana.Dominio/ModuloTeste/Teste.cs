using System;
using System.Collections.Generic;
using TestesMariana.Dominio.Compartilhado;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;

namespace TestesMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public int QtdeQuestoes { get; set; }
        public List<Questao> Questoes { get; set; }
        public DateTime Data { get; set; }
        public Teste()
        {

        }

        public override void Atualizar(Teste registro)
        {
            this.Nome = registro.Nome;
            this.Disciplina = registro.Disciplina;
            this.Materia = registro.Materia;
            this.QtdeQuestoes = registro.QtdeQuestoes;
            this.Questoes = registro.Questoes;
        }

        public Teste Clone()
        {
            return new Teste
            {
                Nome = this.Nome,
                Disciplina = this.Disciplina,
                Materia = this.Materia,
                QtdeQuestoes = this.QtdeQuestoes,
                Questoes = this.Questoes
            };
        }
    }
}
