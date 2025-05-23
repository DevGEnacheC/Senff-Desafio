﻿using AluguelCarros.Domain.Entities;
using MediatR;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Application.Exceptions;
using AluguelCarros.Application.Commands.Carros.Commands;
using AluguelCarros.Application.Events.Carros.Events;
using AluguelCarros.Domain.Repositories;

namespace AluguelCarros.Application.Commands.Carros.Handlers
{
    public class CriarCarroCommandHandler : IRequestHandler<CriarCarroCommand, Guid>
    {
        private readonly ICarroRepository _repository;
        private readonly IMediator _mediator;

        public CriarCarroCommandHandler(ICarroRepository carroRepository, IMediator mediator)
        {
            _repository = carroRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarCarroCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.ExistsByPlacaAsync(request.Placa, cancellationToken))
            {
                throw new FluentValidationException(
                [
                    new FluentValidation.Results.ValidationFailure("Placa", "A placa já está em uso.")
                ]);
            }

            var carro = new Carro(request.Marca, request.Modelo, request.Ano, request.Placa, request.Cor, request.PrecoDiaria);
            
            await _repository.AddAsync(carro);

            var evento = new CarroCriadoEvent(carro.Id, carro.Marca, carro.Modelo, carro.Ano, carro.Placa, carro.Cor, carro.PrecoDiaria);
            await _mediator.Publish(evento, cancellationToken);

            return carro.Id;
        }
    }
}
