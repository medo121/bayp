namespace BuyAtYourPrice.Core.Domain
{
    public class Offer : DomainEntity
    {
        public virtual int SellerId { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual decimal Price { get; set; }

        public virtual int TimeLimitHours { get; set; }

        public virtual OfferStatus OfferStatus { get; set; }
    }
}