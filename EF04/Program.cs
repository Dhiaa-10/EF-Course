using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EF04
{
    class Program
    {
        public static void Main()
        {
            var configurations = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            IDbConnection db = new SqlConnection(configurations.GetSection("constr").Value);


            Console.ReadKey();
        }
    }
}