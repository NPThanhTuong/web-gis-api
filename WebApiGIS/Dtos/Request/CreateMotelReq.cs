namespace WebApiGIS.Dtos.Request
{
    public class CreateMotelReq
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Geom { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
