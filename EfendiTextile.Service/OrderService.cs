using EfendiTextile.Data;
using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Service
{
    public interface IOrderService
    {
        void Insert(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
        void Delete(Guid id);
        Order Find(Guid id);
        IEnumerable<Order> GetAll();

    }
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> orderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderRepository = orderRepository;
        }

        public void Delete(Order entity)
        {
            orderRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var order = orderRepository.Find(id);
            if (order != null)
            {
                this.Delete(order);
            }
        }
        public Order Find(Guid id)
        {
            return orderRepository.Find(id);
        }
        public IEnumerable<Order> GetAll()
        {
            return orderRepository.GetAll();
        }
        public void Insert(Order entity)
        {
            orderRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }
        public void Update(Order entity)
        {
            var order = orderRepository.Find(entity.Id);
            order.UnitPrice = entity.UnitPrice;
            order.Quantity = entity.Quantity;
            orderRepository.Update(order);
            unitOfWork.SaveChanges();
        }
    }
}
