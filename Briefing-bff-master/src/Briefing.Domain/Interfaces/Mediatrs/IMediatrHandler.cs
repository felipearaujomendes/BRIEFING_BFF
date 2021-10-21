using Briefing.Domain.Messages;
using System.Threading.Tasks;

namespace Briefing.Domain.Interfaces.Mediatrs
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}
