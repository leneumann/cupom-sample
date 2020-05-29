using CupomSample.Application.CupomContext.Commands;
using FluentValidation;

namespace CupomSample.Application.CupomContext.Validations
{
    public class CriarCupomCommandValidator : AbstractValidator<CriarCupomCommand>
    {
        public CriarCupomCommandValidator()
        {
            RuleFor(x => x.CodigoCupom).NotEmpty().WithMessage("O Codigo do cupom deve ser preenchido");
            RuleFor(x => x.CodigoCampanha).NotEmpty().WithMessage("O Codigo da Campanha deve ser preenchido");
        }
    }
}