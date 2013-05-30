namespace BuyAtYourPrice.Domain
{
    public class BidTransaction : DomainEntity
    {
        public  BidTransactionType TransactionType { get; set; }
        public  decimal Amount { get; set; }
    }
}