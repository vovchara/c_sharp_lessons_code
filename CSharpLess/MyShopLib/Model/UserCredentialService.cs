using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopLib.Model
{
    public class UserCredentialService
    {
        public Task<bool> TryLogin(UserCredModel userCredModel)
        {
            using SqliteConnection sqlite_conn = CreateConnection();
            //CreateTable(sqlite_conn);
            //InsertData(sqlite_conn);
            ReadData(sqlite_conn);
            return Task.FromResult(true);
        }

        private SqliteConnection CreateConnection()
        {
            var sqlite_conn = new SqliteConnection("Data Source=main.db");
         // Open the connection:
         try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        static void ReadData(SqliteConnection conn)
        {
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM credentials";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }
    }
}
