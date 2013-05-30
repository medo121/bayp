using System.Linq;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Interfaces;

namespace BuyAtYourPrice.Repository.Extensions
{
    public static class CustomerRepositoryExtension
    {
        public static Customer GetCustomerForUser(this IRepository<Customer> customerRepository, string username)
        {
            return customerRepository.GetAll().FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }
    }
}
