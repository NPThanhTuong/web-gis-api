namespace WebApiGIS.Dtos.Request
{
    public class UpdateRoomReq
    {
        public int? Price { get; set; }
        public int? Capability { get; set; }
        public bool? IsMezzanine { get; set; }
        public bool? IsAvailable { get; set; }
        public string? Description { get; set; }
        public string? Geom { get; set; }
        public int? MotelId { get; set; }
    }
}
