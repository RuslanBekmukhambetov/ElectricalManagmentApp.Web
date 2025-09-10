namespace ElectricalManagmentApp.Web.Models
{
    public class Consumer : BaseEntity
    {
        public string? AccountNumber { get; set; }
        public string? Caption { get; set; }
        public List<MeterPoint> MeterPoints { get; set; } = new List<MeterPoint>();
    }
}
