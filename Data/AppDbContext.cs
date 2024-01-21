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
        public DbSet<OrganizationEntity> Organizations { get; set; }

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
            modelBuilder.Entity<OrganizationEntity>()
           .OwnsOne(e => e.Address);

            modelBuilder.Entity<PostEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Posts)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
        new OrganizationEntity()
        {
            Id = 1,
            Title = "WSEI",
            Nip = "83492384",
            Regon = "13424234",
        },
        new OrganizationEntity()
        {
            Id = 2,
            Title = "Firma",
            Nip = "2498534",
            Regon = "0873439249",
        } );

            modelBuilder.Entity<OrganizationEntity>().OwnsOne(e => e.Address).HasData(
                new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                new { OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" } );

            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity { Id = 1, Content = "Content1", Author = "Author1", Date = new DateTime(2000, 04, 10), Comment = "Comment1", Tags = "Sport" },
                new PostEntity { Id = 2, Content = "Content2", Author = "Author2", Date = new DateTime(2001, 05, 11), Comment = "Comment2", Tags = "Sport" }
            );
        }
    }
}
