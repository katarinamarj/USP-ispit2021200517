using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Library.Application.Common.Exceptions;
using System.Net;

namespace Library.API.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationException)
            {
                var problemDetails = new ValidationProblemDetails(validationException.Errors)
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = "Validation errors occurred",
                    Detail = "One or more validation errors occurred.",
                };

                context.Result = new BadRequestObjectResult(problemDetails);
                context.ExceptionHandled = true;
            }
            else
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var problemDetails = new ProblemDetails
                {
                    Status = statusCode,
                    Title = "An unexpected error occurred",
                    Detail = context.Exception.Message,
                };

                context.Result = new ObjectResult(problemDetails)
                {
                    StatusCode = statusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
