namespace ElectricalManagmentApp.Web.Models
{
    public class MeterReadings : BaseEntity
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public Guid MeterPointId { get; set; }
        public MeterPoint MeterPoint { get; set; }
    }
}
