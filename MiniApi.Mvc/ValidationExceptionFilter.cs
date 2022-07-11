using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace MiniApi.Mvc;

public class ValidationExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ValidationExceptionFilter> _logger;

    public ValidationExceptionFilter(ILogger<ValidationExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException exception)
        {
            try
            {
                var modelState = new ModelStateDictionary();

                foreach (var error in exception.Errors)
                {
                    modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                var problemDetails = new ValidationProblemDetails(modelState);

                context.Result = new BadRequestObjectResult(problemDetails);
                context.ExceptionHandled = true;
            }
            catch (Exception innerException)
            {
                _logger.LogError(innerException, "There was an unhandled error while handling a validation exception");
            }
        }
    }
}
