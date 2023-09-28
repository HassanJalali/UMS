using MediatR;

namespace Framework.Facade
{
    public abstract class QueryFacadeBase
    {
        protected readonly IMediator mediator;

        public QueryFacadeBase(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
