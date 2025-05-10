using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluguelCarros.Application.Commands.Clientes.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators.Clientes
{
    public class CriarClienteCommandValidator : AbstractValidator<CriarClienteCommand>
    {
        const int maxCharNome = 100;

        /// <summary>
        ///  Máximo de 11 caracteres para um CPF no padrão do Brasil.
        /// </summary>
        const int lengthCPF= 11;

        public CriarClienteCommandValidator()
        {

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(maxCharNome)
                    .WithMessage(string.Format("O nome não pode exceder {0} caracteres.", maxCharNome));

            RuleFor(x => x.CPF)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O cpf é obrigatório.")
                .Length(lengthCPF)
                    .WithMessage(string.Format("O CPF deve conter {0} caracteres."
                    , lengthCPF));


        }
    }
}
