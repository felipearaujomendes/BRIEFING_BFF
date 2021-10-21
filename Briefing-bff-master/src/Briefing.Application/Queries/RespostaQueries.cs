using AutoMapper;
using Briefing.Domain.Entities;
using Briefing.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Briefing.Application.Queries
{
    public class RespostaQueries : IRespostaQueries
    {

        private readonly IRespostaRepository _respostaRepository;
        private readonly IMapper _mapper;

        public RespostaQueries(IRespostaRepository respostaRepository, IMapper mapper)
        {
            _respostaRepository = respostaRepository;
            _mapper = mapper;
        }

        public async Task<Resposta> ObterPorId(Guid id)
        {
            return await _respostaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Resposta>> ObterTodos()
        {
            return await _respostaRepository.ObterTodos();
        }
    }
}
