﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Data.Entities.GroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Wyższa Szkoła Ekonomii i Informatyki w Krakowie",
                            Name = "WSEI"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Akademia Górniczo-Hutnicza w Krakowie",
                            Name = "AGH"
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

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

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

            modelBuilder.Entity("Data.Entities.GroupEntity", b =>
                {
                    b.OwnsOne("Data.Members", "Members", b1 =>
                        {
                            b1.Property<int>("GroupEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("CountryMostMembers")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("HighestRankMember")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("NumberOfMembers")
                                .HasColumnType("INTEGER");

                            b1.HasKey("GroupEntityId");

                            b1.ToTable("Groups");

                            b1.WithOwner()
                                .HasForeignKey("GroupEntityId");

                            b1.HasData(
                                new
                                {
                                    GroupEntityId = 1,
                                    CountryMostMembers = "Polska",
                                    HighestRankMember = "Member1",
                                    NumberOfMembers = 30
                                },
                                new
                                {
                                    GroupEntityId = 2,
                                    CountryMostMembers = "USA",
                                    HighestRankMember = "Member145/6",
                                    NumberOfMembers = 50
                                });
                        });

                    b.Navigation("Members");
                });

            modelBuilder.Entity("Data.Entities.PostEntity", b =>
                {
                    b.HasOne("Data.Entities.GroupEntity", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Data.Entities.GroupEntity", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
