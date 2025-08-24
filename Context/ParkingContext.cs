using carParkingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace carParkingApi.Context
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {

        }

        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ParkingAssignment> ParkingAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpot>().Property(p => p.Status).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
