using EfendiTextile.Data;
using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Service
{
    public interface IOfferService
    {
        void Insert(Offer entity);
        void Update(Offer entity);
        void Delete(Offer entity);
        void Delete(Guid id);
        Offer Find(Guid id);
        IEnumerable<Offer> GetAll();
    }
    public class OfferService : IOfferService
    {
        private readonly IRepository<Offer> offerRepository;
        private readonly IUnitOfWork unitOfWork;
        public OfferService(IUnitOfWork unitOfWork, IRepository<Offer> offerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.offerRepository = offerRepository;
        }

        public void Delete(Offer entity)
        {
            offerRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var offer = offerRepository.Find(id);
            if (offer != null)
            {
                this.Delete(offer);
            }
        }

        public Offer Find(Guid id)
        {
            return offerRepository.Find(id);
        }

        public IEnumerable<Offer> GetAll()
        {
            return offerRepository.GetAll();
        }

        public void Insert(Offer entity)
        {
            offerRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public void Update(Offer entity)
        {
            var offer = offerRepository.Find(entity.Id);
            offer.OfferPrice = entity.OfferPrice;
            offer.Description = entity.Description;
            offerRepository.Update(offer);
            unitOfWork.SaveChanges();
        }
    }

}