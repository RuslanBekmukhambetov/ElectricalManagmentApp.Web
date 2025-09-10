namespace ElectricalManagmentApp.Web.Models
{
    public class ElectricityMeter : BaseEntity
    {
        public required string SerialNumber { get; set; }
        public ElectricityMeterType Type { get; set; }
        public DateTime? InstallationDate { get; set; }
        public Guid MeterPointId { get; set; }
        public MeterPoint? MeterPoint { get; set; }

        public enum ElectricityMeterType
        {
            Type1,
            Type2,
            Type3
        }
    }
}
