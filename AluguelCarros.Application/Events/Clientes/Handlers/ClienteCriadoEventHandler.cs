using AluguelCarros.Application.Events.Clientes.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events.Clientes.Handlers
{
    public class ClienteCriadoEventHandler : INotificationHandler<ClienteCriadoEvent>
    {
        private readonly ILogger<ClienteCriadoEventHandler> _logger;

        public ClienteCriadoEventHandler(ILogger<ClienteCriadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ClienteCriadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Cliente criado: ID={Id}, Nome={Nome}, CPF={CPF}"
               ,notification.Id, notification.Nome, notification.CPF);
            return Task.CompletedTask;
        }
    }
}
