﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Raffle.Infrastructure.EntityFramework;

#nullable disable

namespace Raffle.Raffle.Infrastructure.Migrations
{
    [DbContext(typeof(PersistenceContext))]
    [Migration("20241019074327_Migration Initial Raffle")]
    partial class MigrationInitialRaffle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Raffle.Domain.Entities.AssignedNumber.AssignedNumberEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDateTime");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Number");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateDateTime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("AssignedNumber", "dbo");
                });

            modelBuilder.Entity("Raffle.Domain.Entities.Client.ClientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateDateTime");

                    b.HasKey("Id");

                    b.ToTable("Client", "dbo");
                });

            modelBuilder.Entity("Raffle.Domain.Entities.Product.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClientId");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDateTime");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateDateTime");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Product", "dbo");
                });

            modelBuilder.Entity("Raffle.Domain.Entities.User.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDateTime");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FullName");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Phone");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateDateTime");

                    b.HasKey("Id");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("Raffle.Domain.Entities.AssignedNumber.AssignedNumberEntity", b =>
                {
                    b.HasOne("Raffle.Domain.Entities.Product.ProductEntity", "Product")
                        .WithMany("AssignedNumbers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Raffle.Domain.Entities.User.UserEntity", "User")
                        .WithMany("AssignedNumbers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Raffle.Domain.Entities.Product.ProductEntity", b =>
                {
                    b.HasOne("Raffle.Domain.Entities.Client.ClientEntity", "Client")
                        .WithMany("Products")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Raffle.Domain.Entities.Client.ClientEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Raffle.Domain.Entities.Product.ProductEntity", b =>
                {
                    b.Navigation("AssignedNumbers");
                });

            modelBuilder.Entity("Raffle.Domain.Entities.User.UserEntity", b =>
                {
                    b.Navigation("AssignedNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
