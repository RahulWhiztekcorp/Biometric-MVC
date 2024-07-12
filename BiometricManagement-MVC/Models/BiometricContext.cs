using Microsoft.EntityFrameworkCore;

namespace BiometricManagement_MVC.Models
{
    public class BiometricContext : DbContext
    {
        public BiometricContext(DbContextOptions<BiometricContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<DeviceIn> DevicesIn { get; set; }
        public DbSet<DeviceOut> DevicesOut { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.DevicesIn)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.DevicesOut)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);
        }
    }
}
