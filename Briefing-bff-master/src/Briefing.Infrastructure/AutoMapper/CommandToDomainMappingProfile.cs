using AutoMapper;
using Briefing.Application.Commands;
using Briefing.Domain.Entities;

namespace Briefing.Infrastructure.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<Resposta, AdicionarRespostaCommand>()
            .ForMember(r => r.AggregateRoot, o => o.MapFrom(o =>  o.Id )).ReverseMap();
            
            CreateMap<Pergunta, AdicionarPerguntaCommand>()
            .ForMember(r => r.AggregateRoot, o => o.MapFrom(o => o.Id));
            
            CreateMap<AdicionarPerguntaCommand, Pergunta>()
                .ConstructUsing(p => new Pergunta() { Display=p.Display});


        }
    }
}
