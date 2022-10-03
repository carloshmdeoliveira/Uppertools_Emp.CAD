using Microsoft.EntityFrameworkCore;

namespace WebEmpCad.Models
{
    public class BancoDeDados : DbContext
    {
        public DbSet<Empresa>? Empresas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=WebEmpCad;Integrated Security=True");
        }
    }
}
