﻿using System;
using TestesMariana.Dominio.Compartilhado;

namespace TestesMariana.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>, ICloneable
    {
        public string Nome { get; set; }

        public Disciplina()
        {

        }

        public override void Atualizar(Disciplina registro)
        {
            this.Nome = registro.Nome;
        }

        public override string ToString()
        {
            return $"Numero: {Numero}, Nome: {Nome}";
        }

        public object Clone()
        {
            return new Disciplina
            {
                Numero = this.Numero,
                Nome = this.Nome
            };
        }
    }
}
