
using AluguelCarros.Domain.Entities;
using MediatR;
using AluguelCarros.Domain.Repositories;
using AluguelCarros.Application.Queries.Alugueis.Queries;
using AluguelCarros.Application.Exceptions;

namespace AluguelCarros.Application.Queries.Alugueis.Handlers
{
    public class ListarAlugueisCleinteQueryHandler : IRequestHandler<ListarAlugueisClienteQuery, List<Aluguel>>
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IClienteRepository _clienteRepository;

        public ListarAlugueisCleinteQueryHandler(
            IAluguelRepository aluguelRepository,
            IClienteRepository clienteRepository)
        {
            _aluguelRepository = aluguelRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Aluguel>> Handle(ListarAlugueisClienteQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId);
           
            if (cliente == null)
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("ClienteId",
                    "O cliente especificado não existe.")
                ]);
            }

            return await _aluguelRepository.GetByCliente(request.ClienteId);
        }
    }
}
