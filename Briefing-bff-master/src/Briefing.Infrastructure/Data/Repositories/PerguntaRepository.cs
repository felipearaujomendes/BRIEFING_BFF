using Briefing.Domain.Entities;
using Briefing.Domain.Interfaces.Repositories;
using Briefing.Infrastructure.Data.Contexts;

namespace Briefing.Infrastructure.Data.Repositories
{
    public class PerguntaRepository: Repository<Pergunta>, IPerguntaRepository
    {
        public PerguntaRepository(QuizContext context):base(context)
        {

        }
    }
}
