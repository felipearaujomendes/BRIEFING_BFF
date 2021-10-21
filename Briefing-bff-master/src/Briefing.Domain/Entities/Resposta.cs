using System;
using System.Collections.Generic;
using System.Text;

namespace Briefing.Domain.Entities
{
    public class Resposta: Entity
    {

        public string Valor { get; set; }
        public Pergunta Pergunta { get; set; }
    }
}
