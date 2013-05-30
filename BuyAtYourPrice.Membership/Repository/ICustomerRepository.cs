using System.Web.Security;
using BuyAtYourPrice.Membership.Domain;

namespace BuyAtYourPrice.Membership.Repository
{
    public interface ICustomerRepository
    {
        Model.BusinessUser GetUser(string userName);

        Model.BusinessUser GetUser(int userId);

        Model.BusinessUser CreateUser(string userName, string password, string email,
            out MembershipCreateStatus status, bool isComplexPassword = true, string fullName = null);
    }
}