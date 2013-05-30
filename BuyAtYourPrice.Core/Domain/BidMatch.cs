namespace BuyAtYourPrice.Core.Domain
{
    public class BidMatch : DomainEntity
    {
        public virtual Offer MatchingOffer { get; set; }
    }
}