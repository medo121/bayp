using System;
using System.Collections.Generic;
using System.Linq;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Interfaces;

namespace BuyAtYourPrice.Repository.Extensions
{
    public static class BidRepositoryExtension
    {
        public static string[] OpenBidStatuses = {"Matched", "Offered", "Submitted"};


        public static IQueryable<Bid> GetOpenBids(this IRepository<Bid> bidRepository)
        {
            return
                bidRepository.GetAll("BidItems", "BidTransactions", "BidItems.Condition")
                             .Where(b => OpenBidStatuses.Contains(b.BidStatus.Name));
        }

        public static IEnumerable<Bid> GetTopTenOfferedBids(this IRepository<Bid> bidRepository)
        {
            return GetOpenBids(bidRepository).OrderBy(o => o.Offers.Count).Take(10).ToList();
        }

        public static IEnumerable<Bid> GetBidsAddedToday(this IRepository<Bid> bidRepository)
        {
            return GetOpenBids(bidRepository).Where(x => x.Created.Date == DateTime.Now.Date).Take(10).ToList();
        }

        public static IEnumerable<Bid> GetBidsAddedYesterday(this IRepository<Bid> bidRepository)
        {
            return
                GetOpenBids(bidRepository).Where(x => x.Created.Date == DateTime.Now.AddDays(-1).Date).Take(10).ToList();
        }

        public static IEnumerable<Bid> GetBidsAddedLastWeek(this IRepository<Bid> bidRepository)
        {
            return
                GetOpenBids(bidRepository)
                    .Where(
                        x => x.Created.Day < DateTime.Now.AddDays(7).Day && x.Created.Day > DateTime.Now.AddDays(14).Day)
                    .Take(10)
                    .ToList();
        }

        public static IEnumerable<Bid> GetBidsByTransactionType(this IRepository<Bid> bidRepository,
                                                                string bidTransactionType)
        {
            var bids = GetOpenBids(bidRepository)
                .Where(
                    x =>
                    x.BidTransactions.Any());

            if (bidTransactionType == "All")
                return bids.ToList();

            return
                bids.Where(y => y.BidTransactions.Any(x => x.TransactionType.Name == bidTransactionType))
                    .OrderBy(o => o.Offers.Count)
                    .Take(10)
                    .ToList();
        }

        public static IEnumerable<Bid> GetBidsByPriceRange(this IRepository<Bid> bidRepository, decimal lowerLimit,
                                                           decimal upperLimit)
        {
            return
                GetOpenBids(bidRepository)
                    .Where(
                        x => lowerLimit <= x.BidWishPrice && x.BidWishPrice <= upperLimit).Take(10)
                    .ToList();
        }

        public static IEnumerable<Bid> BidSearch(this IRepository<Bid> bidRepository, string searchText, int categoryId)
                                                         
        {
            return
                GetOpenBids(bidRepository)
                    .Where(
                        x => x.BidItems.FirstOrDefault().Product.Category.Id==categoryId  ).Take(10)
                    .ToList();
        }
        public static IEnumerable<Bid> GetBidsByCondition(this IRepository<Bid> bidRepository, string condition)
        {
            return
                GetOpenBids(bidRepository)
                    .Where(x => x.BidItems.FirstOrDefault().Condition.Condition == condition).Take(10).ToList();
        }

        public static IEnumerable<Bid> GetBidsForProduct(this IRepository<Bid> bidRepository, string productName)
        {
            return
                GetOpenBids(bidRepository).Where(x => x.BidItems.First().Product.Name == productName).ToList();
        }


        public static IEnumerable<Bid> GetBidsByCategory(this IRepository<Bid> bidRepository, string categoryName)
        {
            return
                GetOpenBids(bidRepository)
                    .Where(
                        x =>
                        x.BidItems.FirstOrDefault().Product.Category.Name == categoryName)
                    .OrderBy(o => o.Offers.Count).Take(10).ToList();
        }


        public static IEnumerable<Bid> GetBidsForUser(this IRepository<Bid> bidRepository, int buyerId)
        {
            return bidRepository.GetAll().Where(x => x.CustomerId == buyerId).ToList();
        }
    }
}