namespace WebApiGIS.Dtos.Response
{
    public class RoomRes
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Capability { get; set; }
        public bool IsMezzanine { get; set; }
        public bool IsAvailable { get; set; }
        public string Descripption { get; set; } = string.Empty;
        public string Geom { get; set; } = null!;
        public MotelRes Motel { get; set; }
    }
}
