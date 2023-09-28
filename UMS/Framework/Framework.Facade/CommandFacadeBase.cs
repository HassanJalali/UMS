using MediatR;

namespace Framework.Facade;

public abstract class CommandFacadeBase
{

    protected readonly IMediator mediator;

    public CommandFacadeBase(IMediator mediator)
    {
        this.mediator = mediator;
    }
}