using Framework.ClientApp.ServiceContracts;

namespace Framework.ClientApp.ApiServices;

public abstract class ApiServiceBase
{
    protected readonly IHttpService httpService;
    protected readonly string apiUrl;

    public ApiServiceBase(IHttpService httpService, string apiUrl)
    {
        this.httpService = httpService;
        this.apiUrl = apiUrl;
    }

}