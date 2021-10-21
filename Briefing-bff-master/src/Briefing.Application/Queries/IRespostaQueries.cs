using Briefing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Briefing.Application.Queries
{
    public interface IRespostaQueries
    {
        Task<IEnumerable<Resposta>> ObterTodos();

        Task<Resposta> ObterPorId(Guid id);

    }
}
