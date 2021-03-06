using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntitiyFrameWork
{
    public class CarRentalContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = localhost\SQLEXPRESS01; Database = RentalProject; Trusted_Connection = True");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors {get; set;}
        public DbSet<Brand> Brands {get; set;}
        public DbSet<CarImage> CarImages {get; set;}
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
