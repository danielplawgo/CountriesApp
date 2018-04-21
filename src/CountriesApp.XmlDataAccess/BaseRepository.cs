using CountriesApp.Domains;
using CountriesApp.Logic.Repositories;
using CountriesApp.Logic.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CountriesApp.XmlDataAccess
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private Lazy<IFileService> _fileService;

        protected IFileService FileService
        {
            get
            {
                return _fileService.Value;
            }
        }

        protected abstract string FileName
        {
            get;
        }

        public BaseRepository(Lazy<IFileService> fileService)
        {
            _fileService = fileService;
        }

        public T Add(T entity)
        {
            var data = Load();

            entity.Id = Guid.NewGuid();

            data.Add(entity);

            Save(data);

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return Load();
        }

        public T GetById(Guid id)
        {
            return Load().FirstOrDefault(e => e.Id == id);
        }

        private List<T> Load()
        {
            var path = FileService.MapPath(string.Format("data/{0}", FileName));

            using(var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                return serializer.Deserialize(stream) as List<T>;
            }
        }

        private void Save(List<T> data)
        {
            var path = FileService.MapPath(string.Format("data/{0}", FileName));

            using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                serializer.Serialize(stream, data);
            }
        }
    }
}
