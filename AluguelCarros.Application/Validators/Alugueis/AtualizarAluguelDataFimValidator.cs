using AluguelCarros.Application.Commands.Alugueis.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Alugueis
{
    public class AtualizarAluguelDataFimValidator : AbstractValidator<AtualizarAluguelDataFimCommand>
    {
        /// <summary>
        /// A validação é feita dentro do command handler por falta de informações
        /// </summary>
        public AtualizarAluguelDataFimValidator()
        {
        }
    }
}
