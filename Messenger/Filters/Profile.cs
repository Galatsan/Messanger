using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Messanger.Filters
{
    public class ProfileFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger logger;
        public ProfileFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger("SimpleResourceFilter");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation($"OnResourceExecuted - {DateTime.Now}");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation($"OnResourceExecuting - {DateTime.Now}");
        }
    }
}
