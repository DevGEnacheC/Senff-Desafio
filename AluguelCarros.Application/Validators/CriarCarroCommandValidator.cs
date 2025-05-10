using AluguelCarros.Application.Commands;
using FluentValidation;

namespace AluguelCarros.Application.Validators
{
    public class CriarCarroCommandValidator : AbstractValidator<CriarCarroCommand>
    {
        /// <summary>
        /// A diferença entre o ano atual e o de lançamento não deve ser maior que 30 anos.
        /// <b>Isso é uma regra de negócio ficticia!</b>
        /// </summary>
        readonly int minAno = DateTime.Now.Year - 30;
        const int minCharMarca = 50;
        const int minCharModelo = minCharMarca;

        /// <summary>
        ///  Máximo de 8 caracteres para uma placa no padrão Mercosul.
        ///  <b>Isso é uma regra de negócio ficticia!</b>
        ///  <br></br>
        ///  <i>Ex: ABC-1234 // 8 carcateres!</i>
        /// </summary>
        const int maxCharPlaca = 8; 
        public CriarCarroCommandValidator()
        {
            RuleFor(x => x.Ano)
                .GreaterThan(minAno).WithMessage(string.Format("O ano deve ser maior que {0}.", minAno))
                .LessThanOrEqualTo(DateTime.Now.Year + 1)
                .WithMessage("O ano não pode ser maior que o próximo ano.");

            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("A marca é obrigatória.")
                .MaximumLength(minCharMarca)
                    .WithMessage(string.Format("A marca não pode exceder {0} caracteres."
                    , minCharMarca));

            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("O modelo é obrigatório.")
                .MaximumLength(minCharModelo)
                    .WithMessage(string.Format("O modelo não pode exceder {0} caracteres."
                    , minCharModelo));

            RuleFor(x => x.Placa)
                .Cascade(CascadeMode.Continue)
                .NotEmpty().WithMessage("A placa é obrigatória.")
                .MaximumLength(maxCharPlaca)
                    .WithMessage(string.Format("A placa não pode exceder {0} caracteres."
                    , maxCharPlaca));
        }
    }
}
