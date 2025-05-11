using AluguelCarros.Application.Events.Carros.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events.Carros.Handlers
{
    public class CarroDeletadoEventHandler : INotificationHandler<CarroDeletadoEvent>
    {
        private readonly ILogger<CarroDeletadoEventHandler> _logger;

        public CarroDeletadoEventHandler(ILogger<CarroDeletadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CarroDeletadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Carro deletado: ID={Id}.", notification.Id);
            return Task.CompletedTask;
        }
    }
}
