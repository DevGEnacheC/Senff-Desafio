using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Infrastructure.Data;
using MediatR;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Application.Events.Carros.Events;

namespace AluguelCarros.Application.Commands.Carros.Commands
{
    public class DeletarCarroCommandHandler : IRequestHandler<DeletarCarroCommand, Guid>
    {
        private readonly CarroRepository _carroRepository;
        private readonly AluguelRepository _aluguelRepository;
        private readonly IMediator _mediator;

        public DeletarCarroCommandHandler(AppDbContext context, IMediator mediator)
        {
            _aluguelRepository = new(context);
            _carroRepository = new(context);
            _mediator = mediator;
        }

        public async Task<Guid> Handle(DeletarCarroCommand request, CancellationToken cancellationToken)
        {
            var carro = await _carroRepository.GetByIdAsync(request.Id);

            if (carro == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Id", "O carro especificado não existe.")
                ]);
            }

            bool temAlugueisVinculados = await _aluguelRepository.CheckCarAvailabilityAsync(request.Id, cancellationToken);
            if (temAlugueisVinculados)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Id", "O carro não pode ser deletado pois possui aluguéis vinculados.")
                ]);
            }

            await _carroRepository.DeleteAsync(carro, cancellationToken);

            var evento = new CarroDeletadoEvent(carro.Id);
            await _mediator.Publish(evento, cancellationToken);

            return carro.Id;
        }
    }
}
