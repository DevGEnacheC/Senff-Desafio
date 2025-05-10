using AluguelCarros.Application.Commands.Carros.Commands;
using AluguelCarros.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCarro([FromBody] CriarCarroCommand command)
        {
            var carroId = await _mediator.Send(command);
            return Ok(carroId);   
        }

        [HttpGet]
        public async Task<IActionResult> ListarCarros()
        {
            var query = new ListarCarrosQuery();
            var carros = await _mediator.Send(query);
            return Ok(carros);
        }
    }
}
