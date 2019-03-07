using EfendiTextile.Data;
using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Service
{
    public interface IBillService
    {
        void Insert(Bill entity);
        void Update(Bill entity);
        void Delete(Bill entity);
        void Delete(Guid id);
        Bill Find(Guid id);
        IEnumerable<Bill> GetAll();
        IEnumerable<Bill> GetAllByName(string name);
        IEnumerable<Bill> Search(string name);
    }

    public class BillService : IBillService
    {
        private readonly IRepository<Bill> billRepository;
        private readonly IUnitOfWork unitOfWork;
        public BillService(IUnitOfWork unitOfWork, IRepository<Bill> billRepository)
        {
            this.unitOfWork = unitOfWork;
            this.billRepository = billRepository;
        }
        public void Delete(Bill entity)
        {
            billRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var bill = billRepository.Find(id);
            if (bill != null)
            {
                this.Delete(bill);
            }
        }

        public Bill Find(Guid id)
        {
            return billRepository.Find(id);
        }

        public IEnumerable<Bill> GetAll()
        {
            return billRepository.GetAll();
        }

        public IEnumerable<Bill> GetAllByName(string name)
        {
            return billRepository.GetAll(w => w.Title.Contains(name));
        }

        public void Insert(Bill entity)
        {
            billRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Bill> Search(string name)
        {
            return billRepository.GetAll(e => e.Title.Contains(name));
        }

        public void Update(Bill entity)
        {
            var bill = billRepository.Find(entity.Id);
            bill.Title = entity.Title;
            bill.Description = entity.Description;
            billRepository.Update(bill);
            unitOfWork.SaveChanges();
        }
    }


}
