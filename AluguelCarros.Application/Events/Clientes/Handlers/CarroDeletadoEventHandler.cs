using AluguelCarros.Application.Events.Clientes.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events.Clientes.Handlers
{
    public class ClienteDeletadoEventHandler : INotificationHandler<ClienteDeletadoEvent>
    {
        private readonly ILogger<ClienteDeletadoEventHandler> _logger;

        public ClienteDeletadoEventHandler(ILogger<ClienteDeletadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ClienteDeletadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Cliente deletado: ID={Id}.", notification.Id);
            return Task.CompletedTask;
        }
    }
}
