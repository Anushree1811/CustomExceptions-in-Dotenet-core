using CustomExceptions.Domain.Exceptions;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace CustomExceptions.Middleware;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		try {

			await _next(httpContext);

		} catch (Exception ex)
		{
			httpContext.Response.StatusCode = (int)ExceptionStatusCodes.GetExceptionStatusCode(ex);


            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { error = ex.Message }));

        }
	}



	//public static class MiddlewareExtensions{

	//	public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder) { 
		
	//		return builder.UseMiddleware<ExceptionMiddleware>();
	//	}
 //   }
}
