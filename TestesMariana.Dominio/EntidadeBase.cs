﻿using System;

namespace TestesMariana.Dominio
{
    public abstract class EntidadeBase<T>
    {
        public int Numero { get; set; }

        public abstract void Atualizar(T registro);
    }
}
