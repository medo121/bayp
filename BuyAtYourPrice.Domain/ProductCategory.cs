namespace BuyAtYourPrice.Domain
{
    public class ProductCategory : DomainEntity
    {
        public  ProductCategory Parent { get; set; }

        public  string Name { get; set; }
    }
}