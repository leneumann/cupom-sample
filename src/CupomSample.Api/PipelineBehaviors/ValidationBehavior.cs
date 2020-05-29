using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CupomSample.Application.CupomContext.Responses;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CupomSample.Api.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();
            //TODO: Implementar notifications handler ou exceptions handler
            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}