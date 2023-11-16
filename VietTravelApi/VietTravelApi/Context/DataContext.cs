using Microsoft.EntityFrameworkCore;
using VietTravelApi.Models;

namespace VietTravelApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<City> City { get; set; }
        public DbSet<Evaluate> Evaluate { get; set; }
        public DbSet<EvaluateStar> EvaluateStar { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Schedule > Schedule { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TimePackage> TimePackage { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<TourGuide> TourGuide { get; set; }
        public DbSet<TourPackage> TourPackage { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }

        public DbSet<Event> Event { get; set; }
        public DbSet<HistoryChangeStatusTicket> HistoryChangeStatusTicket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<City>()
                .HasMany(p => p.Tours)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<City>()
                .HasMany(p => p.Hotels)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<City>()
                .HasMany(p => p.Restaurants)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<City>()
                .HasMany(p => p.TourGuides)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<City>()
                .HasMany(p => p.Evaluates)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<City>()
                .HasMany(p => p.EvaluateStars)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tour>()
                .HasMany(p => p.Events)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.Schedules)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.TourPackages)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.Evaluates)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tour>()
                .HasMany(p => p.EvaluateStars)
                .WithOne(a => a.Tour)
                .HasForeignKey(a => a.TourId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hotel>()
                .HasMany(p => p.Evaluates)
                .WithOne(a => a.Hotel)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Hotel>()
                .HasMany(p => p.EvaluateStars)
                .WithOne(a => a.Hotel)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Hotel>()
                .HasMany(p => p.TourPackages)
                .WithOne(a => a.Hotel)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Restaurant>()
                .HasMany(p => p.Evaluates)
                .WithOne(a => a.Restaurant)
                .HasForeignKey(a => a.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Restaurant>()
                .HasMany(p => p.EvaluateStars)
                .WithOne(a => a.Restaurant)
                .HasForeignKey(a => a.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Restaurant>()
                .HasMany(p => p.TourPackages)
                .WithOne(a => a.Restaurant)
                .HasForeignKey(a => a.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TourPackage>()
                .HasMany(p => p.Tickets)
                .WithOne(a => a.TourPackage)
                .HasForeignKey(a => a.TourPackageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimePackage>()
                .HasMany(p => p.TourPackages)
                .WithOne(a => a.TimePackage)
                .HasForeignKey(a => a.TimePackageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Evaluates)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(p => p.EvaluateStars)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Tickets)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
