using CountriesApp.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesApp.Web.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", path));
        }
    }
}