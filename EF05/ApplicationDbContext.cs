using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF05
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var constr = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);
        }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
