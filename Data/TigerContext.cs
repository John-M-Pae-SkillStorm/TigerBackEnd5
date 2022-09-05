using Microsoft.EntityFrameworkCore;
using TigerBackEnd5.Models;
using TigerBackEnd5.Models.Profiles;
using TigerBackEnd5.ProfileSeeds;

namespace TigerBackEnd5.Data
{
    public class TigerContext : DbContext
    {
        public TigerContext(DbContextOptions<TigerContext> options)
            : base(options) { }

        // Primary data sets
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Device> Devices { get; set; }

        // Support tables
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        // Reference profiles
        public DbSet<PlanProfile> PlanProfiles { get; set; }
        public DbSet<DeviceProfile> DeviceProfiles { get; set; }

        // Create seed data for profiles
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var plan in SeedPlanProfiles.AvailiblePlans)
            {
                builder.Entity<PlanProfile>()
                    .HasData(plan);
            }
            foreach (var device in SeedDeviceProfiles.AvailibleDevices)
            {
                builder.Entity<DeviceProfile>()
                    .HasData(device);
            }
        }
    }
}
