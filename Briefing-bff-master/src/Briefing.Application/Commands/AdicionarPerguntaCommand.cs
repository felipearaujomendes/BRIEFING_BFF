using Briefing.Application.Validations;
using Briefing.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Briefing.Application.Commands
{
    public class AdicionarPerguntaCommand : Command
    {
        public string Display { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new AdicionarPerguntaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
