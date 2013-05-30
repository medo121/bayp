using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Interfaces;


namespace BuyAtYourPrice.Web.Controllers
{
    public class OfferController : BaypApiBaseController
    {
        private readonly IRepository<Offer> _offerRepository;
        public OfferController(IRepository<Offer> offerRepository)
        {
            _offerRepository = offerRepository;
        }

        // GET api/bid/5
        public Offer Get(int id)
        {
            var offer = _offerRepository.GetById(id);
            if (offer != null) return offer;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // POST api/bid
        public HttpResponseMessage Post(Offer offer)
        {
            //UnitOfWork.Offers.SaveOrUpdate(offer);
            //var response = Request.CreateResponse<Offer>(HttpStatusCode.Created, offer);
            //string uri = Url.Link("BaypApi", new { id = offer.Id });
            //response.Headers.Location = new System.Uri(uri);
            return null;
        }

        // PUT api/bid/5
        public void Put(Offer offer)
        {
        }

        // DELETE api/bid/5
        public void Delete(int id)
        {
        }
    }

}

//