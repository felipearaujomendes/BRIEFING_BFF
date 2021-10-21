using AutoMapper;
using Briefing.Domain.Entities;
using Briefing.Domain.Interfaces.Repositories;
using Briefing.Domain.Messages;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Briefing.Application.Commands
{
    public class PerguntaCommandHandler : IRequestHandler<AdicionarPerguntaCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPerguntaRepository _perguntaRepository;

        public PerguntaCommandHandler(IMapper mapper, IPerguntaRepository perguntaRepository)
        {
            _mapper = mapper;
            _perguntaRepository = perguntaRepository;
        }

        public async Task<bool> Handle(AdicionarPerguntaCommand message, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(message)) return false;
                
                var entity = _mapper.Map<Pergunta>(message);
                await _perguntaRepository.Adicionar(entity);
                message.AggregateRoot = entity.Id;
                return await _perguntaRepository.UnitOfWork.Commit();
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;
            return false;
        }
    }
}
