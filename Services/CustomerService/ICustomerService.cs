

using System.Collections.Generic;

namespace WebAPIStarter.Services.CustomerService
{
    public interface IServiceOfT<T>
    {
        IList<T> GetAll();
        T GetOne(int id);
        T Add(T newCustomer);
        void Update(T updatedCustomer);
        void Delete(T deletedCustomer);
    }
}