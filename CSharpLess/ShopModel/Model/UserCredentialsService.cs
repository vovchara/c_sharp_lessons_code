using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel.Model
{
    public class UserCredentialsService
    {
        public async Task<bool> TryLogin(string login, string password)
        {
            var users = new List<UserCredentialModel>();
            string sqlExpression = "SELECT * FROM credentials";
            using (var connection = new SqliteConnection("Data Source=main.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            long idDb = (long)reader["id"];
                            string loginDb = (string)reader["login"];
                            string passDb = (string)reader["password"];
                            string nickDb = (string)reader["nick"];
                            var model = new UserCredentialModel(idDb, loginDb, passDb, nickDb);
                            users.Add(model);
                        }
                    }
                }
            }
            var userFromDb = users.FirstOrDefault(u => u.Login == login && u.Pass == password);
            if (userFromDb == null)
            {
                return false;
            }
            UserSessionStorage.GetInstance().SetUser(userFromDb);
            return true;
        }
    }
}
