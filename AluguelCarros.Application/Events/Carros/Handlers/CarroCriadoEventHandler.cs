using AluguelCarros.Application.Events.Carros.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events.Carros.Handlers
{
    public class CarroCriadoEventHandler : INotificationHandler<CarroAtualizadoEvent>
    {
        private readonly ILogger<CarroCriadoEventHandler> _logger;

        public CarroCriadoEventHandler(ILogger<CarroCriadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CarroAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Carro atualizado: ID={Id}, Marca={Marca}, Modelo={Modelo}, Ano={Ano}, Placa={Placa}, Cor={Cor}, PrecoDiaria={PrecoDiaria}",
                notification.Id, notification.Marca, notification.Modelo, notification.Ano, notification.Placa, notification.Cor, notification.PrecoDiaria);
            return Task.CompletedTask;
        }
    }
}
