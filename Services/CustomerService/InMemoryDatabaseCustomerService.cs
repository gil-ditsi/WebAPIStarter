using System.Collections.Generic;
using WebAPIStarter.Data;
using WebAPIStarter.Data.Models;
using System.Linq;

namespace WebAPIStarter.Services.CustomerService
{
    public class InMemoryDatabaseCustomerService : IServiceOfT<Customer>
    {
        private WebAPIStarterContext context;

        public InMemoryDatabaseCustomerService(WebAPIStarterContext context)
        {
            this.context = context;
        }
        public Customer Add(Customer newCustomer)
        {
            var updatedEntityEntry = this.context.Customers.Add(newCustomer);
            this.context.SaveChanges(); //Temporary?
            return updatedEntityEntry.Entity;
        }

        public void Delete(Customer deletedCustomer)
        {
            this.context.Customers.Remove(deletedCustomer);
            this.context.SaveChanges(); //Temporary?
        }

        public IList<Customer> GetAll()
        {
            return this.context.Customers.ToList();
        }

        public Customer GetOne(int id)
        {
            return this.context.Customers.Find(id);
        }

        public void Update(Customer updatedCustomer)
        {
            this.context.Customers.Update(updatedCustomer);
            this.context.SaveChanges(); //Temporary?
        }

        ~InMemoryDatabaseCustomerService(){
            //It depends on the injection of the service //Transient Vs Singleton
            this.context.SaveChanges();
        }
    }
}