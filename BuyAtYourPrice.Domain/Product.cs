namespace BuyAtYourPrice.Domain
{
    public class Product : DomainEntity
    {
        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public ProductDescription ProductDescription { get; set; }

        public string Color { get; set; }

        public double StandardCost { get; set; }

        public double ListPrice { get; set; }

        public string Size { get; set; }

        public decimal Weight { get; set; }

        public ProductCategory Category { get; set; }

        public string ThumbnailPhotoFileName { get; set; }
    }
}