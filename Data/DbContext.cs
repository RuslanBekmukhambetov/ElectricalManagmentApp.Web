using Microsoft.EntityFrameworkCore;
using ElectricalManagmentApp.Web.Models;

namespace ElectricalManagmentApp.Web.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        public DbSet<MeterPoint> MeterPoints { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<MeterReadings> MetersReadings { get; set; }
        
        protected void OnModeCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<MeterPoint>()
                .HasOne(mp => mp.ElectricityMeter)
                .WithOne(em => em.MeterPoint)
                .HasForeignKey<ElectricityMeter>(em => em.MeterPointId)
                .IsRequired(false);

            modelBuilder.Entity<MeterPoint>()
                .HasOne(mp => mp.Consumer)
                .WithMany(c => c.MeterPoints)
                .HasForeignKey(mp => mp.ConsumerId);

            modelBuilder.Entity<MeterReadings>()
                .HasOne(mr => mr.MeterPoint)
                .WithMany(mp => mp.Readings)
                .HasForeignKey(mr => mr.MeterPointId);
        }
    }
}
