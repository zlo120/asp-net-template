using Core.Models;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(string connectionString) : base(GetOptions(connectionString)) { }

        public static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ecommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // For using localDb
            //optionsBuilder.UseSqlServer("conn string");
            // also optional to add this to make the migrations assembly to "ASP NET template"
            //, b => b.MigrationsAssembly("ASP NET Template");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasColumnName("id")
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithOne(p => p.User);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Stores)
                .WithMany(s => s.Users)
                .UsingEntity(j => j.ToTable("StoreUsers").HasData(new[]
                {
                    new { UsersId = 1, StoresId = 1 },

                    new { UsersId = 2, StoresId = 2 },

                    new { UsersId = 3, StoresId = 1 },

                    new { UsersId = 4, StoresId = 2 },
                    new { UsersId = 4, StoresId = 3 },

                    new { UsersId = 5, StoresId = 2 },
                    new { UsersId = 5, StoresId = 3 },

                    new { UsersId = 6, StoresId = 1 },
                    new { UsersId = 6, StoresId = 2 },
                    new { UsersId = 6, StoresId = 3 },

                    new { UsersId = 7, StoresId = 2 },
                }));

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Store)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.StoreId);

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Harry",
                    LastName = "Potter",
                    Email = "magic@hogwarts.com"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Harry",
                    LastName = "Styles",
                    Email = "magic@onedirection.com"
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Tom",
                    LastName = "Riddle",
                    Email = "slytherin@hogwarts.com"
                },
                new User()
                {
                    Id = 4,
                    FirstName = "Tom",
                    LastName = "Holland",
                    Email = "spiderman@starkindustries.com"
                },
                new User()
                {
                    Id = 5,
                    FirstName = "Tom",
                    LastName = "Hardy",
                    Email = "Bane@Batman.com"
                },
                new User()
                {
                    Id = 6,
                    FirstName = "Tom",
                    LastName = "Hiddleston",
                    Email = "Loki@ThorSucks.com"
                },
                new User()
                {
                    Id = 7,
                    FirstName = "Tom",
                    LastName = "Hanks",
                    Email = "forest@gump.com"
                }
            );

            byte[] salt;

            modelBuilder.Entity<Security>().HasData(
                new Security()
                {
                    Id = 1,
                    UserId = 1,
                    HashedPassword = SecurityService.HashPassword("pwd", out salt),
                    Salt = Convert.ToHexString(salt)
                },
                new Security()
                {
                    Id = 2,
                    UserId = 2,
                    HashedPassword = SecurityService.HashPassword("pwd", out salt),
                    Salt = Convert.ToHexString(salt)
                },
                new Security()
                {
                    Id = 3,
                    UserId = 3,
                    HashedPassword = SecurityService.HashPassword("pwd", out salt),
                    Salt = Convert.ToHexString(salt)
                },
                new Security()
                {
                    Id = 4,
                    UserId = 4,
                    HashedPassword = SecurityService.HashPassword("pwd", out salt),
                    Salt = Convert.ToHexString(salt)
                },
                new Security()
                {
                    Id = 5,
                    UserId = 5,
                    HashedPassword = SecurityService.HashPassword("pwd", out salt),
                    Salt = Convert.ToHexString(salt)
                },
                new Security()
                {
                    Id = 6,
                    UserId = 6,
                    HashedPassword = SecurityService.HashPassword("pwd", out salt),
                    Salt = Convert.ToHexString(salt)
                },
                new Security()
                {
                    Id = 7,
                    UserId = 7,
                    HashedPassword = SecurityService.HashPassword("pwd", out salt),
                    Salt = Convert.ToHexString(salt)
                }
            );

            modelBuilder.Entity<Store>().HasData(
                new Store()
                {
                    Id = 1,
                    Name = "Magical Artifacts"
                },
                new Store()
                {
                    Id = 2,
                    Name = "Authentic Actors Props"
                },
                new Store()
                {
                    Id = 3,
                    Name = "Comic Book Items"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Harry Potter's Wand",
                    Price = 105.50f,
                    Description = "You ever wanted to use Harry Potter's wand, this is authentic af.",
                    StoreId = 1,
                    UserId = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "Bane's Mask",
                    Price = 575.0f,
                    Description = "You can breath in it surprisingly well.",
                    StoreId = 2,
                    UserId = 5
                },
                new Product()
                {
                    Id = 3,
                    Name = "Loki's Scepter",
                    Price = 1500.0f,
                    Description = "Rule Asgard with this powerful item.",
                    StoreId = 1,
                    UserId = 6
                },
                new Product()
                {
                    Id = 4,
                    Name = "Mr Starks Arc Reactor",
                    Price = 10750.0f,
                    Description = "Rule Asgard with this powerful item.",
                    StoreId = 3,
                    UserId = 4
                }
            );
        }
    }
}