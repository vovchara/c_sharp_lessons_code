using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SQLServExample1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Hello World!");

            using (var db = new AppContext())
            {
                var isAvalaible = db.Database.CanConnect();
                //// получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
                var company = new Company { Name = "Playtika", Employees = 3000};
                db.Companys.Add(company);
                db.SaveChanges();
                var comps = db.Companys.ToList();
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public User()
        {
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Employees { get; set; }

        public Company()
        {
        }
    }
}
