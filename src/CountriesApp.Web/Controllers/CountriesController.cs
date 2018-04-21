using AutoMapper;
using CountriesApp.Domains;
using CountriesApp.Logic;
using CountriesApp.Logic.Interfaces;
using CountriesApp.Web.ViewModels.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountriesApp.Web.Controllers
{
    public partial class CountriesController : Controller
    {
        private Lazy<ICountryLogic> _countryLogic;

        protected ICountryLogic CountryLogic
        {
            get
            {
                return _countryLogic.Value;
            }
        }

        private IMapper Mapper { get; set; }

        public CountriesController(Lazy<ICountryLogic> countryLogic,
            IMapper mapper)
        {
            _countryLogic = countryLogic;
            Mapper = mapper;
        }

        // GET: Countries
        public virtual ActionResult Index()
        {
            var result = CountryLogic.GetAll();

            var viewModel = new IndexViewModel();

            viewModel.Items = Mapper.Map<IEnumerable<IndexItemViewModel>>(result.Value);

            return View(viewModel);
        }

        public virtual ActionResult Details(Guid id)
        {
            var result = CountryLogic.GetById(id);

            if (result.Success == false)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<CountryViewModel>(result.Value);

            return View(viewModel);
        }

        public virtual ActionResult Create()
        {
            return View(new CountryViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(CountryViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }

            var country = Mapper.Map<Country>(viewModel);

            var result = CountryLogic.Add(country);

            if (result.Success == false)
            {
                result.AddErrorToModelState(ModelState);
                return View(viewModel);
            }

            return RedirectToAction(MVC.Countries.Index());
        }
    }
}