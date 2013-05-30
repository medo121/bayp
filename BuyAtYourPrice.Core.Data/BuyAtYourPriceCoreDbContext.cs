using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BuyAtYourPrice.Domain;

namespace BuyAtYourPrice.Core.Data
{
    public class BuyAtYourPriceCoreDbContext : DbContext
    {
        public BuyAtYourPriceCoreDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            this.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            this.Configuration.ValidateOnSaveEnabled = false;

        }

        public DbSet<Bid> Bids { get; set; }

        public DbSet<BidItem> BidItems { get; set; }

        public DbSet<BidItemCondition> BidItemConditions { get; set; }

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

            //modelBuilder.Entity<Bid>()
            //            .HasRequired(x => x.BidItems)
            //            .WithRequiredPrincipal();


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