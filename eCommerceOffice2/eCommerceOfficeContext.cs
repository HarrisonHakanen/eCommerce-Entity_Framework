using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Office
{
    public class eCommerceOfficeContext : DbContext
    {
        public DbSet<Colaborador>? Colaboradores { get; set; }
        public DbSet<ColaboradorSetor>? ColaboradoresSetores { get; set; }
        public DbSet<ColaboradorVeiculo>? ColaboradoresVeiculos { get; set; }
        public DbSet<Setor>? Setores { get; set; }
        public DbSet<Turma>? Turmas { get; set; }
        public DbSet<Veiculo>? Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=eCommerceOffice;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mapeamento EF < 5.0
            /*Relacionamento 1 para muitos com a classe intermediaria. Essa forma e utilizada para
             projetos EF < 5.0*/
            modelBuilder.Entity<ColaboradorSetor>().HasKey(a => new { a.SetorId, a.ColaboradorId });
            modelBuilder.Entity<ColaboradorSetor>()
                .HasOne(a => a.Colaborador)
                .WithMany(a => a.ColaboradorSetores)
                .HasForeignKey(a => a.ColaboradorId);

            modelBuilder.Entity<ColaboradorSetor>()
                .HasOne(a => a.Setor)
                .WithMany(a => a.ColaboradoresSetores)
                .HasForeignKey(a => a.SetorId);

            /*
            modelBuilder.Entity<Colaborador>().HasMany(a => a.ColaboradoresSetores).WithOne(a => a.Colaborador).HasForeignKey(a=>a.ColaboradorId);
            modelBuilder.Entity<Setor>().HasMany(a => a.ColaboradoresSetores).WithOne(a => a.Setor).HasForeignKey(a=>a.SetorId);
            */
            #endregion

            #region Mapeamento EF > 5.0

            /*Esse e um tipo de mapeamento explicito pra EF > 5.0 porem o proprio EF identifica
             esse relacionamento no proprio contexto*/
            modelBuilder.Entity<Colaborador>().HasMany(a => a.Turmas).WithMany(a => a.Colaboradores);

            #endregion

            #region Mapeamento hibrido 

            modelBuilder.Entity<Colaborador>().
                HasMany(a => a.Veiculos).
                WithMany(a => a.Colaboradores).
                UsingEntity<ColaboradorVeiculo>(
                    
                    q=>q.HasOne(a=>a.Veiculo).WithMany(a=>a.ColaboradoresVeiculos).HasForeignKey(a=>a.VeiculoId),
                    q=>q.HasOne(a=>a.Colaborador).WithMany(a=>a.ColaboradoresVeiculos).HasForeignKey(a=>a.ColaboradorId),

                    //Caso precie definir a Key
                    q => q.HasKey(a => new {a.ColaboradorId,a.VeiculoId})
                
                );


            modelBuilder.Entity<ColaboradorVeiculo>().HasKey(a => new { a.VeiculoId, a.ColaboradorId });
            
            modelBuilder.Entity<ColaboradorVeiculo>()
                .HasOne(a => a.Colaborador)
                .WithMany(a => a.ColaboradoresVeiculos)
                .HasForeignKey(a => a.ColaboradorId);

            modelBuilder.Entity<ColaboradorVeiculo>()
                .HasOne(a => a.Veiculo)
                .WithMany(a => a.ColaboradoresVeiculos)
                .HasForeignKey(a => a.VeiculoId);


            #endregion

            #region Seeds
            modelBuilder.Entity<Colaborador>().HasData(

                new Colaborador() { Id = 1, Nome = "Pedro" },
                new Colaborador() { Id = 2, Nome = "Joao" },
                new Colaborador() { Id = 3, Nome = "Gisele" },
                new Colaborador() { Id = 4, Nome = "Beatriz" },
                new Colaborador() { Id = 5, Nome = "Tiago" },
                new Colaborador() { Id = 6, Nome = "Simone" },
                new Colaborador() { Id = 7, Nome = "Marcelo" }

                );

            modelBuilder.Entity<Setor>().HasData(

                new Setor() { Id = 1, Nome = "Logistica" },
                new Setor() { Id = 2, Nome = "Separacao" },
                new Setor() { Id = 3, Nome = "Financeiro" },
                new Setor() { Id = 4, Nome = "Administrativo" }


                );


            modelBuilder.Entity<ColaboradorSetor>().HasData(

                new ColaboradorSetor() { SetorId = 1, ColaboradorId = 1, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 1, ColaboradorId = 2, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 2, ColaboradorId = 3, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 2, ColaboradorId = 4, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 3, ColaboradorId = 1, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 3, ColaboradorId = 5, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 4, ColaboradorId = 6, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 4, ColaboradorId = 7, Criado = DateTimeOffset.Now }

                );


            modelBuilder.Entity<Turma>().HasData(
                
                new Turma() { Id = 1, Nome = " Turma A" },
                new Turma() { Id = 2, Nome = " Turma B" },
                new Turma() { Id = 3, Nome = " Turma C" },
                new Turma() { Id = 4, Nome = " Turma D" }

                );


            modelBuilder.Entity<Veiculo>().HasData(

                new Veiculo() { Id = 1, Nome = "Fusca",Placa = "AO1106" },
                new Veiculo() { Id = 2, Nome = " Gol quadrado ",Placa = "AGE2368" },
                new Veiculo() { Id = 3, Nome = " Kombi",Placa= "DAY6690" },
                new Veiculo() { Id = 4, Nome = " Fiorino ",Placa="HUU3389" }

                );

            #endregion
        }


    }
}
