using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventLite_RondelezLauraMVC.Models;
using EventLite_RondelezLauraMVC.Entities;

namespace EventLite_RondelezLauraMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.Id).HasName("Id");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(250).IsUnicode(false);
                entity.Property(e => e.VenueId).IsUnicode(false);
                entity.Property(e => e.CategoryId).IsUnicode(false);
                entity.Property(e => e.Start).IsRequired().IsUnicode(false).HasColumnType("date");
                entity.Property(e => e.End).IsRequired().IsUnicode(false).HasColumnType("date");
                entity.Property(e => e.Price).IsRequired().IsUnicode(false).HasColumnType("decimal(18, 0)");
            });
        }
    }
}
