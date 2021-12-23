using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ConsoleSQL0
{
    class Program
    {
        private static string connectionString = "Server=localhost;Database=testadonetdb;Trusted_Connection=True;TrustServerCertificate=True;"; //added TrustServerCertificate=True to fix serteficate issue
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Hello World!");

            await GetAllUsersAsync();   // сначала выводим всех пользователей

            Console.Write("Введите имя пользователя:");
            string name = Console.ReadLine();

            await GetAgeRangeAsync(name);

            Console.Read();
        }
        private static async Task GetAllUsersAsync()
        {
            string sqlExpression = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        // выводим названия столбцов
                        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(2)}\t{reader.GetName(1)}");

                        while (await reader.ReadAsync()) // построчно считываем данные
                        {
                            object id = reader.GetValue(0);
                            object name = reader.GetValue(2);
                            object age = reader.GetValue(1);
                            Console.WriteLine($"{id} \t{name} \t{age}");
                        }
                    }
                }
            }
        }
        private static async Task GetAgeRangeAsync(string name)
        {
            string sqlExpression = "sp_GetAgeRange";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                command.Parameters.Add(nameParam);

                // определяем первый выходной параметр
                SqlParameter minAgeParam = new SqlParameter
                {
                    ParameterName = "@minAge",
                    SqlDbType = SqlDbType.Int, // тип параметра

                    // указываем, что параметр будет выходным
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(minAgeParam);

                // определяем второй выходной параметр
                SqlParameter maxAgeParam = new SqlParameter
                {
                    ParameterName = "@maxAge",
                    SqlDbType = SqlDbType.Int,
                    // указываем, что параметр будет выходным
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(maxAgeParam);

                await command.ExecuteNonQueryAsync();
                object minAge = command.Parameters["@minAge"].Value;
                object maxAge = command.Parameters["@maxAge"].Value;
                Console.WriteLine($"Минимальный возраст: {minAge}");
                Console.WriteLine($"Максимальный возраст: {maxAge}");
            }
        }
    }
}
