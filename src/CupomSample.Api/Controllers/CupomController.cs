using System.Threading.Tasks;
using CupomSample.Application.CupomContext.Commands;
using CupomSample.Application.CupomContext.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupomSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CupomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CupomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{codigoCupom}")]
        public async Task<IActionResult> ObterCupomPorCodigo(string codigoCupom){
            var query = new ObterCupomPorCodigoQuery(codigoCupom);
            return Ok(await _mediator.Send(query));
        }
        
        [HttpPost]
        public async Task<IActionResult> CriarCupom([FromBody] CriarCupomCommand command)
        {
            var response  = await _mediator.Send(command);
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("hc")]
        public IActionResult Get() => Ok("Servico no ar");
    }
}