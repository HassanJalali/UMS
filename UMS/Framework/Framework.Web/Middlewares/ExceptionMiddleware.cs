using Framework.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Net;
using System.Text.Json;

namespace Framework.Web.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
    {
        this.next = next;
		_logger = logger;
	}

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ContentType = "application/json";
            var apiException = new APIException();

            if (ex is DomainException)
            {
                _logger.LogError(ex.Message);
				apiException.Message = ex.Message; // + "\n" + ex.InnerException?.Message;
            }
            else
            {
				_logger.LogError(ex.Message);
				apiException.Message = ex.Message + "\n" + ex.InnerException?.Message;
                //apiException.Message = "خطایی در عملیات رخ داده است. لطفا دوباره امتحان کنید";
            }

            var result = JsonSerializer.Serialize(apiException);
            await response.WriteAsync(result);
        }
    }
}