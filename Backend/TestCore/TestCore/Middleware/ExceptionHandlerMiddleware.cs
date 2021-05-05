using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Virtualmind.Financial.Api.Exceptions;
using Virtualmind.Financial.DTO;

namespace Virtualmind.Financial.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
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
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.Message);

            var code = HttpStatusCode.InternalServerError;
            var errors = new List<string>() { ex.Message };

            if (ex is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (ex is BadRequestException)
            {
                code = HttpStatusCode.BadRequest;
            }
            else if (ex is UnprocessableRequestException)
            {
                code = HttpStatusCode.UnprocessableEntity;
            }

            string result = JsonConvert.SerializeObject(ResponseDTO<string>.Failure((int)code, errors));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
