using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace AeriSample
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                string result = JsonConvert.SerializeObject(new { Message = $"{ex.Message} {(ex.InnerException != null ? ex.InnerException.Message : "")}" });

                if (ex is ValidationException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex is NotImplementedException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
        }


    }
}
