using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using BuyAtYourPrice.Core.Data;
using BuyAtYourPrice.Domain;


namespace BuyAtYourPrice.DataInitializer
{
    public class BuyAtYourPriceDatabaseInitializer : CreateDatabaseIfNotExists<BuyAtYourPriceCoreDbContext>

    {
        private static readonly Random Rnd = new Random();

        protected override void Seed(BuyAtYourPriceCoreDbContext context)
        {
            context.Configuration.AutoDetectChangesEnabled=false;
            GetBidTransactionTypes().ForEach(x => context.BidTransactionTypes.Add(x));

            GetBidStatuses().ForEach(x => context.BidStatuses.Add(x));

            GetBidItemConditions().ForEach(x => context.BidItemConditions.Add(x));

            GetOfferStatuses().ForEach(x => context.OfferStatuses.Add(x));

            context.SaveChanges();

            GetProductCategories().ForEach(productCategory =>

                {
                    context.ProductCategory.Add(productCategory);


                    for (int i = 0; i < 3; i++)
                    {
                        var prod = CreateProduct(productCategory, i);

                        context.Products.Add(prod);
                    }
                });


            context.SaveChanges();
            var products = context.Products.ToList();

            foreach (var product in products)
            {
                CreateBid(context, product);
            }
            context.SaveChanges();
            var bids = context.Bids.ToList();

            foreach (var bid in bids)
            {
                CreateOffers(context, bid);
            }

            context.SaveChanges();
        }

        private static Product CreateProduct(ProductCategory productCategory, int i)
        {
            var prod = new Product
                {
                    Category = productCategory,
                    Color = "Blue",
                    ListPrice = Rnd.Next(60, 800),
                    Name = productCategory.Name + " Product" + i,
                    ProductNumber = "00022" + i,
                    StandardCost = Rnd.Next(60, 800),
                    ThumbnailPhotoFileName = "noAvatarPat.png"
                };
            return prod;
        }

        private static void CreateBid(BuyAtYourPriceCoreDbContext context, Product product)
        {
            var status = context.BidStatuses.First(x => x.Name == BidStatus.Submitted);
            var r = Rnd.Next(2, 5);
            for (int j = 0; j < r; j++)
            {
                var bid = new Bid()
                    {
                        BidWishPrice = Rnd.Next(50, 1000),
                        TimeLimitHours = Rnd.Next(1, 100),
                        CustomerId = 2,
                        BidStatus = status,
                        Summary =
                            "ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation. ",
                    };

                context.Bids.Add(bid);
            }
            context.SaveChanges();
            var bids = context.Bids.ToList();

            var conditions = context.BidItemConditions.ToList();

            foreach (var bid in bids)
            {
                r = Rnd.Next(2, 10);
                BidItemCondition condition = null;
                if (r <= 5)
                {
                    condition = conditions.Where(x => x.Condition == "New").FirstOrDefault();
                }
                else
                {
                    condition = conditions.Where(x => x.Condition == "Used").FirstOrDefault();
                }

                var item = new BidItem()
                    {
                        BidId = bid.Id,
                        Price = Rnd.Next(30, 700),
                        Product = product,
                        Quantity = 1,
                        Condition = condition
                    };
                context.BidItems.Add(item);
            }

            context.SaveChanges();
        }


        private static void CreateOffers(BuyAtYourPriceCoreDbContext context, Bid bid)
        {
            var status = context.OfferStatuses.First(x => x.Name == OfferStatus.Submitted);
            var r = Rnd.Next(1, 10);
            for (int j = 0; j < r; j++)
            {
                var offer = new Offer()
                    {
                        OfferStatus = status,
                        BidId = bid.Id,
                        Price = Rnd.Next(10, 1000),
                        TimeLimitHours = Rnd.Next(1, 100),
                        SellerId = 1
                    };
                context.Offers.Add(offer);
            }
        }

        private static List<BidTransactionType> GetBidTransactionTypes()
        {
            return new List<BidTransactionType>
                {
                    new BidTransactionType {Name = "Deposit"},
                    new BidTransactionType {Name = "Fully Paid"}
                };
        }

        private static List<BidItemCondition> GetBidItemConditions()
        {
            return new List<BidItemCondition>
                {
                    new BidItemCondition {Condition = "New"},
                    new BidItemCondition {Condition = "Used"}
                };
        }

        private static List<BidStatus> GetBidStatuses()
        {
            return new List<BidStatus>
                {
                    new BidStatus {Name = "Matched"},
                    new BidStatus {Name = "Offered"},
                    new BidStatus {Name = "Submitted"},
                    new BidStatus {Name = "Closed"},
                    new BidStatus {Name = "Withdrawn"},
                    new BidStatus {Name = "Cancelled"}
                };
        }

        private static List<OfferStatus> GetOfferStatuses()
        {
            return new List<OfferStatus>
                {
                    new OfferStatus {Name = "Accepted"},
                    new OfferStatus {Name = "Rejected"},
                    new OfferStatus {Name = "Submitted"},
                    new OfferStatus {Name = "Withdrawn"},
                    new OfferStatus {Name = "Cancelled"}
                };
        }

        private static List<ProductCategory> GetProductCategories()
        {
            return new List<ProductCategory>
                {
                    new ProductCategory {Name = "Antiques"},
                    new ProductCategory {Name = "Art"},
                    new ProductCategory {Name = "Baby"},
                    new ProductCategory {Name = "Books, Comics &amp; Magazines"},
                    new ProductCategory {Name = "Business, Office &amp; Industrial"},
                    new ProductCategory {Name = "Cameras &amp; Photography"},
                    new ProductCategory {Name = "Cars, Motorcycles &amp; Vehicles"},
                    new ProductCategory {Name = "Clothes, Shoes &amp; Accessories"},
                    new ProductCategory {Name = "Coins"},
                    new ProductCategory {Name = "Collectables"},
                    new ProductCategory {Name = "Computers/Tablets &amp; Networking"},
                    new ProductCategory {Name = "Crafts"},
                    new ProductCategory {Name = "Dolls &amp; Bears"},
                    new ProductCategory {Name = "DVDs, Films &amp; TV"},
                    new ProductCategory {Name = "Events Tickets"},
                    new ProductCategory {Name = "Garden &amp; Patio"},
                    new ProductCategory {Name = "Health &amp; Beauty"},
                    new ProductCategory {Name = "Holidays &amp; Travel"},
                    new ProductCategory {Name = "Home, Furniture &amp; DIY"},
                    new ProductCategory {Name = "Jewellery &amp; Watches"},
                    new ProductCategory {Name = "Mobile Phones &amp; Communication"},
                    new ProductCategory {Name = "Music"},
                    new ProductCategory {Name = "Musical Instruments"},
                    new ProductCategory {Name = "Pet Supplies"},
                    new ProductCategory {Name = "Pottery, Porcelain &amp; Glass"},
                    new ProductCategory {Name = "Property"},
                    new ProductCategory {Name = "Sound &amp; Vision"},
                    new ProductCategory {Name = "Sporting Goods"},
                    new ProductCategory {Name = "Sports Memorabilia"},
                    new ProductCategory {Name = "Stamps"},
                    new ProductCategory {Name = "Toys &amp; Games"},
                    new ProductCategory {Name = "Vehicle Parts &amp; Accessories"},
                    new ProductCategory {Name = "Video Games &amp; Consoles"},
                    new ProductCategory {Name = "Wholesale &amp; Job Lots"},
                    new ProductCategory {Name = "Everything Else"},
                };
        }
    }
}