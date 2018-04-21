using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesApp.Web.App_Start.AutofacModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assembly = typeof(MvcApplication).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();
        }
    }
}