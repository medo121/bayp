using System.Linq;
using System.Web.Security;
using BuyAtYourPrice.Membership.Domain;

namespace BuyAtYourPrice.Membership.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MembershipContext _membershipDbContext;

        public CustomerRepository(MembershipContext membershipDbContext)
        {
            membershipDbContext.ArgumentIsNotNull("membershipDbContext");
            _membershipDbContext = membershipDbContext;
        }

        public Model.BusinessUser GetUser(string userName)
        {
            var user =
                _membershipDbContext.Users.FirstOrDefault(x => x.Username.Trim().ToLower() == userName.Trim().ToLower());
            if (user != null)
                return new Model.BusinessUser
                    {
                        Username = user.Username,
                        Title = user.Title,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        EmailAddress = user.EmailAddress,
                        PasswordHash = user.PasswordHash,
                    };

            return  null;
        }

        public Model.BusinessUser GetUser(int userId)
        {
            var user =
                  _membershipDbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
                return new Model.BusinessUser
                {
                    Username = user.Username,
                    Title = user.Title,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress,
                    PasswordHash = user.PasswordHash,
                };

            return null;
        }

        public Model.BusinessUser CreateUser(string userName, string password, string email,
            out MembershipCreateStatus status, bool isComplexPassword = true, string fullName = null)
        {
            Model.BusinessUser newUser = null;
            status = MembershipCreateStatus.Success;

            if (status == MembershipCreateStatus.Success)
            {
                if (!SecurityExtension.IsValidUserName(userName)) status = MembershipCreateStatus.InvalidUserName;
            }

            if (status == MembershipCreateStatus.Success)
            {
                if (!SecurityExtension.IsValidEmail(email)) status = MembershipCreateStatus.InvalidEmail;
            }

            if (status == MembershipCreateStatus.Success)
            {
                if (isComplexPassword && (!SecurityExtension.IsValidPassword(password))) status = MembershipCreateStatus.InvalidPassword;
            }

            using (var context = _membershipDbContext)
            {
                if (status == MembershipCreateStatus.Success)
                {
                    var user = context.Users.FirstOrDefault(u => u.Username.ToLower() == userName.ToLower());
                    if (user != null) status = MembershipCreateStatus.DuplicateUserName;
                }

                if (status == MembershipCreateStatus.Success)
                {
                    // Create user, add it to database, then re-query.
                    var data = new User
                    {
                        Username = userName,
                        PasswordHash = SecurityExtension.GetHashedPassword(password),
                        EmailAddress = email ?? string.Empty,
                        FirstName = fullName ?? string.Empty,
                    };

                    context.Users.Add(data);
                    context.SaveChanges();
                    newUser = GetUser(userName);
                }
            }

            if (status == MembershipCreateStatus.Success)
                return newUser;

            return null;
        }

        //public void UpdateUserById(int userId, string userName, string email, out MembershipCreateStatus status, string fullName = null)
        //{
        //    if (string.IsNullOrWhiteSpace(userName))
        //        throw new ArgumentException("User Name must be supplied.", "userName");

        //    status = MembershipCreateStatus.Success;

        //    if (status == MembershipCreateStatus.Success)
        //    {
        //        if (!this.IsValidUserName(userName)) status = MembershipCreateStatus.InvalidUserName;
        //    }

        //    if (status == MembershipCreateStatus.Success)
        //    {
        //        if (!this.IsValidEmail(email)) status = MembershipCreateStatus.InvalidEmail;
        //    }

        //        if (status == MembershipCreateStatus.Success && userName != null)
        //        {
        //            var user = this.membershipDbContext.Customers
        //                .Where(u => u.Username.ToLower() == userName.ToLower() && u.Id != userId)
        //                .FirstOrDefault();
        //            if (user != null) status = MembershipCreateStatus.DuplicateUserName;
        //        }

        //        if (status == MembershipCreateStatus.Success)
        //        {
        //            var user = this.membershipDbContext.Customers.Where(u => u.Id == userId).FirstOrDefault();

        //            user.UserName = userName;
        //            user.EmailAddress = email ?? string.Empty;
        //            user.FullName = fullName ?? string.Empty;
        //            schema.SubmitChanges();
        //        }

        //}

    }
}
