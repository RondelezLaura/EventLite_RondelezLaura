//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace EventLite_RondelezLauraAPI.Entities
//{
//    public partial class EventLiteContext : DbContext
//    {
//        public virtual DbSet<Event> Event { get; set; }
//        public virtual DbSet<Subscription> Subscription { get; set; }
//        public virtual DbSet<Visitor> Visitor { get; set; }
//        public virtual DbSet<Show> Show { get; set; }
//        public virtual DbSet<ShowType> Showtype { get; set; }
//        public virtual DbSet<Category> Category { get; set; }
//        public virtual DbSet<ShowType> Venue { get; set; }

//        public EventLiteContext(DbContextOptions<EventLiteContext> options) : base(options)
//        {

//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Event>(entity =>
//            {
//                entity.HasIndex(e => e.Id).HasName("Id");
//                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
//                entity.Property(e => e.Description).IsRequired().HasMaxLength(250).IsUnicode(false);
//                entity.Property(e => e.VenueId).IsUnicode(false);
//                entity.Property(e => e.CategoryId).IsUnicode(false);
//                entity.Property(e => e.Start).IsRequired().IsUnicode(false).HasColumnType("date");
//                entity.Property(e => e.End).IsRequired().IsUnicode(false).HasColumnType("date");
//                entity.Property(e => e.Price).IsRequired().IsUnicode(false).HasColumnType("decimal(18, 0)");
//            });

//            modelBuilder.Entity<Subscription>(entity =>
//            {
//                entity.HasIndex(e => e.Id).HasName("Id");
//                entity.Property(e => e.VisitorId).IsRequired();
//                entity.Property(e => e.EventId).IsRequired();

//                //entity.HasOne(s => s.Visitor)
//                //    .WithMany(v => v.Id)
//                //    .HasForeignKey(s => s.VisitorId);
//                //entity.HasOne(s => s.Event)
//                //    .WithMany(e => e.Id)
//                //    .HasForeignKey(s => s.EventId);
//            });

//            modelBuilder.Entity<Visitor>(entity =>
//            {
//                entity.HasIndex(e => e.Id).HasName("Id");
//                entity.Property(e => e.Firstname).IsRequired().HasMaxLength(30);
//                entity.Property(e => e.Lastname).IsRequired().HasMaxLength(30);
//            });

//            modelBuilder.Entity<Show>(entity =>
//            {
//                entity.HasIndex(e => e.Id).HasName("Id");
//                entity.Property(e => e.Title).IsRequired().HasMaxLength(50);
//                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
//                entity.Property(e => e.Start).IsRequired().HasColumnType("datetime");
//                entity.Property(e => e.End).IsRequired().HasColumnType("datetime");
//                entity.Property(e => e.TypeId);
//                entity.Property(e => e.EventId);
//                entity.Property(e => e.Performer).IsRequired();
//            });

//            modelBuilder.Entity<ShowType>(entity =>
//            {
//                entity.HasIndex(e => e.Id).HasName("Id");
//                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
//                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
//                entity.Property(e => e.Seats).IsRequired().HasColumnType("smallint");
//            });

//            modelBuilder.Entity<Category>(entity =>
//            {
//                entity.HasIndex(e => e.Id).HasName("Id");
//                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
//                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
//            });

//            modelBuilder.Entity<Venue>(entity =>
//            {
//                entity.HasIndex(e => e.Id).HasName("Id");
//                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
//                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
//            });
//        }
//    }
//}
