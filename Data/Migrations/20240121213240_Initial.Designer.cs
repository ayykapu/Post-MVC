﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240121213240_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Regon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nip = "83492384",
                            Regon = "13424234",
                            Title = "WSEI"
                        },
                        new
                        {
                            Id = 2,
                            Nip = "2498534",
                            Regon = "0873439249",
                            Title = "Firma"
                        });
                });

            modelBuilder.Entity("Data.Entities.PostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Author1",
                            Comment = "Comment1",
                            Content = "Content1",
                            Date = new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tags = "Sport"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Author2",
                            Comment = "Comment2",
                            Content = "Content2",
                            Date = new DateTime(2001, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tags = "Sport"
                        });
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.OwnsOne("Data.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("Organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 1,
                                    City = "Kraków",
                                    PostalCode = "31-150",
                                    Region = "małopolskie",
                                    Street = "Św. Filipa 17"
                                },
                                new
                                {
                                    OrganizationEntityId = 2,
                                    City = "Kraków",
                                    PostalCode = "31-150",
                                    Region = "małopolskie",
                                    Street = "Krowoderska 45/6"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.PostEntity", b =>
                {
                    b.HasOne("Data.Entities.OrganizationEntity", "Organization")
                        .WithMany("Posts")
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}