using CountriesApp.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Logic.Countries.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.Capital)
                .NotEmpty();
        }
    }
}
