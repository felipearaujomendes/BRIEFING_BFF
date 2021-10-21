using System;
using Briefing.Application.Validations;
using Briefing.Domain.Messages;

namespace Briefing.Application.Commands
{
    public class AdicionarRespostaCommand : Command
    {
        public AdicionarRespostaCommand()
        {
            if (Guid.Empty == AggregateRoot)  AggregateRoot = Guid.NewGuid();
        }
        
        public Guid IdPergunta { get; set; }

        public string Valor { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new AdicionarRespostaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
