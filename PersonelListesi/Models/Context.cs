using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelListesi.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-2RFMJGK\\SQLEXPRESS01;database=UserData;integrated security=true;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Depart> Depart { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
