using CupomSample.Application.CupomContext.Responses;
using MediatR;

namespace CupomSample.Application.CupomContext.Commands
{
    public class CriarCupomCommand : IRequest
    {
        public string CodigoCupom { get;  set; }
        public string CodigoCampanha { get; set; }

    }
}