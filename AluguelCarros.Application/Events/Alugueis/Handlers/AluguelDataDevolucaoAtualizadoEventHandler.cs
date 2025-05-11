using AluguelCarros.Application.Events.Alugueis.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AluguelCarros.Application.Events.Alugueis.Handlers
{
    public class AluguelDataDevolucaoAtualizadoEventHandler : INotificationHandler<AluguelDataDevolucaoAtualizadoEvent>
    {
        private readonly ILogger<AluguelDataDevolucaoAtualizadoEventHandler> _logger;

        public AluguelDataDevolucaoAtualizadoEventHandler(ILogger<AluguelDataDevolucaoAtualizadoEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AluguelDataDevolucaoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Aluguel atualizado: Id={Id}, DataDevolucao={DataDevolucao}",
                notification.Id, notification.DataDevolucao);
            return Task.CompletedTask;
        }
    }
}
