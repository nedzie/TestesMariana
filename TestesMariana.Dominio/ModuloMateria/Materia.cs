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
            throw new NotImplementedException();
        }
    }
}
