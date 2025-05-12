using AluguelCarros.Application.Commands.Alugueis.Commands;
using AluguelCarros.Application.Queries.Alugueis.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlugueisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlugueisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> CriarAluguel([FromBody] CriarAluguelCommand command)
        {
            var aluguelId = await _mediator.Send(command);
            return Ok(aluguelId);
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> ListarAlugueis()
        {
            var query = new ListarAlugueisQuery();
            var alugueis = await _mediator.Send(query);
            return Ok(alugueis);

        }

        [HttpPatch("{id}")]
        [Authorize(Policy = "AdminPolicy")]
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

            var infos = await _mediator.Send(command);
            return Ok(infos);
        }

        [HttpGet("{id}/total")]
        public async Task<IActionResult> AluguelTotal(Guid id)
        {
            AluguelTotalQuery query = new(id);
            var infos = await _mediator.Send(query);
            return Ok(infos);
        }

        [HttpGet("{carroId}/carro")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> ListarAlugueisCarro(Guid carroId)
        {
            ListarAlugueisCarroQuery query = new(carroId);
            var alugueis = await _mediator.Send(query);
            return Ok(alugueis);
        }

        [HttpGet("{clienteId}/cliente")]
        public async Task<IActionResult> ListarAlugueisCliente(Guid clienteId)
        {
            ListarAlugueisClienteQuery query = new(clienteId);
            var alugueis = await _mediator.Send(query);
            return Ok(alugueis);
        }
    }
}