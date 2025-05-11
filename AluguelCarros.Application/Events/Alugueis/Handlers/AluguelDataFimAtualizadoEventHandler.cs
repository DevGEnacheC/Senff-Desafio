using AluguelCarros.Application.Events.Alugueis.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events.Alugueis.Handlers
{
    public class AluguelDataFimAtualizadoEventHandler : INotificationHandler<AluguelDataFimAtualizadoEvent>
    {
        private readonly ILogger<AluguelDataFimAtualizadoEventHandler> _logger;

        public AluguelDataFimAtualizadoEventHandler(ILogger<AluguelDataFimAtualizadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AluguelDataFimAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Aluguel atualizado: Id={Id}, DataFim={DataFim}",
                notification.Id, notification.DataFim);
            return Task.CompletedTask;
        }
    }
}
