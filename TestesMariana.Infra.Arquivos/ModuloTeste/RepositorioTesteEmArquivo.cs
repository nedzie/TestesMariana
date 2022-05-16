using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using TestesMariana.Dominio.ModuloTeste;
using TestesMariana.Infra.Arquivos.Compartilhado;

namespace TestesMariana.Infra.Arquivos.ModuloTeste
{
    public class RepositorioTesteEmArquivo : RepositorioEmArquivoBase<Teste>
    {
        public RepositorioTesteEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Testes.Count > 0)
                contador = dataContext.Testes.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Teste novoRegistro)
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

        public override ValidationResult Editar(Teste registro)
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

        public override List<Teste> ObterRegistros()
        {
            return dataContext.Testes;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }

        private ValidationResult Validar(Teste registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            foreach (var item in dataContext.Testes)
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
