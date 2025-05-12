using MediatR;

namespace AluguelCarros.Application.Queries.Alugueis.Queries
{
    public class AluguelTotalQuery : IRequest<string>
    {
        public Guid Id { get; set; }

        public AluguelTotalQuery(Guid id)
        {
            Id = id;
        }
    }
}
