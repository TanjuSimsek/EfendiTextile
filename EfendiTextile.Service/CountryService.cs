using EfendiTextile.Data;
using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Service
{
    public interface ICountryService {
        void Insert(Country entity);
        void Update(Country entity);
        void Delete(Country entity);
        void Delete(Guid id);
        Country Find(Guid id);
        IEnumerable<Country> GetAll();
        IEnumerable<Country> GetAllByName(string name);
        IEnumerable<Country> Search(string name);

    }
   public class CountryService: ICountryService
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CountryService(IUnitOfWork unitOfWork, IRepository<Country> countryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.countryRepository = countryRepository;
        }

        public void Delete(Country entity)
        {
            countryRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var country = countryRepository.Find(id);
            if (country != null)
            {
                this.Delete(country);
            }
        }

        public Country Find(Guid id)
        {
            return countryRepository.Find(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return countryRepository.GetAll();
        }

        public IEnumerable<Country> GetAllByName(string name)
        {
            return countryRepository.GetAll(w => w.CountryName.Contains(name));
        }

        public void Insert(Country entity)
        {
            countryRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Country> Search(string name)
        {
            return countryRepository.GetAll(e => e.CountryName.Contains(name));
        }

        public void Update(Country entity)
        {
            var country = countryRepository.Find(entity.Id);
            country.CountryName = entity.CountryName;
           
            countryRepository.Update(country);
            unitOfWork.SaveChanges();
        }
    }
}
