using System.Collections.Generic;
using TestesMariana.Dominio.Compartilhado;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;

namespace TestesMariana.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public string Enunciado { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public List<Alternativa> Alternativa { get; set; }

        public override void Atualizar(Questao registro)
        {
            this.Enunciado = registro.Enunciado;
            this.Disciplina = registro.Disciplina;
            this.Materia = registro.Materia;
            this.Alternativa = registro.Alternativa;
        }

        public Questao Clone()
        {
            return new Questao
            {
                Numero = this.Numero,
                Enunciado = this.Enunciado,
                Disciplina = this.Disciplina,
                Materia = this.Materia,
                Alternativa = this.Alternativa
            };
        }
    }
}
