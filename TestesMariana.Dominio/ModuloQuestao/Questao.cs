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
        public List<Alternativa> Alternativas { get; set; }


        public Questao()
        {
            Alternativas = new();
        }

        public void AdicionarAlternativas(List<Alternativa> alts)
        {
            foreach (var item in alts)
                if(Alternativas.Exists(x => x.Equals(item)) == false)
                    this.Alternativas.Add(item);
        }

        public override void Atualizar(Questao registro)
        {
            this.Enunciado = registro.Enunciado;
            this.Disciplina = registro.Disciplina;
            this.Materia = registro.Materia;
            this.Alternativas = registro.Alternativas;
        }

        public Questao Clone()
        {
            return new Questao
            {
                Numero = this.Numero,
                Enunciado = this.Enunciado,
                Disciplina = this.Disciplina,
                Materia = this.Materia,
                Alternativas = this.Alternativas
            };
        }
    }
}
