using CountriesApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Logic.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        T Add(T entity);
    }
}
