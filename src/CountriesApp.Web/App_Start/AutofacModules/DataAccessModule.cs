using Autofac;
using CountriesApp.XmlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesApp.Web.App_Start.AutofacModules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                .AsImplementedInterfaces();
        }
    }
}