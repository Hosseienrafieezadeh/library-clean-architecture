using Library.Entitis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EF.EntitisMaps
{
    public class EFDataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=tavvbook;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);

        }
    }
}
