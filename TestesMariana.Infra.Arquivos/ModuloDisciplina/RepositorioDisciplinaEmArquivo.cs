using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Infra.Arquivos.Compartilhado;

namespace TestesMariana.Infra.Arquivos.ModuloDisciplina
{
    public class RepositorioDisciplinaEmArquivo : RepositorioEmArquivoBase<Disciplina>
    {
        public RepositorioDisciplinaEmArquivo(DataContext contextoDados) : base(contextoDados)
        {
            if (dataContext.Disciplinas.Count > 0)
                contador = dataContext.Disciplinas.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Disciplina novoRegistro)
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

        public override ValidationResult Editar(Disciplina registro)
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

        public override List<Disciplina> ObterRegistros()
        {
            return dataContext.Disciplinas;
        }

        public override AbstractValidator<Disciplina> ObterValidador()
        {
            return new ValidadorDisciplina();
        }

        private ValidationResult Validar(Disciplina registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            foreach (var item in dataContext.Disciplinas)
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
