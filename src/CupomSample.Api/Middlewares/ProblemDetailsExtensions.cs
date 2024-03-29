using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CupomSample.Api.Middlewares
{
	/*
	https://tools.ietf.org/html/rfc7807
	*/
    public static class ProblemDetailsExtensions
{
	public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
	{
		app.UseExceptionHandler(builder =>
		{
			builder.Run(async context =>
			{
				var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

				if (exceptionHandlerFeature != null)
				{
					var exception = exceptionHandlerFeature.Error;

					var problemDetails = new ProblemDetails
					{
						Instance = context.Request.HttpContext.Request.Path
					};

					if (exception is ValidationException validationException)
					{
						problemDetails.Title = "The request is invalid";
						problemDetails.Status = StatusCodes.Status400BadRequest;
						problemDetails.Detail = validationException.Message;
					}
					else
					{
						var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
						logger.LogError($"Unexpected error: {exceptionHandlerFeature.Error}");

						problemDetails.Title = exception.Message;
						problemDetails.Status = StatusCodes.Status500InternalServerError;
					}

					context.Response.StatusCode = problemDetails.Status.Value;
					context.Response.ContentType = "application/problem+json";

					var json = JsonConvert.SerializeObject(problemDetails, SerializerSettings.JsonSerializerSettings);
					await context.Response.WriteAsync(json);
				}
			});
		});
	}
}
}