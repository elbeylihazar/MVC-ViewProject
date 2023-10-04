﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyView.MyViewData;

#nullable disable

namespace MyView.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231004115031_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyView.Models.Satis", b =>
                {
                    b.Property<int>("SatisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatisID"), 1L, 1);

                    b.Property<DateTime>("SatisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("UrunID")
                        .HasColumnType("int");

                    b.HasKey("SatisID");

                    b.HasIndex("UrunID");

                    b.ToTable("Satislar");

                    b.HasData(
                        new
                        {
                            SatisID = 1,
                            SatisTarihi = new DateTime(2023, 9, 10, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunID = 1
                        },
                        new
                        {
                            SatisID = 2,
                            SatisTarihi = new DateTime(2023, 9, 11, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            UrunID = 2
                        },
                        new
                        {
                            SatisID = 3,
                            SatisTarihi = new DateTime(2023, 9, 12, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            UrunID = 1
                        },
                        new
                        {
                            SatisID = 4,
                            SatisTarihi = new DateTime(2023, 9, 13, 16, 45, 0, 0, DateTimeKind.Unspecified),
                            UrunID = 3
                        });
                });

            modelBuilder.Entity("MyView.Models.SatisDetay", b =>
                {
                    b.Property<int>("SatisDetayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatisDetayID"), 1L, 1);

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<int>("SatisID")
                        .HasColumnType("int");

                    b.Property<int>("UrunID")
                        .HasColumnType("int");

                    b.HasKey("SatisDetayID");

                    b.HasIndex("SatisID");

                    b.HasIndex("UrunID");

                    b.ToTable("SatisDetaylari");

                    b.HasData(
                        new
                        {
                            SatisDetayID = 1,
                            Miktar = 3,
                            SatisID = 1,
                            UrunID = 1
                        },
                        new
                        {
                            SatisDetayID = 2,
                            Miktar = 2,
                            SatisID = 2,
                            UrunID = 2
                        },
                        new
                        {
                            SatisDetayID = 3,
                            Miktar = 1,
                            SatisID = 3,
                            UrunID = 1
                        },
                        new
                        {
                            SatisDetayID = 4,
                            Miktar = 4,
                            SatisID = 4,
                            UrunID = 3
                        });
                });

            modelBuilder.Entity("MyView.Models.Urun", b =>
                {
                    b.Property<int>("UrunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UrunID"), 1L, 1);

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UrunID");

                    b.ToTable("Urunler");

                    b.HasData(
                        new
                        {
                            UrunID = 1,
                            UrunAdi = "Laptop"
                        },
                        new
                        {
                            UrunID = 2,
                            UrunAdi = "Akıllı Telefon"
                        },
                        new
                        {
                            UrunID = 3,
                            UrunAdi = "Tablet"
                        });
                });

            modelBuilder.Entity("MyView.Models.Satis", b =>
                {
                    b.HasOne("MyView.Models.Urun", "Urun")
                        .WithMany()
                        .HasForeignKey("UrunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("MyView.Models.SatisDetay", b =>
                {
                    b.HasOne("MyView.Models.Satis", "Satis")
                        .WithMany("SatisDetaylari")
                        .HasForeignKey("SatisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyView.Models.Urun", "Urun")
                        .WithMany("SatisDetaylari")
                        .HasForeignKey("UrunID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Satis");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("MyView.Models.Satis", b =>
                {
                    b.Navigation("SatisDetaylari");
                });

            modelBuilder.Entity("MyView.Models.Urun", b =>
                {
                    b.Navigation("SatisDetaylari");
                });
#pragma warning restore 612, 618
        }
    }
}
