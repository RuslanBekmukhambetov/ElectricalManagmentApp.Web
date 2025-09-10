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
        /*
        protected override void OnModeCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);
        }*/
    }
}
