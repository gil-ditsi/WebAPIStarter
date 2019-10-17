using System.Collections.Generic;
using WebAPIStarter.Data.Models;

namespace WebAPIStarter.Services.CustomerService
{
    public class InMemoryCustomerService : IServiceOfT<Customer>
    {
        private IList<Customer> Customers { get; set; }

        public InMemoryCustomerService(IList<Customer> customers = null)
        {
            this.Customers = customers ?? new List<Customer>();
        }
        public Customer Add(Customer newCustomer)
        {
            newCustomer.Id = this.Customers.Count + 1;
            this.Customers.Add(newCustomer);
            return newCustomer;
        }

        public void Delete(Customer deletedCustomer)
        {
            this.Customers.Remove(deletedCustomer);
        }

        public IList<Customer> GetAll()
        {
            return this.Customers;
        }

        public Customer GetOne(int id)
        {
            foreach (var customer in this.Customers)
            {
                if(customer.Id == id)
                    return customer;
            }
            return null;
        }

        public void Update(Customer updatedCustomer)
        {
            foreach (var customer in this.Customers)
            {
                if(customer.Id == updatedCustomer.Id)
                    customer.FirstName = updatedCustomer.FirstName;
                    customer.Email = updatedCustomer.Email;
                    customer.LastName = updatedCustomer.LastName;
            }
        }
    }
}