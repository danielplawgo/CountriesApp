using CountriesApp.Domains;
using CountriesApp.Logic.Countries.Validators;
using CountriesApp.Logic.Interfaces;
using CountriesApp.Logic.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Logic.Countries
{
    public class CountryLogic : BaseLogic, ICountryLogic
    {
        private Lazy<ICountryRepository> _repository;

        protected ICountryRepository Repository
        {
            get
            {
                return _repository.Value;
            }
        }

        private Lazy<IValidator<Country>> _validator;

        protected IValidator<Country> Validator
        {
            get
            {
                return _validator.Value;
            }
        }

        public CountryLogic(Lazy<ICountryRepository> repository,
            Lazy<IValidator<Country>> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public Result<IEnumerable<Country>> GetAll()
        {
            return Result.Ok(Repository.GetAll());
        }

        public Result<Country> GetById(Guid id)
        {
            var country = Repository.GetById(id);

            if (country == null)
            {
                return Result.Failure<Country>(string.Format("Country doesn't exist."));
            }

            return Result.Ok(country);
        }

        public Result<Country> Add(Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException("country");
            }

            var validationResult = Validator.Validate(country);

            if (validationResult.IsValid == false)
            {
                return Result.Failure<Country>(validationResult.Errors);
            }

            Repository.Add(country);

            return Result.Ok(country);
        }
    }
}
