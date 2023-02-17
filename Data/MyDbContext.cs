using FoodDiary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using СorporateRideManagementSystem.Data.Entities;

namespace СorporateRideManagementSystem.Data
{
    public class MyDbContext : IdentityDbContext<Employee>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> User { get; set; }

        public DbSet<Ride> Ride { get; set; }
        public DbSet<RideReport> RideReport { get; set; }
        public DbSet<SystemSettingForEmployee> SystemSetting { get; set; }

    }
}
