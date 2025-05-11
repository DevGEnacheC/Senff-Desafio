using AluguelCarros.Application.Commands.Alugueis.Commands;
using AluguelCarros.Application.Events.Alugueis.Events;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Infrastructure.Data;
using MediatR;

namespace AluguelCarros.Application.Commands.Alugueis.Handlers
{
    public class AtualizarAluguelDataDevolucaoCommandHandler : IRequestHandler<AtualizarAluguelDataDevolucaoCommand, Guid>
    {
        private readonly AluguelRepository _aluguelRepository;
        private readonly CarroRepository _carroRepository;
        private readonly IMediator _mediator;

        public AtualizarAluguelDataDevolucaoCommandHandler(AppDbContext context, IMediator mediator)
        {
            _aluguelRepository = new(context);
            _carroRepository = new(context);
            _mediator = mediator;
        }

        public async Task<Guid> Handle(AtualizarAluguelDataDevolucaoCommand request, CancellationToken cancellationToken)
        {
            var aluguel = await _aluguelRepository.GetByIdAsync(request.Id);

            if (aluguel == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Id",
                    "O aluguel especificado não existe.")
                ]);
            }

            if (aluguel.DataDevolucao != null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("DataDevolucao",
                    "O aluguel já foi finalizado, não é possivel alterar a data de devolução.")
                ]);
            }

            if (request.DataDevolucao < aluguel.DataInicio)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("DataDevolucao",
                    "A data de devolução não pode ser menor que a data inicio.")
                ]);
            }
            var carro = await _carroRepository.GetByIdAsync(aluguel.CarroId);
            if(carro == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("CarroId",
                    "O carro especificado não existe.")
                ]);
            }

            aluguel.Devolver(request.DataDevolucao);
            await _aluguelRepository.UpdateAsync(aluguel);

            carro.Liberar();
            await _carroRepository.UpdateAsync(carro);

            var evento = new AluguelDataDevolucaoAtualizadoEvent(aluguel.Id, aluguel.DataDevolucao);
            await _mediator.Publish(evento, cancellationToken);

            return aluguel.Id;
        }
    }
}
