using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Net;
using Newtonsoft.Json;
using Restaurant.Shared;

namespace Restaurant.Web
{
   public class ExceptionMiddleware
   {
      private readonly RequestDelegate _next;
      private readonly ILogger<ExceptionMiddleware> _logger;

      public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
      {
         _next = next;
         _logger = logger;
      }

      public async Task Invoke(HttpContext context)
      {
         try
         {
            await _next(context);
         }
         catch (Exception ex)
         {
            _logger.LogError(ex.Message + "\n" + ex.StackTrace);
            HandleExceptionAsync(context, ex);
         }
      }

        private void HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is AuthorizationException)
            {
                if (context.Request.Headers.Any(a => a.Key == "X-Requested-With") && context.Request.Headers.FirstOrDefault(a => a.Key == "X-Requested-With").Value.ToString() == "XMLHttpRequest")
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }
                else
                    context.Response.Redirect("/User/Login");
            }
            else if (exception is BusinessRuleException)
            {
                context.Session.SetString("ErrorMessage", exception.Message);
                context.Response.Redirect("/Home/Error");
            }
            else
            {
                context.Session.SetString("ErrorMessage", "Unhandled Exception happened !!!");
                context.Response.Redirect("/Home/Error");
            }
        }
   }
}
