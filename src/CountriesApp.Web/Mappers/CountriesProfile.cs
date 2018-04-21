using AutoMapper;
using CountriesApp.Domains;
using CountriesApp.Web.ViewModels.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesApp.Web.Mappers
{
    public class CountriesProfile : Profile
    {
        public CountriesProfile()
        {
            CreateMap<Country, IndexItemViewModel>();

            CreateMap<Country, CountryViewModel>()
                .ReverseMap();
        }
    }
}