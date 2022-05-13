using FluentValidation;

namespace TestesMariana.Dominio.ModuloQuestao
{
    public class ValidadorAlternativa : AbstractValidator<Alternativa>
    {
        public ValidadorAlternativa()
        {
            RuleFor(x => x.Opcao)
                .NotNull()
                .NotEmpty();
        }
    }
}
