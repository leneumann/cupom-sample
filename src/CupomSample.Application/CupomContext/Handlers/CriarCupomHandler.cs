using System.Threading;
using System.Threading.Tasks;
using CupomSample.Application.CupomContext.Commands;
using CupomSample.Domain;
using CupomSample.Domain.CupomContext.Repositories;
using MediatR;

namespace CupomSample.Application.CupomContext.Handlers
{
    public class CriarCupomHandler : AsyncRequestHandler<CriarCupomCommand>
    {
        private readonly ICupomRepository _cupomRepository;
        public CriarCupomHandler(ICupomRepository cupomRepository)
        {
            _cupomRepository = cupomRepository;
        }
        protected override Task Handle(CriarCupomCommand command, CancellationToken cancellationToken)
        {
            var cupom = new Cupom(command.CodigoCupom);
            return _cupomRepository.Add(cupom);
        }
    }
}