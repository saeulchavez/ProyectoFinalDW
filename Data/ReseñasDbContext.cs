using Microsoft.EntityFrameworkCore;
using ProyectoFinalDW.Models;

namespace ProyectoFinalDW.Data
{
    public class ReseñasDbContext : DbContext
    {
        public ReseñasDbContext(DbContextOptions<ReseñasDbContext> options) : base(options) { }

        public ReseñasDbContext() { }
        public DbSet<Pese> Peses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReseñasDB;Trusted_Connection=True;");
            }
        }
    }
}