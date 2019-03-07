using EfendiTextile.Data;
using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Service
{
    public interface IProductService
    {
        void Insert(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        void Delete(Guid id);
        Product Find(Guid id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllByName(string name);
        IEnumerable<Product> Search(string name);
    }
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }

        public void Delete(Product entity)
        {
            productRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = productRepository.Find(id);
            if (product != null)
            {
                this.Delete(product);
            }
        }

        public Product Find(Guid id)
        {
            return productRepository.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByName(string name)
        {
            return productRepository.GetAll(w => w.ProductName.Contains(name));
        }

        public void Insert(Product entity)
        {
            productRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Product> Search(string name)
        {
            return productRepository.GetAll(e => e.ProductName.Contains(name));
        }

        public void Update(Product entity)
        {
            var product = productRepository.Find(entity.Id);
            product.ProductName = entity.ProductName;
            product.QuantityPerUnit = entity.QuantityPerUnit;
            product.BuyyingPrice = entity.BuyyingPrice;
            product.UnıtsInStock = entity.UnıtsInStock;
            productRepository.Update(product);
            unitOfWork.SaveChanges();
        }
    }
}