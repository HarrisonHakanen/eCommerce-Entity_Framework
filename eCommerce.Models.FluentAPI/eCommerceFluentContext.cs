using eCommerce.Models.FluentAPI.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.FluentAPI
{
    public class eCommerceFluentContext: DbContext
    {
        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {

        }

        public DbSet<Usuario>? Usuarios { get; set; }

        public DbSet<Contato>? Contatos { get; set; }

        public DbSet<Departamento>? Departamentos { get; set; }

        public DbSet<EnderecoEntrega>? EnderecosEntregas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Todo esse codigo foi para a pasta Configurations
            #region CodigoRealocado
            /*
            //Configura o nome da tabela
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            //Altera configuracoes do campo
            modelBuilder.Entity<Usuario>().Property(a => a.RG).HasColumnName("REGISTRO_GERAL").HasMaxLength(10).HasDefaultValue("RG_AUSENTE").IsRequired();

            //Nao mapeia informacao
            modelBuilder.Entity<Usuario>().Ignore(a => a.Sexo);

            //Determina se vai ser ou nao o banco a gerenciar o campo (None,Identity,Computed)
            modelBuilder.Entity<Usuario>().Property(a => a.Id).ValueGeneratedOnAdd();

            //Colocando Index, determinando campo sendo unico, renomeando indice, e filtrando para que ocorra apenas nos que nao sao nulos
            modelBuilder.Entity<Usuario>().HasIndex(a => a.CPF).IsUnique().HasDatabaseName("IX_CPF_UNIQUE").HasFilter("[CPF] is not null");
            modelBuilder.Entity<Usuario>().HasIndex(a => new { a.CPF, a.Email });

            //Configuracao da Key - Este e apenas um exemplo de estudo. Ignore a logica aplicada
            modelBuilder.Entity<Usuario>().HasKey(a => new { a.Id, a.CPF });

            //Chave alternativa
            modelBuilder.Entity<Usuario>().HasAlternateKey(a =>  a.Email);

            
            
            //CONSTRUINDO O RELACIONAMENTO

            //Usuario tem um contato e contato trabalho com um usuario
            //Um para um, se deve dizer quem e a classe forte para colocar a foreign key
            //Deleta pelo banco em forma de cascat
            modelBuilder.Entity<Usuario>().HasOne(usuario=>usuario.Contato).WithOne(contato=>contato.Usuario).HasForeignKey<Contato>(contato=>contato.UsuarioId).OnDelete(DeleteBehavior.Cascade);

            //Usuario tem muitos enderecos e enderecos trabalha com um usuario
            //Quando sao muitos para um ele ja sabe quem e a classe forte para declarar a foreign key
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.EnderecosEntrega).WithOne(endereco => endereco.Usuario).HasForeignKey(endereco=>endereco.UsuarioId);

            //Usuario tem muitos departamentos e departamentos trabalham com muitos usuarios
            //Nesse caso, muitos para muitos nao se coloca a foreign key, ela fica na tabela intermediaria
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.Departamentos).WithMany(departamento => departamento.Usuarios);


            //HasPrecision e uma forma de garantir que o salario fique com somente 2 numeros apos a virgula
            modelBuilder.Entity<Usuario>().Property(a => a.Salario).HasPrecision(2).IsRequired();

            #endregion

            */
            #endregion


            //Instancia as configuracoes em um arquivo separado
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

        }


    }
}
