namespace BuyAtYourPrice.Domain
{
    public class BidMatch : DomainEntity
    {
        public  Offer MatchingOffer { get; set; }
    }
}