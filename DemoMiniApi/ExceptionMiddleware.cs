using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace DemoMiniApi;

public static class ExceptionMiddleware
{
    public static async Task Handle(HttpContext context, ILogger<StartupModule> logger)
    {
        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature == null)
        {
            return;
        }

        object result;

        if (exceptionHandlerPathFeature.Error is ValidationException err)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var modelState = new ModelStateDictionary();

            foreach (var error in err.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            var errors = modelState.ToDictionary(
                x => x.Key,
                x => x.Value!.Errors.Select(y => y.ErrorMessage).ToArray());

            result = new HttpValidationProblemDetails(errors);
        }
        else
        {
            logger.LogError(exceptionHandlerPathFeature.Error,
                "Unhandled exception: {0}",
                exceptionHandlerPathFeature.Error.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            result = new ProblemDetails()
            {
                Title = "Internal Server Error"
            };
        }

        context.Response.ContentType = "application/json+problem";

        await context.Response.WriteAsJsonAsync(result, cancellationToken: context.RequestAborted);
    }
}
