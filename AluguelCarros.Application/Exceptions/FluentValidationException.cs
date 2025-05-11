using FluentValidation.Results;

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
