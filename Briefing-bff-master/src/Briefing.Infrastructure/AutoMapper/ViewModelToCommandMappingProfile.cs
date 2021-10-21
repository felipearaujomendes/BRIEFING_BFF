using AutoMapper;
using Briefing.Application.Commands;
using Briefing.Application.ViewModels;

namespace Briefing.Infrastructure.AutoMapper
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<AdicionarRespostaViewModel, AdicionarRespostaCommand>()
            .ForMember(r => r.AggregateRoot, o => o.MapFrom(o => o.Id));

            CreateMap<AdicionarPerguntaViewModel, AdicionarPerguntaCommand>()
            .ForMember(r => r.AggregateRoot, o => o.MapFrom(o => o.Id));
        }
    }
}
