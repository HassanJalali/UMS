
using MediatR;
namespace Framework.ApplicationService
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : Command
    {

    }

}


