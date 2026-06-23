using System;
using System.Data;
using System.Data.Common;
using System.Transactions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EF03
{
    class Program
    {
        public static void Main()
        {
            var configurations = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            IDbConnection db = new SqlConnection(configurations.GetSection("constr").Value);

            RawSqlTransaction(db);
            Console.WriteLine("--------------------");
            SelectRawSql(db);

            Console.ReadKey();
        }
        public static void SelectRawSql(IDbConnection db)
        {
            var sql = "SELECT * FROM Wallets";

            var wallets = db.Query<Wallet>(sql);

            foreach (var wallet in wallets)
            {
                Console.WriteLine(wallet);
            }
        }
        public static void InsertRawSql(IDbConnection db) 
        {
            var sql = "INSERT INTO Wallets (Holder, Balance)" +
                " VALUES (@Holder, @Balance);";

            var walletToInsert = new Wallet
            {
                Holder = "Afnan",
                Balance = 9000
            };

            db.Execute(sql, new
            {
                Holder = walletToInsert.Holder,
                Balance = walletToInsert.Balance
            });
        }
        public static void InsertRawSqlReturnId(IDbConnection db)
        {
            var sql = "INSERT INTO Wallets (Holder, Balance)" +
                " VALUES (@Holder, @Balance)" +
                " SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var walletToInsert = new Wallet
            {
                Holder = "Afnan",
                Balance = 9000
            };

            var parameter = new
            {
                Holder = walletToInsert.Holder,
                Balance = walletToInsert.Balance
            };

            walletToInsert.Id =  db.Query<int>(sql,parameter).Single();
            Console.WriteLine(walletToInsert);
        }
        public static void UpdateRawSql(IDbConnection db)
        {
            var sql = "UPDATE Wallets SET Holder = @Holder, Balance = @Balance" +
                " WHERE Id = @Id;";

            var walletToUpdate = new Wallet
            {
                Id = 11,
                Holder = "Zaid",
                Balance = 11000
            };

            var parameter = new
            {
                Id = walletToUpdate.Id,
                Holder = walletToUpdate.Holder,
                Balance = walletToUpdate.Balance
            };
            db.Execute(sql, parameter);
        }
        public static void DeleteRawSql(IDbConnection db)
        {
            var sql = "DELETE FROM Wallets" +
                " WHERE Id = @Id;";

            var walletToDelete = new Wallet
            {
                Id = 11,
            };

            var parameter = new
            {
                Id = walletToDelete.Id,
            };
            db.Execute(sql, parameter);
        }
        public static void SelectRawSqlMultiple(IDbConnection db)
        {
            var sql = "SELECT MIN(Balance) FROM Wallets;" +
                      "SELECT MAX(Balance) FROM Wallets;";

            var multi = db.QueryMultiple(sql);

            Console.WriteLine($"min {multi.ReadSingle<decimal>()}, max {multi.ReadSingle<decimal>()}");

        }
        public static void RawSqlTransaction(IDbConnection db)
        {
            using (var TransactionScope = new TransactionScope())
            {
                var walletFrom = db.QuerySingle<Wallet>
                    ("Select * from Wallets Where Id = @Id", new { Id = 11});
                var walletTo = db.QuerySingle<Wallet>
                    ("Select * from Wallets Where Id = @Id", new { Id = 1});

                db.Execute("Update Wallets set Balance = @Balance Where Id = @Id", new
                {
                    Id = 1,
                    Balance = walletFrom.Balance - 1000,
                });
                db.Execute("Update Wallets set Balance = @Balance Where Id = @Id", new
                {
                    Id = 11,
                    Balance = walletTo.Balance + 1000,
                });

                TransactionScope.Complete();
            }
        }

    }
}
