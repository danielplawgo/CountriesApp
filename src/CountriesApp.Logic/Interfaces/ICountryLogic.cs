using CountriesApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Logic.Interfaces
{
    public interface ICountryLogic : ILogic
    {
        Result<IEnumerable<Country>> GetAll();

        Result<Country> GetById(Guid id);

        Result<Country> Add(Country country);
    }
}
