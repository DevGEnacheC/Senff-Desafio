using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _logger.LogInformation("Carro criado: ID={Id}, Marca={Marca}, Modelo={Modelo}, Ano={Ano}",
                notification.Id, notification.Marca, notification.Modelo, notification.Ano);
            return Task.CompletedTask;
        }
    }
}
