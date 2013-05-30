using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BuyAtYourPrice.Core.Domain;
using BuyAtYourPrice.Data.Contracts;

namespace BuyAtYourPrice.Core
{
    public class BuyAtYourPriceDbContext : DbContext
    {
        public BuyAtYourPriceDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Bid> Bids { get; set; }
        
        public DbSet<BidItem> BidItems { get; set; }

        public DbSet<BidMatch> BidMatches { get; set; }

        public DbSet<BidStatus> BidStatuses { get; set; }

        public DbSet<BidTransaction> BidTransactions { get; set; }

        public DbSet<BidTransactionType> BidTransactionTypes { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<OfferStatus> OfferStatuses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDescription> ProductDescriptions { get; set; }

        public DbSet<ProductModel> ProductModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Bid>().ToTable("Bids");
            //modelBuilder.Entity<BidItem>().ToTable("BidItems");
            //modelBuilder.Entity<BidMatch>().ToTable("BidMatches");
            //modelBuilder.Entity<BidStatus>().ToTable("BidStatuses");
            //modelBuilder.Entity<BidTransaction>().ToTable("BidTransaction");
            //modelBuilder.Entity<BidTransactionType>().ToTable("BidTransactionTypes");
            //modelBuilder.Entity<ProductCategory>().ToTable("ProductCategorys");
            //modelBuilder.Entity<ProductModel>().ToTable("ProductModels");
            //modelBuilder.Entity<ProductDescription>().ToTable("ProductDescriptions");
            //modelBuilder.Entity<Offer>().ToTable("Offers");
            //modelBuilder.Entity<OfferStatus>().ToTable("OfferStatuses");
            //modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Bid>()
                        .HasRequired(x => x.BidItem)
                        .WithRequiredPrincipal();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Customer>().
            HasMany(c => c.Addresses).
            WithMany(p => p.Customers).
            Map(m =>
            {
                m.MapLeftKey("CustomerId");
                m.MapRightKey("AddressId");
                m.ToTable("CustomerAddress");

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}