﻿using ModelsLayer;
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
       
        Customer UpdateCustomerDetails(Customer customer);
        List<Customer> GetAllCustomerDetails(int userId);


    }
}
