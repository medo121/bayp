using System;
using System.Collections.Specialized;
using System.Web.Security;
using BuyAtYourPrice.Membership.Repository;
namespace BuyAtYourPrice.Membership
{
    public class MembershipProvider : System.Web.Security.MembershipProvider, IMembershipProvider
    {
// ReSharper disable RedundantDefaultFieldInitializer
        private ICustomerRepository _customerMembershipRepository = null;
// ReSharper restore RedundantDefaultFieldInitializer

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            ApplicationName = config["ApplicationName"];
        }


        public string ProviderName
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsUserInRole(string username, string rolename)
        {
            throw new NotImplementedException();
        }

        public MembershipUser GetUser(int userid, bool userIsOnline)
        {
            return GetUserByUserId(userid);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return GetUserByUserName(username);
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword, bool isResetPassword)
        {
            throw new NotImplementedException();
        }
        
        public override string ApplicationName { get; set; }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            using (var context = new MembershipContext())
            {
                _customerMembershipRepository = new CustomerRepository(context);
                return _customerMembershipRepository.CreateUser(username, password, email, out status);
            }

        }

        public MembershipUser CreateUser(string username, string password, string email, out MembershipCreateStatus status, string fullname)
        {
            using (var context = new MembershipContext())
            {
                _customerMembershipRepository = new CustomerRepository(context);
                return _customerMembershipRepository.CreateUser(username, password, email, out status, true, fullname);
            }

        }         

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            return ValidateUserInternal(username, password);
        }

        private Model.BusinessUser GetUserByUserName(string userName)
        {
            using (var context = new MembershipContext())
            {
                _customerMembershipRepository = new CustomerRepository(context);

                return _customerMembershipRepository.GetUser(userName);
            }
        }

        private Model.BusinessUser GetUserByUserId(int userId)
        {
            using (var context = new MembershipContext())
            {
                _customerMembershipRepository = new CustomerRepository(context);

                return _customerMembershipRepository.GetUser(userId);
            }
        }

        private bool ValidateUserInternal(string userName, string password)
        {
            using (var context = new MembershipContext())
            {
                _customerMembershipRepository = new CustomerRepository(context);
                var user = _customerMembershipRepository.GetUser(userName);
                return (user != null && user.PasswordHash == SecurityExtension.GetHashedPassword(password));
            }
        }
    }
}
