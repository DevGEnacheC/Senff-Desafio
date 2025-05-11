using AluguelCarros.Application.Commands.Carros.Commands;
using AluguelCarros.Application.Commands.Clientes.Commands;
using AluguelCarros.Application.Queries.Clientes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CriarClienteCommand command)
        {
            var cliente = await _mediator.Send(command);
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            var query = new ListarClientesQuery();
            var clientes = await _mediator.Send(query);
            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(Guid id, [FromBody] AtualizarClienteCommand command)
        {
            // Para seguir o padrão RESTFull é enviado o id como path parameter
            if (id != command.Id)
                return BadRequest("Id da rota e do body não coincidem");

            var clienteId = await _mediator.Send(command);
            return Ok(clienteId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCliente(Guid id)
        {
            var command = new DeletarClienteCommand(id);
            var carroId = await _mediator.Send(command);
            return Ok(carroId);
        }
    }
}
