namespace BuyAtYourPrice.Core.Domain
{
    public class BidTransaction : DomainEntity
    {
        public virtual BidTransactionType TransactionType { get; set; }
        public virtual decimal Amount { get; set; }
    }
}