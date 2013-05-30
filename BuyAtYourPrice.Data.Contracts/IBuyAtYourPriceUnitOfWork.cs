using BuyAtYourPrice.Domain;

namespace BuyAtYourPrice.Data.Contracts
{
   public  interface IBuyAtYourPriceUnitOfWork
    {// Save pending changes to the data store.
        void Commit();

        IRepository<Customer> Customers { get; set; }

        IRepository<ProductCategory> Categories { get; set; }

        IRepository<Product> Products { get; set; }

        IRepository<Bid> Bids { get; set; }

        IRepository<BidMatch> BidMatches { get; set; }

        IRepository<BidTransaction> BidTransactions { get; set; }

        IRepository<BidStatus> BidStatuses { get; set; }

        IRepository<Offer> Offers { get; set; }

        IRepository<OfferStatus> OfferStatuses { get; set; }
    }
}