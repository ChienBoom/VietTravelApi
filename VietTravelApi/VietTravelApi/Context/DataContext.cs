using Microsoft.EntityFrameworkCore;
using VietTravelApi.Models;

namespace VietTravelApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<City> City { get; set; }
        public DbSet<Evaluate> Evaluate { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Schedule > Schedule { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TimePackage> TimePackage { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<TourGuide> TourGuide { get; set; }
        public DbSet<TourPackage> TourPackage { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<City>()
            //    .HasMany(p => p.Tours)
            //    .WithOne(a => a.City)
            //    .HasForeignKey(a => a.CityId);
            //modelBuilder.Entity<Tour>()
            //    .HasMany(p => p.TourPackages)
            //    .WithOne(a => a.Tour)
            //    .HasForeignKey(a => a.TourId);
            //modelBuilder.Entity<TimePackage>()
            //    .HasMany(p => p.TourPackages)
            //    .WithOne(a => a.TimePackage)
            //    .HasForeignKey(a => a.TimePackageId);
            //modelBuilder.Entity<Hotel>()
            //    .HasMany(p => p.TourPackages)
            //    .WithOne(a => a.Hotel)
            //    .HasForeignKey(a => a.HotelId);
            //modelBuilder.Entity<Ticket>()
            //    .HasOne(p => p.TourPackage)
            //    .WithOne(a => a.Ticket)
            //    .HasForeignKey<Ticket>(a => a.TourPackageId);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Tickets)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
        }
    }
}
