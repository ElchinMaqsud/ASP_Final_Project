using Asp_Final.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.Db
{
    public class Final_Db : IdentityDbContext<ApplicationUser>
    {
        public Final_Db(DbContextOptions<Final_Db> options) : base(options)
        {
        }
        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<SpeedBox> SpeedBoxes { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<CarImages> CarImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Mark>().HasData
                (
                     new Mark { Id = 8, Name = "Bmw" },
                     new Mark { Id = 9, Name = "Mercedes" },
                     new Mark { Id = 10, Name = "Audi" },
                     new Mark { Id = 11, Name = "Kia" },
                     new Mark { Id = 12, Name = "Hyundai" },
                     new Mark { Id = 13, Name = "Chevrolet" },
                     new Mark { Id = 14, Name = "Lada(VAZ)" }
                     
                );
            builder.Entity<Model>().HasData(
               new Model { Id = 26, Name = "530", MarkId = 8 },
               new Model { Id = 27, Name = "X5", MarkId = 8 },
               new Model { Id = 28, Name = "M6", MarkId = 8 },
               new Model { Id = 29, Name = "C-220", MarkId = 9 },
               new Model { Id = 30, Name = "E-220", MarkId = 9 },
               new Model { Id = 31, Name = "XD-250", MarkId = 9 },
               new Model { Id = 32, Name = "A4", MarkId = 10 },
               new Model { Id = 33, Name = "A6", MarkId = 10 },
               new Model { Id = 34, Name = "Q7", MarkId = 10 },
               new Model { Id = 35, Name = "Cerato", MarkId = 11 },
               new Model { Id = 36, Name = "Sorento", MarkId = 11 },
               new Model { Id = 37, Name = "Optima", MarkId = 11 },
               new Model { Id = 38, Name = "Elantra", MarkId = 12 },
               new Model { Id = 39, Name = "Santa-fe", MarkId = 12 },
               new Model { Id = 40, Name = "Accent", MarkId = 12 },
               new Model { Id = 41, Name = "Aveo", MarkId = 13 },
               new Model { Id = 42, Name = "Captiva", MarkId = 13 },
               new Model { Id = 43, Name = "Cruze", MarkId = 13 },
               new Model { Id = 45, Name = "2107", MarkId = 14 },
               new Model { Id = 46, Name = "Niva", MarkId = 14 },
               new Model { Id = 47, Name = "Prioa", MarkId = 14 }
               );
               builder.Entity<Color>().HasData
              (
                   new Color { Id = 9, Name = "Black" },
                   new Color { Id = 10, Name = "White" },
                   new Color { Id = 11, Name = "Yellow" },
                   new Color { Id = 12, Name = "Gray" },
                   new Color { Id = 13, Name = "Brown" },
                   new Color { Id = 14, Name = "Red" },
                   new Color { Id = 15, Name = "Blue" },
                   new Color { Id = 16, Name = "Green" }

              );
            builder.Entity<Fuel>().HasData
            (
                 new Fuel { Id = 4, Name = "Gasoline" },
                 new Fuel { Id = 5, Name = "Diesel" },
                 new Fuel { Id = 6, Name = "Hybrid" }
            );
            builder.Entity<SpeedBox>().HasData
           (
                new SpeedBox { Id = 3, Name = "Automatic" },
                new SpeedBox { Id = 4, Name = "Mechanic" }
           );
            builder.Entity<Ban>().HasData
         (
              new Ban { Id = 4, Name = "Hatchback" },
              new Ban { Id = 5, Name = "Sedan" },
              new Ban { Id = 6, Name = "Van" }
         );
            builder.Entity<City>().HasData
      (
           new City { Id = 7, Name = "Baku" },
           new City { Id = 8, Name = "Sumgayit" },
           new City { Id = 9, Name = "Barda" },
           new City { Id = 10, Name = "Gence" },
           new City { Id = 11, Name = "Semkir" },
           new City { Id = 12, Name = "Naxcivan" }
           
      );
            builder.Entity<Automobile>().HasData
            (
                 new Automobile { Name="Kia Optima", Id = 5, PhotoUrl = "Kia.jpg", Price = 20000, ModelId = 37, GraduationYear = new DateTime(2013, 08, 06), EnginePower = 200,EngineVolume=2400, Mileage = 25000, ColorId = 9, FuelId = 4, SpeedBoxId = 3,BanId=5,CityId=8,IsNew=false,}
            );
            builder.Entity<CarImages>().HasData
          (
               new CarImages { Id=20,AutomobileId=5,CarPhotoUrl="Kia1.jpg" },
                new CarImages {Id=21, AutomobileId = 5, CarPhotoUrl = "Kia2.jpg" }
          );

            builder.Entity<News>().HasData
        (
             new News { Id = 15, Title = "New Kia Soul 2019", PhotoUrl="KiaSoul.jpg",Info="New Kia Soul Full Edition 2019" },
              new News { Id = 16, Title = "New Ferrari SpeedCar 2019", PhotoUrl = "Ferrari.jpg", Info = "New Ferrari  Full Sport Edition 2019" }
        );
        }
         
            

    }

}

