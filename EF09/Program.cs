using EF09.Data;

namespace EF09
{
    class Program
    {
        public static void Main()
        {
            var context  = new AppDbContext();
            foreach (var product in context.Products)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}