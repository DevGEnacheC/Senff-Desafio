using AluguelCarros.Application.Commands.Clientes.Commands;
using AluguelCarros.Application.Queries.Clientes.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adiciona um novo cliente, quem pode acessar: Cliente e Admin
        /// </summary>
        /// <returns>Id do cliente criado</returns>
        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CriarClienteCommand command)
        {
            var cliente = await _mediator.Send(command);
            return Ok(cliente);
        }

        /// <summary>
        /// Mostra todos os clientes, quem pode acessar: Admin
        /// </summary>
        /// <returns>Lista de todos os clientes</returns>
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> ListarClientes()
        {
            var query = new ListarClientesQuery();
            var clientes = await _mediator.Send(query);
            return Ok(clientes);
        }

        /// <summary>
        /// Edita um cliente, quem pode acessar: Cliente Admin
        /// </summary>
        /// <returns>Id do cliente editado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(Guid id, [FromBody] AtualizarClienteCommand command)
        {
            // Para seguir o padrão RESTFull é enviado o id como path parameter
            if (id != command.Id)
                return BadRequest("Id da rota e do body não coincidem");

            var clienteId = await _mediator.Send(command);
            return Ok(clienteId);
        }

        /// <summary>
        /// Deleta um cliente se o mesmo não possuir nenhum vinculo com aluguel, quem pode acessar: Admin
        /// </summary>
        /// <returns>Id do cliente deletado</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeletarCliente(Guid id)
        {
            var command = new DeletarClienteCommand(id);
            var carroId = await _mediator.Send(command);
            return Ok(carroId);
        }
    }
}
