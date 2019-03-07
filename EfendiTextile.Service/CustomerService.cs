using EfendiTextile.Data;
using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Service
{
    public interface ICustomerService
    {
        void Insert(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
        void Delete(Guid id);
        Customer Find(Guid id);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> GetAllByName(string name);
        IEnumerable<Customer> Search(string name);
    }
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> customerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.customerRepository = customerRepository;
        }

        public void Delete(Customer entity)
        {
            customerRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var customer = customerRepository.Find(id);
            if (customer != null)
            {
                this.Delete(customer);
            }
        }

        public Customer Find(Guid id)
        {
            return customerRepository.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public IEnumerable<Customer> GetAllByName(string name)
        {
            return customerRepository.GetAll(w => w.CustomerName.Contains(name));
        }

        public void Insert(Customer entity)
        {
            customerRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Customer> Search(string name)
        {
            return customerRepository.GetAll(e => e.CustomerName.Contains(name));
        }

        public void Update(Customer entity)
        {
            var customer = customerRepository.Find(entity.Id);
            customer.CustomerName = entity.CustomerName;
            customer.Debt = entity.Debt;
            customer.Demand = entity.Demand;
            customer.Balance = entity.Balance;
            customer.CustomerSurname = entity.CustomerSurname;
            customer.Phone = entity.Phone;
            customer.Email = entity.Email;
            customer.Address = entity.Address;
            customer.Description = entity.Description;
            customerRepository.Update(customer);
            unitOfWork.SaveChanges();
        }
    }

}