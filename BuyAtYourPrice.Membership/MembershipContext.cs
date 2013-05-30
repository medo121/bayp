using System.Data.Entity;

namespace BuyAtYourPrice.Membership
{
    public class MembershipContext : DbContext
    {
        public MembershipContext()
            : base("MembershipConnection")
        {
            Database.SetInitializer(new Init());
        }

        public MembershipContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Domain.User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            MapUser(modelBuilder);
        }

        protected virtual void MapUser(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.User>()
                        .Map(m => m.ToTable("User", "dbo"));
        }
    }
}