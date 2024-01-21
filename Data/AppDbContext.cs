using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }

        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "post.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupEntity>()
           .OwnsOne(e => e.Members);

            modelBuilder.Entity<PostEntity>()
                .HasOne(e => e.Group)
                .WithMany(o => o.Posts)
                .HasForeignKey(e => e.GroupId);

            modelBuilder.Entity<GroupEntity>().HasData(
        new GroupEntity()
        {
            Id = 1,
            Name = "WSEI",
            Description = "Wyższa Szkoła Ekonomii i Informatyki w Krakowie",
            CreateDate = new DateTime(2000, 04, 10),
        },
        new GroupEntity()
        {
            Id = 2,
            Name = "AGH",
            Description = "Akademia Górniczo-Hutnicza w Krakowie",
            CreateDate = new DateTime(2011, 04, 10),
        } );

            modelBuilder.Entity<GroupEntity>().OwnsOne(e => e.Members).HasData(
                new { GroupEntityId = 1, NumberOfMembers = 30, HighestRankMember = "Member1", CountryMostMembers = "Polska" },
                new { GroupEntityId = 2, NumberOfMembers = 50, HighestRankMember = "Member145/6", CountryMostMembers = "USA" } );

            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity { Id = 1, Content = "Content1", Author = "Author1", Date = new DateTime(2000, 04, 10), Comment = "Comment1", Tags = "Sport" },
                new PostEntity { Id = 2, Content = "Content2", Author = "Author2", Date = new DateTime(2001, 05, 11), Comment = "Comment2", Tags = "Sport" }
            );
        }
    }
}
