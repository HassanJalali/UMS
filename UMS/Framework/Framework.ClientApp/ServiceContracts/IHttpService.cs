
namespace Framework.ClientApp.ServiceContracts;

public interface IHttpService
{
    Task<T> Get<T>(string url);
    Task Post(string uri, object value);
    Task Put(string uri, object value);
    Task Delete(string uri);
}
