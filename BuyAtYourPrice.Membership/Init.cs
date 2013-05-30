using System.Collections.Generic;
using System.Data.Entity;
using BuyAtYourPrice.Membership.Domain;

namespace BuyAtYourPrice.Membership
{
    public class Init : DropCreateDatabaseIfModelChanges<MembershipContext>
    {
        protected override void Seed(MembershipContext context)
        {
            base.Seed(context);
            using (context = new MembershipContext())
            {
                foreach (var user in GetUserList())
                    context.Users.Add(user);

                context.SaveChanges();
            }
        }

        public List<User> GetUserList()
        {
            return new List<User>
            {
                new User { Username = "test1",  PasswordHash = SecurityExtension.GetHashedPassword("test") , FirstName = "test1", EmailAddress="test1@test.com"},
                new User { Username = "test2",  PasswordHash = SecurityExtension.GetHashedPassword("test") , FirstName = "test2", EmailAddress="test1@test.com"},
            };
        }
    }
}
