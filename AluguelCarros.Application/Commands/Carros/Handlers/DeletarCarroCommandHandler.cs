using AluguelCarros.Infrastructure.Data.Repositories;
using MediatR;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Application.Events.Carros.Events;
using AluguelCarros.Domain.Repositories;

namespace AluguelCarros.Application.Commands.Carros.Commands
{
    public class DeletarCarroCommandHandler : IRequestHandler<DeletarCarroCommand, Guid>
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IMediator _mediator;

        public DeletarCarroCommandHandler(
            ICarroRepository carroRepository,
            IAluguelRepository aluguelRepository, 
            IMediator mediator)
        {
            _carroRepository = carroRepository;
            _aluguelRepository = aluguelRepository;
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
