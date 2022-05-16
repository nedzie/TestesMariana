using System;
using TestesMariana.Dominio.Compartilhado;
using TestesMariana.Dominio.ModuloDisciplina;

namespace TestesMariana.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public SerieEnum Serie { get; set; }
        public Disciplina Disciplina { get; set; }

        public override void Atualizar(Materia registro)
        {
            this.Nome = registro.Nome;
            this.Serie = registro.Serie;
            this.Disciplina = registro.Disciplina;
        }

        public Materia Clone()
        {
            return new Materia
            {
                Numero = this.Numero,
                Nome = this.Nome,
                Serie = this.Serie,
                Disciplina = this.Disciplina
            };
        }

        public override string ToString()
        {
            return $"Número: {Numero}, Nome: {Nome}, Série: {Serie}, Disciplina: {Disciplina}";
        }
    }
}
