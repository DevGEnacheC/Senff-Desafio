using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluguelCarros.Infrastructure.Entities;
using MediatR;

namespace AluguelCarros.Application.Queries
{
    public class ListarCarrosQuery : IRequest<List<Carro>>
    {
    }
}
