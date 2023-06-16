using CustomExceptions.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace CustomExceptions.Filters;

public class CustomExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is EmployeeArgumentExceptions employeeArgumentException)
        {
            // Handle the specific custom exception
            var result = new ObjectResult(JsonConvert.SerializeObject(employeeArgumentException.Message))
            {
                StatusCode = (int)ExceptionStatusCodes.GetExceptionStatusCode(employeeArgumentException), // Bad Request
                Value = employeeArgumentException.Message
            };
            context.Result = result;
        }
        else
        {
            // Handle other exceptions or unknown errors
            var result = new ObjectResult(JsonConvert.SerializeObject(new { error = "An error occurred while processing your request" }))
            {
                StatusCode = (int)HttpStatusCode.InternalServerError // Internal Server Error
            };
            context.Result = result;
        }

        base.OnException(context);
    }
}
