using AluguelCarros.Application.Exceptions;
using AluguelCarros.Application.Queries.Alugueis.Queries;
using AluguelCarros.Domain.Repositories;
using MediatR;

namespace AluguelCarros.Application.Queries.Alugueis.Handlers
{
    public class AluguelTotalQueryHandler : IRequestHandler<AluguelTotalQuery, string>
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly ICarroRepository _carroRepository;

        public AluguelTotalQueryHandler(IAluguelRepository aluguelRepository, ICarroRepository carroRepository)
        {
            _aluguelRepository = aluguelRepository;
            _carroRepository = carroRepository;
        }

        public async Task<string> Handle(AluguelTotalQuery request, CancellationToken cancellationToken)
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

            var carro = await _carroRepository.GetByIdAsync(aluguel.CarroId);
            if (carro == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("CarroId",
                    "O carro especificado não existe.")
                ]);
            }

            double valorNormal = aluguel.DiasNormais() * carro.PrecoDiaria;
            double taxaAtraso = (aluguel.DiasAtraso() * carro.PrecoDiaria) * 1.55;

            return string.Format("Valor do aluguel: R${0} | Taxa por atraso: R${1} | Total: {2}",
                valorNormal,
                taxaAtraso, 
                valorNormal + taxaAtraso);
        }
    }
}
