﻿using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepo customerRepo ;
        public CustomerManager(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public Customer AddCustomerDetails(Customer customer)
        {
            return this.customerRepo.AddCustomerDetails(customer);
        }

       

        public List<Customer> GetAllCustomerDetails(int userId)
        {
            return this.customerRepo.GetAllCustomerDetails(userId);
        }

        public Customer UpdateCustomerDetails(Customer customer)
        {
            return this.customerRepo.UpdateCustomerDetails(customer);
        }
    }
}
