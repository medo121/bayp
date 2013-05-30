using System.Net.Http;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Membership.Model;
using BuyAtYourPrice.Web.Models;
using Newtonsoft.Json;

namespace BuyAtYourPrice.Web.Security
{
    public static class UserManager
    {

        public static dynamic GetCustomerProfile(BusinessUser user)
        {
            var client = new HttpClient();
            var result = client.GetAsync("http://localhost:21680/api/customer/GetCustomerForUser?username=" + user.Username,
                                         HttpCompletionOption.ResponseContentRead);

            object responseObject;
            result.Result.TryGetContentValue(out responseObject);
            var customer =
                JsonConvert.DeserializeObject<Customer>(result.Result.Content.ReadAsStringAsync().Result);

            if (customer != null && customer.Id > 0)
            {
              return  new CustomerProfile(user)
// ReSharper disable RedundantEmptyObjectOrCollectionInitializer
                  {
                     // Address = customer.Addresses.Select(a => a.AddressLine1).FirstOrDefault(),
                  };
// ReSharper restore RedundantEmptyObjectOrCollectionInitializer
            }

            return user;
        }

    }
}