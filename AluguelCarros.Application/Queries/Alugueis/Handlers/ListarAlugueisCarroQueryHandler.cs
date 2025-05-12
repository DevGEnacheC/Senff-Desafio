
using AluguelCarros.Domain.Entities;
using MediatR;
using AluguelCarros.Domain.Repositories;
using AluguelCarros.Application.Queries.Alugueis.Queries;
using AluguelCarros.Application.Exceptions;

namespace AluguelCarros.Application.Queries.Alugueis.Handlers
{
    public class ListarAlugueisCarroQueryHandler : IRequestHandler<ListarAlugueisCarroQuery, List<Aluguel>>
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly ICarroRepository _carroRepository;

        public ListarAlugueisCarroQueryHandler(
            IAluguelRepository aluguelRepository, 
            ICarroRepository carroRepository)
        {
            _aluguelRepository = aluguelRepository;
            _carroRepository = carroRepository;
        }

        public async Task<List<Aluguel>> Handle(ListarAlugueisCarroQuery request, CancellationToken cancellationToken)
        {
            var carro = await _carroRepository.GetByIdAsync(request.CarroId);
           
            if (carro == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("CarroId",
                    "O carro especificado não existe.")
                ]);
            }

            return await _aluguelRepository.GetByCarro(request.CarroId);
        }
    }
}
