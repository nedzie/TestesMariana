using FluentValidation;

namespace TestesMariana.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Serie)
                .NotNull()
                .NotEmpty();
        }
    }
}
