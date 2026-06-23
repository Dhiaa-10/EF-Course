using EF06.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF06
{
    public class Program
    {
        public static void Main()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var constr = config.GetSection("constr").Value;
            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(constr);
            var options = optionBuilder.Options;
            
            using (var context = new ApplicationDbContext(options))
            {
                var tasks = new[]
                {
                    Task.Factory.StartNew( ()=> {})
                };
            }
        }
    }
}