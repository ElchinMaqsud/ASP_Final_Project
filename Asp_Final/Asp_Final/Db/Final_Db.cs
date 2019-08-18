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

    }

}

