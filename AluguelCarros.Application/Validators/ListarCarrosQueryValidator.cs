using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluguelCarros.Application.Queries;
using FluentValidation;

namespace AluguelCarros.Application.Validators
{
    public class ListarCarrosQueryValidator : AbstractValidator<ListarCarrosQuery>
    {
        public ListarCarrosQueryValidator()
        {
        }
    }
}
