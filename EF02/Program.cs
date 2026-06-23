using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EF02
{
    class Program
    {
        public static void Main ()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);

            TransactionRawSql(conn);
            SelectRawSql(conn);


            Console.ReadKey();
        }

        public static void SelectRawSql(SqlConnection conn)
        {
            var sql = "SELECT * FROM WALLETS";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.CommandType = CommandType.Text;

            conn.Open();

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            Wallet wallet;

            while (sqlDataReader.Read())
            {
                wallet = new Wallet
                {
                    Id = sqlDataReader.GetInt32("Id"),
                    Holder = sqlDataReader.GetString("Holder"),
                    Balance = sqlDataReader.GetDecimal("Balance"),
                };

                Console.WriteLine(wallet);
            }

            conn.Close();
        }
        public static void InsertRawSql(SqlConnection conn)
        {
            var walletToInsert = new Wallet
            {
                Holder = "Musab",
                Balance = 6500,
            };

            var sql = "INSERT INTO WALLETS (Holder, Balance) VALUES" +
                $"(@Holder, @Balance);";

            SqlParameter hokderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Value = walletToInsert.Holder,
                Direction = ParameterDirection.Input,
            };

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Value = walletToInsert.Balance,
                Direction = ParameterDirection.Input,
            };

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(hokderParameter);
            cmd.Parameters.Add(balanceParameter);
            cmd.CommandType = CommandType.Text;

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void InsertRawSqlScalar(SqlConnection conn)
        {
            var walletToInsert = new Wallet
            {
                Holder = "Musab",
                Balance = 6500,
            };

            var sql = "INSERT INTO WALLETS (Holder, Balance) VALUES" +
                $"(@Holder, @Balance);" +
                $"SELECT CAST(scope_identity() AS int)";

            SqlParameter hokderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Value = walletToInsert.Holder,
                Direction = ParameterDirection.Input,
            };

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Value = walletToInsert.Balance,
                Direction = ParameterDirection.Input,
            };

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(hokderParameter);
            cmd.Parameters.Add(balanceParameter);
            cmd.CommandType = CommandType.Text;

            conn.Open();

            walletToInsert.Id = (int) cmd.ExecuteScalar();

            Console.WriteLine($"wallet {walletToInsert} added successfully!");

            conn.Close();
        }
        public static void InsertRawSqlProcedure(SqlConnection conn)
        {
            var walletToInsert = new Wallet
            {
                Holder = "Ameen",
                Balance = 4500,
            };



            SqlParameter hokderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Value = walletToInsert.Holder,
                Direction = ParameterDirection.Input,
            };

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Value = walletToInsert.Balance,
                Direction = ParameterDirection.Input,
            };

            SqlCommand cmd = new SqlCommand("AddWallet", conn);
            cmd.Parameters.Add(hokderParameter);
            cmd.Parameters.Add(balanceParameter);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            //walletToInsert.Id = (int)cmd.ExecuteScalar();    
            
            Console.WriteLine($"wallet {walletToInsert} added successfully!");
            

            conn.Close();
        }
        public static void UpdateRawSql(SqlConnection conn)
        {
            var sql = "Update Wallets set Holder = @Holder, Balance = @Balance " +
                $"Where Id = @Id;";

            SqlParameter hokderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Value = "Mortada",
                Direction = ParameterDirection.Input,
            };

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Value = 6000,
                Direction = ParameterDirection.Input,
            };

            SqlParameter idParameter = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Value = 7,
                Direction = ParameterDirection.Input,
            };

        SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(idParameter);
            cmd.Parameters.Add(hokderParameter);
            cmd.Parameters.Add(balanceParameter);
            cmd.CommandType = CommandType.Text;

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void DeleteRawSql(SqlConnection conn)
        {
            var sql = "delete from Wallets " +
                $"Where Id = @Id;";

            SqlParameter idParameter = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Value = 7,
                Direction = ParameterDirection.Input,
            };

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(idParameter);
            cmd.CommandType = CommandType.Text;

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void SelectRawSqlDataAdapter(SqlConnection conn)
        {
            var sql = "SELECT * FROM WALLETS";

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            conn.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var wallet = new Wallet
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Holder = Convert.ToString(dataRow["Holder"]),
                    Balance = Convert.ToDecimal(dataRow["Balance"]),
                };

                Console.WriteLine(wallet);
            }
        }
        public static void TransactionRawSql(SqlConnection conn)
        {
            

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;

            conn.Open();

            SqlTransaction Transaction = conn.BeginTransaction();

            cmd.Transaction = Transaction;

            try
            {
                cmd.CommandText = "update Wallets set Balalnce = Balance - 1500 where Id = 8";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update Wallets set Balalnce = Balance + 1500 where Id = 4";
                cmd.ExecuteNonQuery();

                Transaction.Commit();
                Console.WriteLine("Done!");
            }
            catch
            {
                Transaction.Rollback();
            }
            finally
            {
                conn.Close();
            }


        }
    }
}
