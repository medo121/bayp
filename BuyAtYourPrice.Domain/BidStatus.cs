namespace BuyAtYourPrice.Domain
{

    public class BidStatus : DomainEntity
    {
        public virtual string Name { get; set; }

        public static string Accepted = "Accepted";
        public static string Offered = "Rejected";
        public static string Submitted = "Submitted";
        public static string Withdrawn = "Withdrawn";
        public static string Cancelled = "Cancelled";
    }
}