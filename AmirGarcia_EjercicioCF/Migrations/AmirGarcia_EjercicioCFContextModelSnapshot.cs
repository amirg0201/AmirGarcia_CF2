﻿// <auto-generated />
using System;
using AmirGarcia_EjercicioCF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmirGarcia_EjercicioCF.Migrations
{
    [DbContext(typeof(AmirGarcia_EjercicioCFContext))]
    partial class AmirGarcia_EjercicioCFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmirGarcia_EjercicioCF.Models.Burger", b =>
                {
                    b.Property<int>("Burgerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Burgerid"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("WithCheese")
                        .HasColumnType("bit");

                    b.HasKey("Burgerid");

                    b.ToTable("Burger");
                });

            modelBuilder.Entity("AmirGarcia_EjercicioCF.Models.Promo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Burgerid")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaPromo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Burgerid");

                    b.ToTable("Promo");
                });

            modelBuilder.Entity("AmirGarcia_EjercicioCF.Models.Promo", b =>
                {
                    b.HasOne("AmirGarcia_EjercicioCF.Models.Burger", "Burger")
                        .WithMany("Promo")
                        .HasForeignKey("Burgerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");
                });

            modelBuilder.Entity("AmirGarcia_EjercicioCF.Models.Burger", b =>
                {
                    b.Navigation("Promo");
                });
#pragma warning restore 612, 618
        }
    }
}
