namespace BuyAtYourPrice.Domain
{
    // <summary>
    /// This enum may have an equivalent table in the database called OrderStatusTypes. It wouldn't
    /// map to the table directly, but the table could be put in place in order to provide
    /// referential integrity and to allow the database to be more "discoverable"; i.e., you could
    /// look at the OrderStatusTypes table to infer the meaning behind any FK relationships to it.
    ///
    /// If an OrderStatusTypes table is created, you'd have to manually add (and maintain) an entry
    /// for each enum value and manually add any FK relationships to it.
    /// </summary>
    public class OfferStatus : DomainEntity
    {
        public  string Name { get; set; }
        public static string Accepted = "Accepted";
        public static string Rejected = "Rejected";
        public static string Submitted = "Submitted";
        public static string Withdrawn = "Withdrawn";
        public static string Cancelled = "Cancelled";

        

    }
}