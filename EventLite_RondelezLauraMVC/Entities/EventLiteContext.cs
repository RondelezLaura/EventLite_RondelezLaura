using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventLite_RondelezLauraMVC.Entities
{
    public partial class EventLiteContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Show> Show { get; set; }
        public virtual DbSet<ShowType> ShowType { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=KEZZIES-LAPTOP\SQLEXPRESS;Initial Catalog=EventLite;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.End).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Start).HasColumnType("date");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_124");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("FK_117");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.Performer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Show)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_200");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Show)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_188");
            });

            modelBuilder.Entity<ShowType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.VisitorId).HasColumnName("VisitorID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_222");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.VisitorId)
                    .HasConstraintName("FK_192");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
