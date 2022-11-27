using ClientXML.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientXML.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Models.Client> Clients { get; set; }

        public ApplicationContext(): base()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasIndex(c => c.CardCode).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HENTAI\\MSSQLSERVERRUBAN;Integrated Security=True;Database=clients;Trusted_Connection=True");
        }
    }
}
