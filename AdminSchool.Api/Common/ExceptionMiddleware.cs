using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using FluentValidation;
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
        catch (UnauthorizedAccessException ex)
        {
            await HandleExceptionAsync(context, ex.Message, 401);
        }
        catch (ValidationException ex) // FluentValidation
        {
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            await HandleExceptionAsync(context, "Validation failed", 400, errors);
        }
        catch (KeyNotFoundException ex)
        {
            await HandleExceptionAsync(context, ex.Message, 404);
        }
        catch (DbUpdateException ex)
        {
            await HandleExceptionAsync(context, "A database error occurred.", 409);
        }
        catch (ArgumentException ex)
        {
            await HandleExceptionAsync(context, ex.Message, 400);
        }
        catch (NotImplementedException ex)
        {
            await HandleExceptionAsync(context, "Not implemented", 501);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled Exception");
            await HandleExceptionAsync(context, "An unexpected error occurred.", 500);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, string message, int statusCode, object? details = null)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new
        {
            status = statusCode,
            message,
            errors = details
        };

        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        await context.Response.WriteAsync(json);
    }
}
