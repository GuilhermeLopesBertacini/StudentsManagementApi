using System.Net;
using System.Text.Json;
using StudentsManagement.Business.Exceptions;

namespace StudentsManagement.Api.Middlewares
{
  public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
  {
    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
        await HandleExceptionAsync(context, ex);
      }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      var (statusCode, message) = exception switch
      {
        DomainException e     => (HttpStatusCode.BadRequest, e.Message),
        NotFoundException e   => (HttpStatusCode.NotFound, e.Message),
        BadRequestException e => (HttpStatusCode.BadRequest, e.Message),
        _                     => (HttpStatusCode.InternalServerError, "An unexpected error occurred.")
      };

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)statusCode;

      var body = JsonSerializer.Serialize(new
      {
        statusCode = (int)statusCode,
        message
      });

      await context.Response.WriteAsync(body);
    }
  }
}
