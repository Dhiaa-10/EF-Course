using EF06.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF06.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; }
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
