using CustomExceptions.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace CustomExceptions;

public class CustomIExceptionFilter: IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is EmployeeArgumentExceptions employeeArgumentExceptions)
        {

            context.Result = new ObjectResult(JsonConvert.SerializeObject(employeeArgumentExceptions.Message))
            {
                StatusCode = (int)ExceptionStatusCodes.GetExceptionStatusCode(employeeArgumentExceptions),
               // DeclaredType = typeof(EmployeeArgumentExceptions)
            };

        }
        else {


            context.Result = new ObjectResult(JsonConvert.SerializeObject(new { error = "An error occurred while processing your request" }))
            {
                StatusCode = (int)HttpStatusCode.InternalServerError

            };
        
        }
        
        
    }

    internal class CustomExceptionAttributeFilterAttribute : Attribute
    {
    }
}



