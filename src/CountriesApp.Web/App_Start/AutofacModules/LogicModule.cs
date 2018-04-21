using Autofac;
using CountriesApp.Logic;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesApp.Web.App_Start.AutofacModules
{
    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(BaseLogic).Assembly)
                .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(typeof(BaseLogic).Assembly)
            //    .Where(t => typeof(AbstractValidator<>).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic);
        }
    }
}