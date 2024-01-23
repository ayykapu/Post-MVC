using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            base.OnModelCreating(modelBuilder);

            ///////// ADMIN ROLE //////////////
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Tadek",
                NormalizedUserName = "TADEK",
                Email = "tadek123@gmail.pl",
                NormalizedEmail = "TADEK123@GMAIL.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> adminPasswordHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = adminPasswordHasher.HashPassword(admin, "ABcd12#$");

            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            /////////////// MOD ROLE /////////////////
            string MOD_ID = Guid.NewGuid().ToString();
            string MOD_ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "mod",
                NormalizedName = "MOD",
                Id = MOD_ROLE_ID,
                ConcurrencyStamp = MOD_ROLE_ID
            });

            var mod = new IdentityUser
            {
                Id = MOD_ID,
                UserName = "Tomasz",
                NormalizedUserName = "TOMASZ",
                Email = "tomasz@o2.pl",
                NormalizedEmail = "TOMASZ@o2.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> modPasswordHasher = new PasswordHasher<IdentityUser>();
            mod.PasswordHash = modPasswordHasher.HashPassword(mod, "ABcd12#$!");

            modelBuilder.Entity<IdentityUser>().HasData(mod);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = MOD_ROLE_ID,
                    UserId = MOD_ID
                });

            /////////////// USER ROLE /////////////////
            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            var user = new IdentityUser
            {
                Id = USER_ID,
                UserName = "Arkadiusz",
                NormalizedUserName = "ARKADIUSZ",
                Email = "arkadiuszpol@onet.pl",
                NormalizedEmail = "ARKADIUSZPOL@ONET.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> userPasswordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = userPasswordHasher.HashPassword(user, "ABcd12#$");

            modelBuilder.Entity<IdentityUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });


            modelBuilder.Entity<PostEntity>().HasOne(c => c.Tag).WithMany(o => o.Posts).HasForeignKey(c => c.TagId);
            modelBuilder.Entity<CommentEntity>().HasOne(c => c.Post).WithMany(o => o.Comments).HasForeignKey(c => c.PostId);

            modelBuilder.Entity<TagEntity>().HasData(
         new
         {
             TagId = 1,
             TagTitle = "Rozrywka",
         },
         new
         {
             TagId = 2,
             TagTitle = "Nauka",
         },
         new
         {
             TagId = 3,
             TagTitle = "Polityka",
         },
         new
         {
             TagId = 4,
             TagTitle = "Zdrowie",
         },
         new
         {
             TagId = 5,
             TagTitle = "Sport",
         },
         new
         {
             TagId = 6,
             TagTitle = "Technologia",
         },
         new
         {
             TagId = 7,
             TagTitle = "Rozwój",
         },
         new
         {
             TagId = 8,
             TagTitle = "Odkrycia",
         },
         new
         {
             TagId = 9,
             TagTitle = "Podróże",
         },
         new
         {
             TagId = 10,
             TagTitle = "Innowacje",
         }
     );
                modelBuilder.Entity<CommentEntity>().HasData(
          new
          {
              CommentId = 1,
              PostId = 1,
              CommentAuthor = "Użytkownik1",
              CommentContent = "Świetny post!",
              CommentDate = DateTime.Now.AddDays(-2),
          },
          new
          {
              CommentId = 2,
              PostId = 1,
              CommentAuthor = "Użytkownik2",
              CommentContent = "Ciekawe spostrzeżenia!",
              CommentDate = DateTime.Now.AddDays(-1),
          },
          new
          {
              CommentId = 3,
              PostId = 2,
              CommentAuthor = "Użytkownik3",
              CommentContent = "Mam pytanie...",
              CommentDate = DateTime.Now.AddHours(-6),
          },
          new
          {
              CommentId = 4,
              PostId = 3,
              CommentAuthor = "Użytkownik4",
              CommentContent = "Dobrze napisane!",
              CommentDate = DateTime.Now.AddMinutes(-30),
          },
          new
          {
              CommentId = 5,
              PostId = 3,
              CommentAuthor = "Użytkownik5",
              CommentContent = "Zgadzam się całkowicie!",
              CommentDate = DateTime.Now.AddSeconds(-10),
          }
      );

                modelBuilder.Entity<PostEntity>().HasData(
        new
        {
            PostId = 1,
            PostAuthor = "Janek",
            TagId = 1,
            PostContent = "Lorem Lorem",
            PostDate = DateTime.Now
        },
        new
        {
            PostId = 2,
            PostAuthor = "Grzegorz",
            TagId = 2,
            PostContent = "Kocham jak w końcu działa mi w projekcie identity.",
            PostDate = DateTime.Now
        },
        new
        {
            PostId = 3,
            PostAuthor = "Ania",
            TagId = 3,
            PostContent = "ZZZZZ",
            PostDate = DateTime.Now
        },
        new
        {
            PostId = 4,
            PostAuthor = "Kasia",
            TagId = 4,
            PostContent = "Tragiczna dziś podoga!",
            PostDate = DateTime.Now,
        },
        new
        {
            PostId = 5,
            PostAuthor = "Alex",
            TagId = 5,
            PostContent = "Kocham Kraków.",
            PostDate = DateTime.Now,
        },
        new
        {
            PostId = 6,
            PostAuthor = "Michał",
            TagId = 1,
            PostContent = "Nowe odkrycia archeologiczne na Bliskim Wschodzie.",
            PostDate = DateTime.Now.AddDays(-1),
        },
        new
        {
            PostId = 7,
            PostAuthor = "Karolina",
            TagId = 2,
            PostContent = "Najnowsze trendy w świecie mody.",
            PostDate = DateTime.Now.AddDays(-2),
        },
        new
        {
            PostId = 8,
            PostAuthor = "Piotrek",
            TagId = 3,
            PostContent = "Odkryto nowe gatunki roślin w dżungli Amazonii.",
            PostDate = DateTime.Now.AddDays(-3),
        },
        new
        {
            PostId = 9,
            PostAuthor = "Magda",
            TagId = 4,
            PostContent = "Porównanie aparatów fotograficznych: Canon vs Nikon.",
            PostDate = DateTime.Now.AddDays(-4),
        },
        new
        {
            PostId = 10,
            PostAuthor = "Bartek",
            TagId = 5,
            PostContent = "Przyszłość sztucznej inteligencji.",
            PostDate = DateTime.Now.AddDays(-5),
        },
        new
        {
            PostId = 11,
            PostAuthor = "Monika",
            TagId = 1,
            PostContent = "Rekordy Guinnessa w sporcie.",
            PostDate = DateTime.Now.AddDays(-6),
        },
        new
        {
            PostId = 12,
            PostAuthor = "Tomasz",
            TagId = 2,
            PostContent = "Historia rozwoju technologii komputerowej.",
            PostDate = DateTime.Now.AddDays(-7),
        },
        new
        {
            PostId = 13,
            PostAuthor = "Ola",
            TagId = 3,
            PostContent = "Badania nad życiem pozaziemskim.",
            PostDate = DateTime.Now.AddDays(-8),
        },
        new
        {
            PostId = 14,
            PostAuthor = "Łukasz",
            TagId = 4,
            PostContent = "Nowości na rynku samochodowym.",
            PostDate = DateTime.Now.AddDays(-9),
        },
        new
        {
            PostId = 15,
            PostAuthor = "Natalia",
            TagId = 5,
            PostContent = "Kulinarne podróże po świecie.",
            PostDate = DateTime.Now.AddDays(-10),
        }
    );

            }
        }
}
