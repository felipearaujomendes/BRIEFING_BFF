using AutoMapper;
using Briefing.Domain.Entities;
using Briefing.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Briefing.Application.Queries
{
    public class PerguntaQueries : IPerguntaQueries
    {
        private readonly IMapper _mapper;
        private readonly IPerguntaRepository _perguntaRepository;
        
        public PerguntaQueries(IMapper mapper, IPerguntaRepository perguntaRepository)
        {
            _mapper = mapper;
            _perguntaRepository = perguntaRepository;
        }

        public async Task<Pergunta> ObterPorId(Guid id)
        {
          return  await  _perguntaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Pergunta>> ObterTodos()
        {
            return await _perguntaRepository.ObterTodos();
        }
    }
}
