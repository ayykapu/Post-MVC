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
    [Migration("20240123021351_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Data.Entities.CommentEntity", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentAuthor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            CommentAuthor = "Karolina",
                            CommentContent = "Już nie mogę się doczekać!",
                            CommentDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9342),
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 2,
                            CommentAuthor = "Milena",
                            CommentContent = "Słabo im szło w tym sezonie.",
                            CommentDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9396),
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 3,
                            CommentAuthor = "Andrzej",
                            CommentContent = "Tak, doszło do trzykrotnego zwiększenia jej wielkości.",
                            CommentDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9398),
                            PostId = 3
                        },
                        new
                        {
                            CommentId = 4,
                            CommentAuthor = "Karol",
                            CommentContent = "Oczywiście, że Toyota!",
                            CommentDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9400),
                            PostId = 4
                        },
                        new
                        {
                            CommentId = 5,
                            CommentAuthor = "Sam",
                            CommentContent = "Najgorsze jest to, że na premierę na PC poczekamy pewnie do 2027.",
                            CommentDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9401),
                            PostId = 5
                        });
                });

            modelBuilder.Entity("Data.Entities.PostEntity", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostAuthor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            PostAuthor = "Janek",
                            PostContent = "W 2025 wybory na prezydenta!",
                            PostDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9432),
                            TagId = 1
                        },
                        new
                        {
                            PostId = 2,
                            PostAuthor = "Grzegorz",
                            PostContent = "Real Madryt odpadł z ligi mistrzów.",
                            PostDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9436),
                            TagId = 2
                        },
                        new
                        {
                            PostId = 3,
                            PostAuthor = "Ania",
                            PostContent = "Wiatr słoneczny zniekształcił atmosfere marsa!",
                            PostDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9437),
                            TagId = 3
                        },
                        new
                        {
                            PostId = 4,
                            PostAuthor = "Kasia",
                            PostContent = "Toyota Supra vs Nissan Skyline R34?",
                            PostDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9438),
                            TagId = 4
                        },
                        new
                        {
                            PostId = 5,
                            PostAuthor = "Alex",
                            PostContent = "Nie mogę się doczekać premiery GTA VI!",
                            PostDate = new DateTime(2024, 1, 23, 3, 13, 51, 4, DateTimeKind.Local).AddTicks(9440),
                            TagId = 5
                        });
                });

            modelBuilder.Entity("Data.Entities.TagEntity", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            TagTitle = "Tag1"
                        },
                        new
                        {
                            TagId = 2,
                            TagTitle = "Tag2"
                        },
                        new
                        {
                            TagId = 3,
                            TagTitle = "Tag3"
                        },
                        new
                        {
                            TagId = 4,
                            TagTitle = "Tag4"
                        },
                        new
                        {
                            TagId = 5,
                            TagTitle = "Tag5"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3507a266-a9b6-4591-9ef1-be4056725bf9",
                            ConcurrencyStamp = "3507a266-a9b6-4591-9ef1-be4056725bf9",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "7d37937e-210e-4943-88be-c42475a8d975",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f043611a-1470-4ac0-8584-77c4cbf0bdb9",
                            Email = "kacper@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "KACPER@WSEI.EDU.PL",
                            NormalizedUserName = "KACPER",
                            PasswordHash = "AQAAAAIAAYagAAAAEDOJM0dY1OainPHrQxyIwjO/vQgiVmg8AlLtvzbmnawYUep9eArfOjvWOc/M5hfiiQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8af4d62d-7880-481c-8d99-5c3da8fae63a",
                            TwoFactorEnabled = false,
                            UserName = "Kacper"
                        },
                        new
                        {
                            Id = "d063f214-cbff-4fbe-a511-30e9947fb282",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "56dc2171-02d1-4e2a-b1b2-eabf3c88615a",
                            Email = "hubert@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "HUBERT@WSEI.EDU.PL",
                            NormalizedUserName = "HUBERT",
                            PasswordHash = "AQAAAAIAAYagAAAAEGBhOiwrRQRVQgOQo6y8qoVJzaG6HHRLIftM8KgFE/+14GlaIADbnM8QAVRZA8cOOA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4a3bdf2c-da1d-42c5-b9fe-76299fd1df30",
                            TwoFactorEnabled = false,
                            UserName = "Hubert"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "7d37937e-210e-4943-88be-c42475a8d975",
                            RoleId = "3507a266-a9b6-4591-9ef1-be4056725bf9"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Entities.CommentEntity", b =>
                {
                    b.HasOne("Data.Entities.PostEntity", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Data.Entities.PostEntity", b =>
                {
                    b.HasOne("Data.Entities.TagEntity", "Tag")
                        .WithMany("Posts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.PostEntity", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Data.Entities.TagEntity", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
