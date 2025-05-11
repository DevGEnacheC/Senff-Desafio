using AluguelCarros.Application.Commands.Alugueis.Commands;
using AluguelCarros.Application.Events.Alugueis.Events;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Domain.Repositories;
using MediatR;

namespace AluguelCarros.Application.Commands.Alugueis.Handlers
{
    public class AtualizarAluguelDataFimCommandHandler : IRequestHandler<AtualizarAluguelDataFimCommand, Guid>
    {
        private readonly IAluguelRepository _repository;
        private readonly IMediator _mediator;

        public AtualizarAluguelDataFimCommandHandler(
            IAluguelRepository aluguelRepository, 
            IMediator mediator)
        {
            _repository = aluguelRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(AtualizarAluguelDataFimCommand request, CancellationToken cancellationToken)
        {
            var aluguel = await _repository.GetByIdAsync(request.Id);
                
            if(aluguel == null)
            {
               throw new FluentValidationException(
               [
                   new FluentValidation.Results.ValidationFailure("Id", 
                    "O aluguel especificado não existe.")
               ]);
            }

            if (aluguel.DataInicio > request.DataFim)
            {
               throw new FluentValidationException(
               [
                   new FluentValidation.Results.ValidationFailure("DataFim", 
                    "A data fim não pode ser menor que a data inicio.")
               ]);
            }

            aluguel.UpdateDataFim(request.DataFim);

            await _repository.UpdateAsync(aluguel);

            var evento = new AluguelDataFimAtualizadoEvent(aluguel.Id, aluguel.DataFim);
            await _mediator.Publish(evento, cancellationToken);

            return aluguel.Id;
        }
    }
}
