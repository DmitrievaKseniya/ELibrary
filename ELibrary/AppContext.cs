using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary
{
    public class AppContext : DbContext
    {
        //Объекты таблицы User
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5EUO4AB\SQLEXPRESS;Database=ELibrary;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }
    }
}
