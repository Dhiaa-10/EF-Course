using System.Transactions;
using Microsoft.Extensions.Configuration;

namespace EF05
{
    public class Program
    {
        public static void Main()
        {
            //// Select in EF Core
            //using (var context = new ApplicationDbContext())
            //{
            //    foreach (var wallet in context.Wallets)
            //    {
            //        Console.WriteLine(wallet);
            //    }
            //}

            //Console.WriteLine("-------------------------");

            //// Select one row with id, in EF Core
            //using (var context = new ApplicationDbContext())
            //{
            //    var wallet = context.Wallets.FirstOrDefault(x => x.Id == 2);
            //    Console.WriteLine(wallet);
            //}

            //// Insert row with id, in EF Core
            //var walletToInsert = new Wallet
            //{
            //    Holder = "Salah",
            //    Balance = 3500
            //};
            //using (var context = new ApplicationDbContext())
            //{
            //    context.Wallets.Add(walletToInsert);
            //    context.SaveChanges();
            //}

            //// Update
            //using (var context = new ApplicationDbContext())
            //{
            //    var walletToUpdate = context.Wallets.Single(x => x.Id == 12);
            //    walletToUpdate.Balance += 1000;
            //    walletToUpdate.Holder = "Mohammed";
            //    var walletToUpdate1 = context.Wallets.Single(x => x.Id == 13);
            //    walletToUpdate1.Holder = "Mahmood";
            //    var walletToUpdate2 = context.Wallets.Single(x => x.Id == 14);
            //    walletToUpdate2.Balance += 1500;
            //    walletToUpdate2.Holder = "Khaled";
            //    context.SaveChanges();
            //}

            ////// Delete
            ////using (var context = new ApplicationDbContext())
            ////{
            ////    var walletToDelete = context.Wallets.Single(x => x.Id == 17);
            ////    context.Wallets.Remove(walletToDelete);
            ////    context.SaveChanges();
            ////}
            
            //// Query
            //using (var context = new ApplicationDbContext())
            //{
            //    var results = context.Wallets.Where(x => x.Balance > 5000);
            //    foreach (var result in results)
            //    {
            //        Console.WriteLine(result);
            //    }
            //}

            ////Transaction
            //using (var context = new ApplicationDbContext())
            //{
            //    using (var transaction = context.Database.BeginTransaction())
            //    {
            //        var from = context.Wallets.Single(x => x.Id == 15);
            //        var to = context.Wallets.Single(x => x.Id == 13);
            //        var amount = 500m;
            //        from.Balance -= amount;
            //        context.SaveChanges();
            //        to.Balance += amount;
            //        context.SaveChanges();
            //        transaction.Commit();
            //    }
            //}

        }
    }
}