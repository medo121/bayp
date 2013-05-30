using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BuyAtYourPrice.Domain
{
    public class Bid : DomainEntity
    {
        public Bid()
        {
            Offers = new Collection<Offer>();
            BidItems = new Collection<BidItem>();
            BidTransactions = new Collection<BidTransaction>();

        }

        public  int CustomerId { get; set; }
        public  string Summary { get; set; }


        public ICollection<BidItem> BidItems { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public  ICollection<BidTransaction> BidTransactions { get; set; }

        public  BidStatus BidStatus { get; set; }

        public  int TimeLimitHours { get; set; }

        public  decimal BidWishPrice { get; set; }
    }
}