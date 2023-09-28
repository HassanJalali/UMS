using Framework.Core.Persistence;
using MediatR;

namespace Framework.ApplicationService.Behaviours
{
    public class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : Command
    {
        private readonly IDbContext dbContext;

        public UnitOfWorkBehaviour(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            try
            {
                var response = await next();
                dbContext.SaveChanges();
                return response;

            }
            catch (Exception ex)
            {
                dbContext.Dispose();
                throw;
            }
        }
    }
}
