using CountriesApp.Domains;
using CountriesApp.Logic.Repositories;
using CountriesApp.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.XmlDataAccess
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        protected override string FileName => "countries.xml";

        public CountryRepository(Lazy<IFileService> fileService) : base(fileService)
        {
        }
    }
}
