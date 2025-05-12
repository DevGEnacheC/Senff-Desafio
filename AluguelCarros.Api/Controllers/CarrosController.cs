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

        /// <summary>
        /// Adiciona um novo carro, quem pode acessar: Admin
        /// </summary>
        /// <returns>Id do carro criado</returns>
        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> CriarCarro([FromBody] CriarCarroCommand command)
        {
            var carroId = await _mediator.Send(command);
            return Ok(carroId);   
        }

        /// <summary>
        /// Mostra todos os carros filtrados por disponivel= true || flase, caso null retorna
        /// todos os carros, quem pode acessar: Cliente e Admin
        /// </summary>
        /// <returns>Lista de todos os carros filtrados(sim ou não) por disponibilidade</returns>
        [HttpGet]
        public async Task<IActionResult> ListarCarros([FromQuery] bool? disponivel)
        {
            var query = new ListarCarrosQuery(disponivel);
            var carros = await _mediator.Send(query);
            return Ok(carros);
        }

        /// <summary>
        /// Edita um carro, quem pode acessar: Admin
        /// </summary>
        /// <returns>Id do carro editado</returns>
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


        /// <summary>
        /// Deleta um carro se o mesmo não possuir nenhum vinculo com aluguel, quem pode acessar: Admin
        /// </summary>
        /// <returns>Id do carro deletado</returns>
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
