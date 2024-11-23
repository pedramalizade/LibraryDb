using HW_Week_13.Configs;
using HW_Week_13.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.DbContextt
{
    public class AppDbContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.ConfigureWarnings(warnings =>
            //      warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            optionsBuilder.UseSqlServer("Server=DESKTOP-O8SFUP7\\SQLEXP; DataBase=LibraryDb; Integrated Security=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
