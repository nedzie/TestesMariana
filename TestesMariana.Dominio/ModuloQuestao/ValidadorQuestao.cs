using FluentValidation;

namespace TestesMariana.Dominio.ModuloQuestao
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.Enunciado)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Materia)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Disciplina)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Alternativas)
                .NotNull()
                .NotEmpty();
        }
    }
}
