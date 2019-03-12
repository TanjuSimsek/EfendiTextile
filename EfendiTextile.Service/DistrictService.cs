using EfendiTextile.Data;
using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Service
{
    public interface IDistrictService
    {
        void Insert(District entity);
        void Update(District entity);
        void Delete(District entity);
        void Delete(Guid id);
        District Find(Guid id);
        IEnumerable<District> GetAll();
        IEnumerable<District> GetAllByName(string name);
        IEnumerable<District> Search(string name);
    }
    public class DistrictService :IDistrictService
    {

        private readonly IRepository<District> districtRepository;
        private readonly IUnitOfWork unitOfWork;
        public DistrictService(IUnitOfWork unitOfWork, IRepository<District> districtRepository)
        {
            this.unitOfWork = unitOfWork;
            this.districtRepository = districtRepository;
        }

        public void Delete(District entity)
        {
            districtRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var district = districtRepository.Find(id);
            if (district != null)
            {
                this.Delete(district);
            }
        }

        public District Find(Guid id)
        {
            return districtRepository.Find(id);
        }

        public IEnumerable<District> GetAll()
        {
            return districtRepository.GetAll();
        }

        public IEnumerable<District> GetAllByName(string name)
        {
            return districtRepository.GetAll(w => w.DistrictName.Contains(name));

        }

        public void Insert(District entity)
        {
            districtRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<District> Search(string name)
        {
            return districtRepository.GetAll(e => e.DistrictName.Contains(name));
        }

        public void Update(District entity)
        {
            var district = districtRepository.Find(entity.Id);
            district.DistrictName = entity.DistrictName;
            districtRepository.Update(district);
            unitOfWork.SaveChanges();
        }
    }
}
