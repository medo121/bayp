using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Extensions;
using BuyAtYourPrice.Repository.Interfaces;

namespace BuyAtYourPrice.Web.Controllers
{
    public class CustomerController : BaypApiBaseController
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.ActionName("GetCustomerForUser")]
        public Customer GetCustomerForUser(string username)
        {
            var customer = _customerRepository.GetCustomerForUser(username);
            if (customer != null)
                return customer;

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
    }
}
