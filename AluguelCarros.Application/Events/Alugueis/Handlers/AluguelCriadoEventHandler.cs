using AluguelCarros.Application.Events.Alugueis.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events.Alugueis.Handlers
{
    public class AluguelCriadoEventHandler : INotificationHandler<AluguelCriadoEvent>
    {
        private readonly ILogger<AluguelCriadoEventHandler> _logger;

        public AluguelCriadoEventHandler(ILogger<AluguelCriadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AluguelCriadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Aluguel criado: Id={Id}, CarroId={CarroId}, ClienteId={ClienteId}, DataInicio={DataInicio}, DataFim={DataFim}, ValorAluguel={ValorAluguel}",
                notification.Id, 
                notification.CarroId, notification.ClienteId, 
                notification.DataInicio, notification.DataFim,
                notification.ValorAluguel);
            return Task.CompletedTask;
        }
    }
}
