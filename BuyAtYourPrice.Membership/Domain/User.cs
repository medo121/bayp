namespace BuyAtYourPrice.Membership.Domain
{
    public class User 
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
