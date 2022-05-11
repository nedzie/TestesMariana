using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesMariana.Dominio
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string Nome { get; set; }
        public SerieEnum Serie { get; set; }
        public Disciplina()
        {

        }

        public override void Atualizar(Disciplina registro)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Numero: {Numero}, Nome: {Nome}, Série: {Serie}";
        }
    }
}
