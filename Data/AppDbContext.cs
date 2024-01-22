using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

        private string Path { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "posts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PostEntity>().HasOne(c => c.Tag).WithMany(o => o.Posts).HasForeignKey(c => c.TagId);
            modelBuilder.Entity<CommentEntity>().HasOne(c => c.Post).WithMany(o => o.Comments).HasForeignKey(c => c.PostId);

            modelBuilder.Entity<TagEntity>().HasData(
                new
                {
                    TagId = 1,
                    TagTitle = "Tag1",

                },
                new
                {
                    TagId = 2,
                    TagTitle = "Tag2",

                },
                new
                {
                    TagId = 3,
                    TagTitle = "Tag3",

                },
                new
                {
                    TagId = 4,
                    TagTitle = "Tag4",

                },
                new
                {
                    TagId = 5,
                    TagTitle = "Tag5",

                }
                );
            modelBuilder.Entity<CommentEntity>().HasData(
                new
                {
                    CommentId = 1,
                    PostId = 1,
                    CommentAuthor = "Karolina",
                    CommentContent = "Już nie mogę się doczekać!",
                    CommentDate = DateTime.Now,
                },
                new
                {
                    CommentId = 2,
                    PostId = 2,
                    CommentAuthor = "Milena",
                    CommentContent = "Słabo im szło w tym sezonie.",
                    CommentDate = DateTime.Now,
                },
                new
                {
                    CommentId = 3,
                    PostId = 3,
                    CommentAuthor = "Andrzej",
                    CommentContent = "Tak, doszło do trzykrotnego zwiększenia jej wielkości.",
                    CommentDate = DateTime.Now,
                },
                new
                {
                    CommentId = 4,
                    PostId = 4,
                    CommentAuthor = "Karol",
                    CommentContent = "Oczywiście, że Toyota!",
                    CommentDate = DateTime.Now,
                },
                new
                {
                    CommentId = 5,
                    PostId = 5,
                    CommentAuthor = "Sam",
                    CommentContent = "Najgorsze jest to, że na premierę na PC poczekamy pewnie do 2027.",
                    CommentDate = DateTime.Now,
                }
                );

            modelBuilder.Entity<PostEntity>().HasData(
                new
                {
                    PostId = 1,
                    PostAuthor = "Janek",
                    TagId = 1,
                    PostContent = "W 2025 wybory na prezydenta!",
                    PostDate = DateTime.Now
                },
                new
                {
                    PostId = 2,
                    PostAuthor = "Grzegorz",
                    TagId = 2,
                    PostContent = "Real Madryt odpadł z ligi mistrzów.",
                    PostDate = DateTime.Now
                },
                new
                {
                    PostId = 3,
                    PostAuthor = "Ania",
                    TagId = 3,
                    PostContent = "Wiatr słoneczny zniekształcił atmosfere marsa!",
                    PostDate = DateTime.Now
                },
                new
                {
                    PostId = 4,
                    PostAuthor = "Kasia",
                    TagId = 4,
                    PostContent = "Toyota Supra vs Nissan Skyline R34?",
                    PostDate = DateTime.Now,

                },
                new
                {
                    PostId = 5,
                    PostAuthor = "Alex",
                    TagId = 5,
                    PostContent = "Nie mogę się doczekać premiery GTA VI!",
                    PostDate = DateTime.Now,
                }
                );

            base.OnModelCreating(modelBuilder);

            var admin = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Kacper",
                NormalizedUserName = "KACPER",
                Email = "kacper@wsei.edu.pl",
                NormalizedEmail = "KACPER@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Hubert",
                NormalizedUserName = "HUBERT",
                Email = "hubert@wsei.edu.pl",
                NormalizedEmail = "HUBERT@WSEI.EDU.PL",
                EmailConfirmed = true,
            };
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();

            admin.PasswordHash = passwordHasher.HashPassword(admin, "123!Abc");
            user.PasswordHash = passwordHasher.HashPassword(user, "1234Abcd!");

            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);

            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN",
            };

            adminRole.ConcurrencyStamp = adminRole.Id;
            modelBuilder.Entity<IdentityRole>().HasData(adminRole);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = admin.Id,
                });

        }
    }
}
