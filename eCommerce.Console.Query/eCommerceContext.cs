using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext: DbContext
    {
        #region
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=eCommerceDB;Integrated Security=True;")                ;
        }
        
        #endregion

        public DbSet<Usuario>? Usuarios  { get; set; }

        public DbSet<Contato>? Contatos { get; set; }

        public DbSet<Departamento>? Departamentos { get; set; }

        public DbSet<EnderecoEntrega>? EnderecosEntregas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }


    }
}
