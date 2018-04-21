using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Domains
{
    public class Country : BaseModel
    {
        public string Name { get; set; }

        public string Capital { get; set; }
    }
}
