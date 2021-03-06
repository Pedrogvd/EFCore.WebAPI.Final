// <auto-generated />
using System;
using EFCore.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.Repositorio.Migrations
{
    [DbContext(typeof(HeroiContext))]
    [Migration("20220503200221_VoltandoHeroisAoNormal")]
    partial class VoltandoHeroisAoNormal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EFCore.Dominio.Arma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeroiId");

                    b.ToTable("Armas");
                });

            modelBuilder.Entity("EFCore.Dominio.Batalha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Batalhas");
                });

            modelBuilder.Entity("EFCore.Dominio.Heroi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BatalhaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatalhaId");

                    b.ToTable("Herois");
                });

            modelBuilder.Entity("EFCore.Dominio.HeroiBatalha", b =>
                {
                    b.Property<int>("BatalhaId")
                        .HasColumnType("int");

                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.HasKey("BatalhaId", "HeroiId");

                    b.HasIndex("HeroiId");

                    b.ToTable("HeroisBatalhas");
                });

            modelBuilder.Entity("EFCore.Dominio.IdentidadeSecreta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.Property<int>("NomeReal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeroiId")
                        .IsUnique();

                    b.ToTable("IdentidadeSecretas");
                });

            modelBuilder.Entity("EFCore.Dominio.Arma", b =>
                {
                    b.HasOne("EFCore.Dominio.Heroi", "Heroi")
                        .WithMany("Armas")
                        .HasForeignKey("HeroiId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EFCore.Dominio.Heroi", b =>
                {
                    b.HasOne("EFCore.Dominio.Batalha", "Batalha")
                        .WithMany()
                        .HasForeignKey("BatalhaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Batalha");
                });

            modelBuilder.Entity("EFCore.Dominio.HeroiBatalha", b =>
                {
                    b.HasOne("EFCore.Dominio.Batalha", "Batalha")
                        .WithMany("HeroisBatalhas")
                        .HasForeignKey("BatalhaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("EFCore.Dominio.Heroi", "Heroi")
                        .WithMany("HeroisBatalhas")
                        .HasForeignKey("HeroiId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Batalha");

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EFCore.Dominio.IdentidadeSecreta", b =>
                {
                    b.HasOne("EFCore.Dominio.Heroi", "Heroi")
                        .WithOne("IdentidadeSecreta")
                        .HasForeignKey("EFCore.Dominio.IdentidadeSecreta", "HeroiId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EFCore.Dominio.Batalha", b =>
                {
                    b.Navigation("HeroisBatalhas");
                });

            modelBuilder.Entity("EFCore.Dominio.Heroi", b =>
                {
                    b.Navigation("Armas");

                    b.Navigation("HeroisBatalhas");

                    b.Navigation("IdentidadeSecreta");
                });
#pragma warning restore 612, 618
        }
    }
}
