using Briefing.Application.Commands;
using FluentValidation;

namespace Briefing.Application.Validations
{
    public class AdicionarRespostaValidation : AbstractValidator<AdicionarRespostaCommand>
    {
        public AdicionarRespostaValidation()
        {
            RuleFor(c => c.Valor)
              .NotEmpty()
              .WithMessage("Um valor é necessário");


        }
    }
}
