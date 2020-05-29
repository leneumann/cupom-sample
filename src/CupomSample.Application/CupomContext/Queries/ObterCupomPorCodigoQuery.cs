using CupomSample.Application.CupomContext.Responses;
using MediatR;

namespace CupomSample.Application.CupomContext.Queries
{
    public class ObterCupomPorCodigoQuery:IRequest<CupomResponse>
    {
        public string CodigoCupom { get; private set; }
        public ObterCupomPorCodigoQuery(string codigoCupom)
        {
            CodigoCupom = codigoCupom;
        }
    }
}