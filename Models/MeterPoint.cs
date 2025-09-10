namespace ElectricalManagmentApp.Web.Models
{
    public class MeterPoint : BaseEntity
    {
        public string Caption { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double CurrentTransoformationRatio { get; set; } = 1.0;
        public double VoltageTransoformationRatio { get; set; } = 1.0;
        public ElectricityMeter? ElectricityMeter { get; set; }
        public Guid ConsumerId { get; set; }
        public Consumer? Consumer { get; set; }
        public Guid ReadingsId { get; set; }
        public List<MeterReadings> Readings { get; set; } = new List<MeterReadings>();
    }
}
