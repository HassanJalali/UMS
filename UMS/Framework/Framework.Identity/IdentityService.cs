using Microsoft.AspNetCore.Http;

namespace Framework.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpContext httpContext;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContext = httpContextAccessor.HttpContext;
        }

        public Guid GetCurrentEmployeeId()
        {
            throw new NotImplementedException();
        }

        public string GetCurrentEmployeePersonnelCode()
        {
            var nameClaim = httpContext.User.FindFirst("name")?.Value;
            return nameClaim;
        }
    }
}
