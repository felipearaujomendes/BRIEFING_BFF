using System;

namespace Briefing.Application.ViewModels
{
    public class AdicionarRespostaViewModel
    {
        public Guid Id { get; set; }
        public Guid IdPergunta { get; set; }
        public string Valor { get; set; }
        public int TipoEntrada { get; set; }
    }
}
