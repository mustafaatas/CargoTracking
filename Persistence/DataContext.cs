using Domain;
using Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<IdentityRole> ApplicationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<IEFSoftDeleteEntity>().HasQueryFilter(k => !k.IsDeleted);
            builder.Entity<Cargo>().HasKey(k => k.Id);

            builder.Entity<Cargo>()
                .HasOne(k => k.Employee)
                .WithMany(k => k.CargoList)
                .HasForeignKey(k => k.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Employee>().HasKey(k => k.Id);

            builder.Entity<Employee>()
                .HasOne(k => k.Dealer)
                .WithMany(k => k.EmployeeList)
                .HasForeignKey(k => k.DealerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Dealer>()
                .HasIndex(k => k.ZIPCode).IsUnique();
        }
    }
}
