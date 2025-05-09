using AluguelCarros.Infrastructure.Entities;
using AluguelCarros.Infrastructure.Data;
using MediatR;
using AluguelCarros.Application.Events;

namespace AluguelCarros.Application.Commands
{
    public class CriarCarroCommandHandler : IRequestHandler<CriarCarroCommand, Guid>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public CriarCarroCommandHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarCarroCommand request, CancellationToken cancellationToken)
        {
            var carro = new Carro(request.Marca, request.Modelo, request.Ano);
            _context.Carros.Add(carro);

            await _context.SaveChangesAsync(cancellationToken);

            var evento = new CarroCriadoEvent(carro.Id, carro.Marca, carro.Modelo, carro.Ano);
            await _mediator.Publish(evento, cancellationToken);

            return carro.Id;
        }
    }
}
