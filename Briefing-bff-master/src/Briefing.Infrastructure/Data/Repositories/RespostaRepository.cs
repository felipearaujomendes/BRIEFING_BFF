using Briefing.Domain.Entities;
using Briefing.Domain.Interfaces.Repositories;
using Briefing.Infrastructure.Data.Contexts;

namespace Briefing.Infrastructure.Data.Repositories
{
    public class RespostaRepository:Repository<Resposta>, IRespostaRepository
    {
        public RespostaRepository(QuizContext context):base(context)
        {

        }
    }
}
