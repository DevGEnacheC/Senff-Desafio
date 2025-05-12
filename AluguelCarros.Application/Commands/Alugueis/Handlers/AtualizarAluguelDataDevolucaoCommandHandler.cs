using AluguelCarros.Application.Commands.Alugueis.Commands;
using AluguelCarros.Application.Events.Alugueis.Events;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Infrastructure.Data.Repositories;
using MediatR;
using AluguelCarros.Domain.Repositories;

namespace AluguelCarros.Application.Commands.Alugueis.Handlers
{
    public class AtualizarAluguelDataDevolucaoCommandHandler : IRequestHandler<AtualizarAluguelDataDevolucaoCommand, string>
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly ICarroRepository _carroRepository;
        private readonly IMediator _mediator;

        public AtualizarAluguelDataDevolucaoCommandHandler(
                    IAluguelRepository aluguelRepository,
                    ICarroRepository carroRepository,
                    IMediator mediator)
        {
            _aluguelRepository = aluguelRepository;
            _carroRepository = carroRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(AtualizarAluguelDataDevolucaoCommand request, CancellationToken cancellationToken)
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


            double valorNormal = aluguel.DiasNormais() * carro.PrecoDiaria;
            double taxaAtraso = (aluguel.DiasAtraso() * carro.PrecoDiaria) * 1.55;

            return string.Format("Valor do aluguel: R${0} | Taxa por atraso: R${1} | Total: R${2}", 
                valorNormal, 
                taxaAtraso, valorNormal + taxaAtraso);
        }
    }
}
