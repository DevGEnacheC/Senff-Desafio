using AluguelCarros.Application.Events.Clientes.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events.Clientes.Handlers
{
    public class ClienteAtualizadoEventHandler : INotificationHandler<ClienteAtualizadoEvent>
    {
        private readonly ILogger<ClienteCriadoEventHandler> _logger;

        public ClienteAtualizadoEventHandler(ILogger<ClienteCriadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ClienteAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Cliente atualizado: ID={Id}, Nome={Nome}, CPF={CPF}"
               , notification.Id, notification.Nome, notification.CPF);
            return Task.CompletedTask;
        }
    }
}
