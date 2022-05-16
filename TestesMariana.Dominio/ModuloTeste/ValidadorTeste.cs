using FluentValidation;

namespace TestesMariana.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty();
        }
    }
}
