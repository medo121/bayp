namespace BuyAtYourPrice.Domain
{
    public class Offer : DomainEntity
    {
        public  int SellerId { get; set; }

        public  int BidId { get; set; }
       
        public  decimal Price { get; set; }

        public  int TimeLimitHours { get; set; }

        public  virtual OfferStatus OfferStatus { get; set; }
    }
}