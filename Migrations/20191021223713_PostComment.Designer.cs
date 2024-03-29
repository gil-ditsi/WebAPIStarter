﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIStarter.Data;

namespace WebAPIStarter.Migrations
{
    [DbContext(typeof(WebAPIStarterContext))]
    [Migration("20191021223713_PostComment")]
    partial class PostComment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("WebAPIStarter.Data.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Line2")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("StateProvice")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Zipcode")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WebAPIStarter.Data.Models.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressTypeName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("WebAPIStarter.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebAPIStarter.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebAPIStarter.Data.Models.CustomerAddress", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("AddressId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("WebAPIStarter.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WebAPIStarter.Data.Models.Address", b =>
                {
                    b.HasOne("WebAPIStarter.Data.Models.AddressType", "AddressType")
                        .WithMany()
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPIStarter.Data.Models.Comment", b =>
                {
                    b.HasOne("WebAPIStarter.Data.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPIStarter.Data.Models.CustomerAddress", b =>
                {
                    b.HasOne("WebAPIStarter.Data.Models.Address", "Address")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPIStarter.Data.Models.Customer", "Customer")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
