namespace WebApiGIS.Dtos.Request
{
    public class UpdateMotelReq
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Geom { get; set; }
        public int? UserId { get; set; }
    }
}
