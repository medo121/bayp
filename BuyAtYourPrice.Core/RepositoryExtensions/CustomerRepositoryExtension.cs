using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuyAtYourPrice.Core.Domain;
using BuyAtYourPrice.Data.Contracts;

namespace BuyAtYourPrice.Core.RepositoryExtensions
{
    public static class CustomerRepositoryExtension
    {
        public static Customer GetCustomerForUser(this IRepository<Customer> customerRepository, string username)
        {
            return customerRepository.GetAll().Where(x => x.Username.ToLower() == username).FirstOrDefault();
        }
    }
}
