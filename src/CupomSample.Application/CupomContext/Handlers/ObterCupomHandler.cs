using System.Threading;
using System.Threading.Tasks;
using CupomSample.Application.CupomContext.Queries;
using CupomSample.Application.CupomContext.Responses;
using CupomSample.Domain.CupomContext.Repositories;
using MediatR;

namespace CupomSample.Application.CupomContext.Handlers
{
    public class ObterCupomHandler : IRequestHandler<ObterCupomPorCodigoQuery, CupomResponse>
    {
        private readonly ICupomRepository _cupomRepository;
        public ObterCupomHandler(ICupomRepository cupomRepository)
        {
            _cupomRepository = cupomRepository;
        }
        public async Task<CupomResponse> Handle(ObterCupomPorCodigoQuery request, CancellationToken cancellationToken)
        {
            var cupomDto = await _cupomRepository.Obter(request.CodigoCupom);
            return new CupomResponse{CodigoCupom = cupomDto.CodigoCupom, IdCupom = cupomDto.IdCupom};
        }
    }
}