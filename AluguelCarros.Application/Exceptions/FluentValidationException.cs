using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AluguelCarros.Application.Exceptions
{
    public class FluentValidationException : Exception
    {
        public List<ValidationError> Errors { get; }

        public FluentValidationException(IEnumerable<ValidationFailure> failures)
            : base("Erros de validação")
        {
            Errors = [.. failures
                .Select(f => new ValidationError
                {
                    Campo = f.PropertyName,
                    Erro = f.ErrorMessage
                })];
        }
    }

    public class ValidationError
    {
        public required string Campo { get; set; }
        public required string Erro { get; set; }
    }
}
