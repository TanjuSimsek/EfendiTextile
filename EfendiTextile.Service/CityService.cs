using EfendiTextile.Data;
using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Service
{
    public interface ICityService
    {
        void Insert(City entity);
        void Update(City entity);
        void Delete(City entity);
        void Delete(Guid id);
        City Find(Guid id);
        IEnumerable<City> GetAll();
        IEnumerable<City> GetAllByName(string name);
        IEnumerable<City> Search(string name);
    }
    public class CityService :ICityService
    {
        private readonly IRepository<City> cityRepository;
        private readonly IUnitOfWork unitOfWork;
        public CityService(IUnitOfWork unitOfWork, IRepository<City> cityRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cityRepository = cityRepository;
        }

        public void Delete(City entity)
        {
            cityRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var city = cityRepository.Find(id);
            if (city != null)
            {
                this.Delete(city);
            }
        }

        public City Find(Guid id)
        {
            return cityRepository.Find(id);
        }

        public IEnumerable<City> GetAll()
        {
            return cityRepository.GetAll();
        }

        public IEnumerable<City> GetAllByName(string name)
        {
            return cityRepository.GetAll(w => w.CityName.Contains(name));
        }

        public void Insert(City entity)
        {
            cityRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<City> Search(string name)
        {
            return cityRepository.GetAll(e => e.CityName.Contains(name));
        }

        public void Update(City entity)
        {
            var city = cityRepository.Find(entity.Id);
            city.CityName = entity.CityName;       
            cityRepository.Update(city);
            unitOfWork.SaveChanges();
        }
    }
}
