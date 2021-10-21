using AutoMapper;
using Briefing.Application.Queries;
using Briefing.Domain.Entities;
using Briefing.Domain.Interfaces.Repositories;
using Briefing.Domain.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Briefing.Application.Commands
{
    public class RespostaCommandHandler : IRequestHandler<AdicionarRespostaCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRespostaRepository _respostaRepository;
        private readonly IPerguntaQueries  _perguntaQueries;

        public RespostaCommandHandler(IMapper mapper, IRespostaRepository respostaRepository, IPerguntaQueries perguntaQueries)
        {
            _mapper = mapper;
            _respostaRepository = respostaRepository;
            _perguntaQueries = perguntaQueries;
        }

        public async Task<bool> Handle(AdicionarRespostaCommand message, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(message)) return false;

                var entity = _mapper.Map<Resposta>(message);
                var pergunta = await _perguntaQueries.ObterPorId(message.IdPergunta);
                entity.Pergunta = pergunta;
                await _respostaRepository.Adicionar(entity);
                message.AggregateRoot = entity.Id;
                return await _respostaRepository.UnitOfWork.Commit();
            }
            catch (System.Exception)
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
