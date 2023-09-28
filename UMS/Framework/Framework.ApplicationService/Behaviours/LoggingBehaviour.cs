//using System.Reflection;
//using MediatR;
//using Microsoft.Extensions.Logging;

//namespace Framework.ApplicationService.Behaviours
//{
//    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//	{
//		private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

//		//IIdentityService identityService for getting current user info
//		public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
//		{
//			_logger = logger;
//		}
//		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//        {
//            try
//            {
//				//Request

//				_logger.LogInformation($"Handling {typeof(TRequest).Name}");
//				Type myType = request.GetType();
//				IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
//				foreach (PropertyInfo prop in props)
//				{
//					object propValue = prop.GetValue(request, null);
//					_logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
//				}
//				var response = await next();

//				//Response
//				_logger.LogInformation($"Handled {typeof(TResponse).Name}");
//				return response;
//			}
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, request.GetType().Name + "\n " + String.Join(": ", GetRequestProperty(request)));
//                throw;
//            }
//        }
//        public static List<object> GetRequestProperty(TRequest request)
//        {
//            List<object> list = new List<object>();
//            Type type = request.GetType();
//            PropertyInfo[] props = type.GetProperties();
//            foreach (var prop in props)
//            {
//                list.Add(prop.Name);
//                list.Add(prop.GetValue(request));
//            }
//            return list;
//        }
//    }


//}
