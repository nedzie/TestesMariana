using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Infra.Arquivos.Compartilhado;

namespace TestesMariana.Infra.Arquivos.ModuloMateria
{
    public class RepositorioMateriaEmArquivo : RepositorioEmArquivoBase<Materia>
    {
        public RepositorioMateriaEmArquivo(DataContext contextoDados) : base(contextoDados)
        {
            if (dataContext.Materias.Count > 0)
                contador = dataContext.Materias.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Materia novoRegistro)
        {
            ValidationResult resultadoValidacao = Validar(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;
        }

        public override ValidationResult Editar(Materia registro)
        {
            var resultadoValidacao = Validar(registro);

            if (resultadoValidacao.IsValid)
            {
                var registros = ObterRegistros();

                foreach (var item in registros)
                {
                    if (item.Numero == registro.Numero)
                    {
                        item.Atualizar(registro);
                        break;
                    }
                }
            }

            return resultadoValidacao;
        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }

        private ValidationResult Validar(Materia registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            foreach (var item in dataContext.Materias)
            {
                if (item.Nome == registro.Nome && item.Numero != registro.Numero)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome já cadastrado"));
            }

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            return resultadoValidacao;
        }
    }
}
