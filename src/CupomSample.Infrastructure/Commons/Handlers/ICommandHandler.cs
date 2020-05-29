using System.Threading.Tasks;
using CupomSample.Infrastructure.Commons.Messages;

namespace CupomSample.Infrastructure.Commons.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand:ICommand
    {
         Task Handle(TCommand command);
    }
}