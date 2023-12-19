using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;

namespace DataAccess
{
    public class RepositoryContext : IdentityDbContext<CustomUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options): base(options)
        {
        }
        public DbSet<Phone> Phones
        {
            get; set;
        }
        public DbSet<Brand> Brands
        {
            get; set;
        }

        public DbSet<Order> Orders
        {
            get; set;
        }
        public DbSet<PhoneRating> PhoneRatings
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
