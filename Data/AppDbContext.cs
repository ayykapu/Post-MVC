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
            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity { Id = 1, Content = "Content1", Author = "Author1", Date = new DateTime(2000, 04, 10), Comment = "Comment1", Tags = "Sport" },
                new PostEntity { Id = 2, Content = "Content2", Author = "Author2", Date = new DateTime(2001, 05, 11), Comment = "Comment2", Tags = "Sport" },
                new PostEntity { Id = 3, Content = "Content3", Author = "Author3", Date = new DateTime(2002, 12, 12), Comment = "Comment3", Tags = "Tech" },
                new PostEntity { Id = 4, Content = "Content4", Author = "Author4", Date = new DateTime(2002, 04, 25), Comment = "Comment4", Tags = "Health" },
                new PostEntity { Id = 5, Content = "Content5", Author = "Author5", Date = new DateTime(2013, 03, 09), Comment = "Comment5", Tags = "New" }

            );
        }
    }
}
