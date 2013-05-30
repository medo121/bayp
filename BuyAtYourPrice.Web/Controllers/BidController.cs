using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Extensions;
using BuyAtYourPrice.Repository.Interfaces;
using BuyAtYourPrice.Web.ApiModels;

namespace BuyAtYourPrice.Web.Controllers
{
    public class BidController : BaypApiBaseController
    {
        private readonly IRepository<Bid> _bidRepository;

        public BidController(IRepository<Bid> bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public Bid GetBid(int id)
        {
            var bid = _bidRepository.GetById(id);
            if (bid != null) return bid;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // GET api/bid/5
        public IEnumerable<Bid> GetBidsForUser(int id)
        {
            var bids = _bidRepository.GetBidsForUser(id);
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // GET api/bid/5
        public IEnumerable<Bid> GetBidsWithDeposit()
        {
            var bids = _bidRepository.GetBidsByTransactionType("Deposit"); 
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        public IEnumerable<Bid> GetBidsAddedToday()
        {
            var bids = _bidRepository.GetBidsAddedToday();
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        public IEnumerable<Bid> GetBidsAddedYesterday()
        {
            var bids = _bidRepository.GetBidsAddedYesterday();
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        public IEnumerable<Bid> GetBidsAddedLastWeek()
        {
            var bids = _bidRepository.GetBidsAddedLastWeek();
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        public IEnumerable<Bid> GetBidsByCondition(string condition)
        {
            var bids = _bidRepository.GetBidsByCondition(condition);
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }
        public IEnumerable<Bid> GetBidsByCategory(string category)
        {
            var bids = _bidRepository.GetBidsByCategory(category);
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }
        public IEnumerable<Bid> GetBidsByPriceRange([FromUri] BidsByPriceRangeModel bidsByPriceRangeModel)
        {
            var bids = _bidRepository.GetBidsByPriceRange(decimal.Parse(bidsByPriceRangeModel.LowerLimit), decimal.Parse(bidsByPriceRangeModel.UpperLimit));
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        // GET api/bid/5
        public IEnumerable<Bid> GetBidsByTransactionType(string transactionType)
        {
            var bids = _bidRepository.GetBidsByTransactionType(transactionType);
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        public IEnumerable<Bid> GetBidsByTopTenOffered()
        {
            var bids = _bidRepository.GetTopTenOfferedBids();
            if (bids != null) return bids;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // POST api/bid
        public HttpResponseMessage Post(Bid bid)
        {
            //UnitOfWork.Bids.SaveOrUpdate(bid);
            //var response = Request.CreateResponse<Bid>(HttpStatusCode.Created, bid);
            //string uri = Url.Link("BaypApi", new { id = bid.Id });
            //response.Headers.Location = new System.Uri(uri);
            return null;
        }

        // PUT api/bid/5
        public void Put(Bid bid)
        {
        }

        // DELETE api/bid/5
        public void Delete(int id)
        {
        }
    }
}