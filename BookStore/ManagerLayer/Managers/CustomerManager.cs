using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepo customerRepo;
        public Customer AddCustomerDetails(Customer customer)
        {
            return this.customerRepo.AddCustomerDetails(customer);
        }

        public int DeleteCustomer(int UserId, int CustomerId)
        {
            return this.customerRepo.DeleteCustomer(UserId,CustomerId);
        }

        public Customer GetAllCustomerDetails(Customer customer)
        {
            return this.customerRepo.GetAllCustomerDetails(customer);
        }

        public Customer UpdateCustomerDetails(Customer customer)
        {
            return this.customerRepo.UpdateCustomerDetails(customer);
        }
    }
}
