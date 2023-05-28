using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using eCommerce.Console.Models;

namespace eCommerce.Console.Database
{
    public partial class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext()
        {
        }

        public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contato> Contatos { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<EnderecosEntrega> EnderecosEntregas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
        
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=eCommerceDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId, "IX_Contatos_UsuarioId")
                    .IsUnique();

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.Contato)
                    .HasForeignKey<Contato>(d => d.UsuarioId);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasMany(d => d.Usuarios)
                    .WithMany(p => p.Departamentos)
                    .UsingEntity<Dictionary<string, object>>(
                        "DepartamentoUsuario",
                        l => l.HasOne<Usuario>().WithMany().HasForeignKey("UsuariosId"),
                        r => r.HasOne<Departamento>().WithMany().HasForeignKey("DepartamentosId"),
                        j =>
                        {
                            j.HasKey("DepartamentosId", "UsuariosId");

                            j.ToTable("DepartamentoUsuario");

                            j.HasIndex(new[] { "UsuariosId" }, "IX_DepartamentoUsuario_UsuariosId");
                        });
            });

            modelBuilder.Entity<EnderecosEntrega>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId, "IX_EnderecosEntregas_UsuarioId");

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.EnderecosEntregas)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.Rg).HasColumnName("RG");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
