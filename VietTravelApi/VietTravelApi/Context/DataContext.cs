using Microsoft.EntityFrameworkCore;
using VietTravelApi.Models;

namespace VietTravelApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        DbSet<City> City { get; set; }
        DbSet<Evaluate> Evaluate { get; set; }
        DbSet<Hotel> Hotel { get; set; }
        DbSet<Schedule > Schedule { get; set; }
        DbSet<Ticket> Ticket { get; set; }
        DbSet<TicketDetail> TicketDetail { get; set; }
        DbSet<Tour> Tour { get; set; }
        DbSet<Tour_TourPackage> Tour_TourPackage { get; set; }
        DbSet<TourGuide> TourGuide { get; set; }
        DbSet<TourPackage > TourPackage { get; set; }
        DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(p => p.Tours)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.Evaluates)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Evaluates)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.Tickets)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.TourGuides)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.Hotels)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.Tour_TourPackages)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId);
            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.TicketDetail)
                .WithOne(a => a.Ticket)
                .HasForeignKey<Ticket>(a => a.TicketDetailId);
            modelBuilder.Entity<TicketDetail>()
                .HasMany(p => p.TourGuides)
                .WithOne(a => a.TicketDetail)
                .HasForeignKey(a => a.TicketDetailId);
            modelBuilder.Entity<TourPackage>()
                .HasMany(p => p.Tour_TourPackages)
                .WithOne(a => a.TourPackage)
                .HasForeignKey(a => a.TourPackageId);
            modelBuilder.Entity<TourPackage>()
                .HasMany(p => p.Tour_TourPackages)
                .WithOne(a => a.TourPackage)
                .HasForeignKey(a => a.TourPackageId);
            modelBuilder.Entity<TourPackage>()
                .HasMany(p => p.TicketDetails)
                .WithOne(a => a.TourPackage)
                .HasForeignKey(a => a.TourPackageId);
            modelBuilder.Entity<TicketDetail>()
                .HasMany(p => p.Schedules)
                .WithOne(a => a.TicketDetail)
                .HasForeignKey(a => a.TicketDetailId);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Tickets)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
        }
    }
}
