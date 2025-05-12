using AluguelCarros.Application.Commands.Carros.Commands;
using AluguelCarros.Application.Queries.Carros.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CarrosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> CriarCarro([FromBody] CriarCarroCommand command)
        {
            var carroId = await _mediator.Send(command);
            return Ok(carroId);   
        }

        [HttpGet]
        public async Task<IActionResult> ListarCarros([FromQuery] bool? disponivel)
        {
            var query = new ListarCarrosQuery(disponivel);
            var carros = await _mediator.Send(query);
            return Ok(carros);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> AtualizarCarro(Guid id, [FromBody] AtualizarCarroCommand command)
        {
            // Para seguir o padrão RESTFull é enviado o id como path parameter
            if (id != command.Id)
                return BadRequest("Id da rota e do body não coincidem");

            var carroId = await _mediator.Send(command);
            return Ok(carroId);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeletarCarro(Guid id)
        {
            var command = new DeletarCarroCommand(id);
            var carroId = await _mediator.Send(command);
            return Ok(carroId);
        }
    }
}
