﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerce.Office;

#nullable disable

namespace eCommerce.Office.Migrations
{
    [DbContext(typeof(eCommerceOfficeContext))]
    [Migration("20230527234441_Migra04")]
    partial class Migra04
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ColaboradorTurma", b =>
                {
                    b.Property<int>("ColaboradoresId")
                        .HasColumnType("int");

                    b.Property<int>("TurmasId")
                        .HasColumnType("int");

                    b.HasKey("ColaboradoresId", "TurmasId");

                    b.HasIndex("TurmasId");

                    b.ToTable("ColaboradorTurma");
                });

            modelBuilder.Entity("eCommerce.Office.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colaboradores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Pedro"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Joao"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Gisele"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Beatriz"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Tiago"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Simone"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Marcelo"
                        });
                });

            modelBuilder.Entity("eCommerce.Office.Models.ColaboradorSetor", b =>
                {
                    b.Property<int>("SetorId")
                        .HasColumnType("int");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Criado")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("SetorId", "ColaboradorId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("ColaboradoresSetores");

                    b.HasData(
                        new
                        {
                            SetorId = 1,
                            ColaboradorId = 1,
                            Criado = new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8872), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SetorId = 1,
                            ColaboradorId = 2,
                            Criado = new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SetorId = 2,
                            ColaboradorId = 3,
                            Criado = new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8908), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SetorId = 2,
                            ColaboradorId = 4,
                            Criado = new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SetorId = 3,
                            ColaboradorId = 1,
                            Criado = new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8914), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SetorId = 3,
                            ColaboradorId = 5,
                            Criado = new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8917), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SetorId = 4,
                            ColaboradorId = 6,
                            Criado = new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8919), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SetorId = 4,
                            ColaboradorId = 7,
                            Criado = new DateTimeOffset(new DateTime(2023, 5, 27, 20, 44, 40, 241, DateTimeKind.Unspecified).AddTicks(8922), new TimeSpan(0, -3, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("eCommerce.Office.Models.ColaboradorVeiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DataAtribuicao")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("VeiculoId", "ColaboradorId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("ColaboradoresVeiculos");
                });

            modelBuilder.Entity("eCommerce.Office.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Logistica"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Separacao"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Financeiro"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Administrativo"
                        });
                });

            modelBuilder.Entity("eCommerce.Office.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Turmas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = " Turma A"
                        },
                        new
                        {
                            Id = 2,
                            Nome = " Turma B"
                        },
                        new
                        {
                            Id = 3,
                            Nome = " Turma C"
                        },
                        new
                        {
                            Id = 4,
                            Nome = " Turma D"
                        });
                });

            modelBuilder.Entity("eCommerce.Office.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Fusca",
                            Placa = "AO1106"
                        },
                        new
                        {
                            Id = 2,
                            Nome = " Gol quadrado ",
                            Placa = "AGE2368"
                        },
                        new
                        {
                            Id = 3,
                            Nome = " Kombi",
                            Placa = "DAY6690"
                        },
                        new
                        {
                            Id = 4,
                            Nome = " Fiorino ",
                            Placa = "HUU3389"
                        });
                });

            modelBuilder.Entity("ColaboradorTurma", b =>
                {
                    b.HasOne("eCommerce.Office.Models.Colaborador", null)
                        .WithMany()
                        .HasForeignKey("ColaboradoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Office.Models.Turma", null)
                        .WithMany()
                        .HasForeignKey("TurmasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eCommerce.Office.Models.ColaboradorSetor", b =>
                {
                    b.HasOne("eCommerce.Office.Models.Colaborador", "Colaborador")
                        .WithMany("ColaboradorSetores")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Office.Models.Setor", "Setor")
                        .WithMany("ColaboradoresSetores")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("eCommerce.Office.Models.ColaboradorVeiculo", b =>
                {
                    b.HasOne("eCommerce.Office.Models.Colaborador", "Colaborador")
                        .WithMany("ColaboradoresVeiculos")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Office.Models.Veiculo", "Veiculo")
                        .WithMany("ColaboradoresVeiculos")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("eCommerce.Office.Models.Colaborador", b =>
                {
                    b.Navigation("ColaboradorSetores");

                    b.Navigation("ColaboradoresVeiculos");
                });

            modelBuilder.Entity("eCommerce.Office.Models.Setor", b =>
                {
                    b.Navigation("ColaboradoresSetores");
                });

            modelBuilder.Entity("eCommerce.Office.Models.Veiculo", b =>
                {
                    b.Navigation("ColaboradoresVeiculos");
                });
#pragma warning restore 612, 618
        }
    }
}