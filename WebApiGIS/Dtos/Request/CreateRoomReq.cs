namespace WebApiGIS.Dtos.Request
{
    public class CreateRoomReq
    {
        public int Price { get; set; }
        public int Capability { get; set; }
        public bool IsMezzanine { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Geom { get; set; } = null!;
        public int MotelId { get; set; }
    }
}
