using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Human> Humans { get; set; }

        public readonly string DbPath = "../../../main.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
