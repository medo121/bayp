using System.Collections.Generic;
using System.Linq;
using BuyAtYourPrice.Data.Contracts;
using BuyAtYourPrice.Core.Domain;

namespace BuyAtYourPrice.Core.RepositoryExtensions
{
    public static class BidRepositoryExtension
    {
        public static string[] OpenBidStatuses = {"Matched", "Offered", "Submitted"};

        public static IEnumerable<Bid> GetOpenBids(this IRepository<Bid> bidRepository)
        {
            return bidRepository.GetAll().Where(b => OpenBidStatuses.Contains(b.BidStatus.Name)).ToList();
        }

        public static IEnumerable<Bid> GetTopTenOfferedBids(this IRepository<Bid> bidRepository, int buyerId)
        {
            return GetOpenBids(bidRepository).OrderBy(o => o.Offers.Count).Take(10).ToList();
        }

        public static IEnumerable<Bid> GetBidsByTransactionType(this IRepository<Bid> bidRepository, string bidTransactionType)
        {
            return
                GetOpenBids(bidRepository)
                    .Where(
                        x =>
                        x.BidTransaction != null &&
                        x.BidTransaction.Any(y => y.TransactionType.Name == bidTransactionType))
                    .ToList();
        }


        public static IEnumerable<Bid> GetBidsForProduct(this IRepository<Bid> bidRepository, string productName)
        {
            return
                  GetOpenBids(bidRepository)
                      .Where(
                          x =>
                          x.BidItem.Product.Name==productName)
                      .ToList();
        }


        public static IEnumerable<Bid> GetBidsByCategory(this IRepository<Bid> bidRepository, string categoryName)
        {
            return
                  GetOpenBids(bidRepository)
                      .Where(
                          x =>
                          x.BidItem.Product.Category.Name == categoryName)
                      .ToList();
        }


        public static IEnumerable<Bid> GetBidsForUser(this IRepository<Bid> bidRepository, int buyerId)
        {
            return bidRepository.GetAll().Where(x => x.CustomerId == buyerId).ToList();
        }


    }
}