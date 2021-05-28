using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface ICustomerManager
    {
        Customer AddCustomerDetails(Customer customer);
        int DeleteCustomer(int UserId, int CustomerId);
        Customer UpdateCustomerDetails(Customer customer);
        Customer GetAllCustomerDetails(Customer customer);


    }
}
