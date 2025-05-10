using AluguelCarros.Application.Commands;
using AluguelCarros.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlugueisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlugueisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAluguel([FromBody] CriarAluguelCommand command)
        {
            var aluguelId = await _mediator.Send(command);
            return Ok(aluguelId);
        }

        [HttpGet]
        public async Task<IActionResult> ListarAlugueis()
        {
            var query = new ListarAlugueisQuery();
            var alugueis = await _mediator.Send(query);
            return Ok(alugueis);

        }
    }
}