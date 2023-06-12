using System.Net;

namespace CustomExceptions.Domain.Exceptions;

public static class ExceptionStatusCodes
{
    private static Dictionary<Type, HttpStatusCode> exceptionStatusCode = new Dictionary<Type, HttpStatusCode>
    {
        { typeof(EmployeeArgumentExceptions),HttpStatusCode.BadRequest}
    };

    public static HttpStatusCode GetExceptionStatusCode(Exception exception) { 
    
        bool exceptionFound =exceptionStatusCode.TryGetValue(exception.GetType(),out var statusCode);
        return exceptionFound? statusCode : HttpStatusCode.InternalServerError;
    }

}
