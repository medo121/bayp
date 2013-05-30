using BuyAtYourPrice.Core.Data;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Interfaces;

namespace BuyAtYourPrice.Repository
{
    public class BidRepository :  EfRepository<Bid>, IBidRepository
    {
        public BidRepository(BuyAtYourPriceCoreDbContext dbContext):base(dbContext)
        {
        }
    }
}
