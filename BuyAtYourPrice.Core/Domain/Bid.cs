using System.Collections.Generic;

namespace BuyAtYourPrice.Core.Domain
{
    public class Bid : DomainEntity
    {
        public Bid()
        {
            Offers = new List<Offer>();
        }

        public virtual int CustomerId { get; set; }
        public virtual string Summary { get; set; }


        public virtual BidItem BidItem { get; set; }

        public virtual IList<Offer> Offers { get; set; }

        public virtual IList<BidTransaction> BidTransaction { get; set; }

        public virtual BidStatus BidStatus { get; set; }

        public virtual int TimeLimitHours { get; set; }

        public virtual decimal BidWishPrice { get; set; }
    }
}