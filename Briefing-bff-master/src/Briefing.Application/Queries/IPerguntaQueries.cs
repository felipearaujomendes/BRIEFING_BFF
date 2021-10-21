using Briefing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Briefing.Application.Queries
{
    public interface IPerguntaQueries
    {
        Task<IEnumerable<Pergunta>> ObterTodos();

        Task<Pergunta> ObterPorId(Guid id);

    }
}
