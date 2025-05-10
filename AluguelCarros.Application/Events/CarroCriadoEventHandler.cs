using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events
{
    public class CarroCriadoEventHandler : INotificationHandler<CarroCriadoEvent>
    {
        private readonly ILogger<CarroCriadoEventHandler> _logger;

        public CarroCriadoEventHandler(ILogger<CarroCriadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CarroCriadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Carro criado: ID={Id}, Marca={Marca}, Modelo={Modelo}, Ano={Ano}, Placa={Placa}",
                notification.Id, notification.Marca, notification.Modelo, notification.Ano, notification.Placa);
            return Task.CompletedTask;
        }
    }
}
