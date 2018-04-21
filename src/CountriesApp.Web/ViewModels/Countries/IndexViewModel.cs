using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesApp.Web.ViewModels.Countries
{
    public class IndexViewModel
    {
        public IEnumerable<IndexItemViewModel> Items { get; set; }
    }

    public class IndexItemViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Capital { get; set; }
    }
}