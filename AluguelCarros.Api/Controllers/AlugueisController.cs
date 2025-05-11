using AluguelCarros.Application.Commands.Alugueis.Commands;
using AluguelCarros.Application.Queries.Alugueis.Queries;
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAluguelDataFim(Guid id, [FromBody] AtualizarAluguelDataFimCommand command)
        {
            // Para seguir o padrão RESTFull é enviado o id como path parameter
            if (id != command.Id)
                return BadRequest("Id da rota e do body não coincidem");

            var aluguelId = await _mediator.Send(command);
            return Ok(aluguelId);
        }

        [HttpPatch("{id}/devolver")]
        public async Task<IActionResult> AtualizarAluguelDataDevolucao(Guid id, [FromBody] AtualizarAluguelDataDevolucaoCommand command)
        {
            // Para seguir o padrão RESTFull é enviado o id como path parameter
            if (id != command.Id)
                return BadRequest("Id da rota e do body não coincidem");

            var aluguelId = await _mediator.Send(command);
            return Ok(aluguelId);
        }

    }
}