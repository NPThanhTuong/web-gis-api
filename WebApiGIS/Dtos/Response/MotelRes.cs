namespace WebApiGIS.Dtos.Response
{
    public class MotelRes
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Geom { get; set; } = string.Empty;

        public List<MotelImageRes> Images { get; set; } = [];
    }
}
