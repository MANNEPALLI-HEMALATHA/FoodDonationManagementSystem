using Microsoft.EntityFrameworkCore;
namespace FoodDonation
{
    public class FoodDonationContext : DbContext
    {
        public FoodDonationContext()
        {

        }
        public FoodDonationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> UserMaster { get; set; }
        public DbSet<FoodRequest> FoodRequest { get; set; }//by admin - food required(table)
        public DbSet<FoodDonationRequestByUser> FoodDonationRequest { get; set; }//by user who are willing to donate food(table)

        public DbSet<LogisticRequest> LogisticRequest { get; set; }//by admin - Logistics required(table)
        public DbSet<LogisticDonationRequestByUser> LogisticDonationRequest { get; set; }//by users who are willing to donate the logistics(table)




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-VN7LFBN5;Initial Catalog=FoodDonation_DB;Integrated Security=true");
        }
    }
}
