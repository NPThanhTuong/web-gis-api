using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace WebApiGIS.Utils
{
    public static class GeometryHelper
    {
        public static bool IsValidGeoJson(string geoJson)
        {
            try
            {
                var reader = new GeoJsonReader();
                var geometry = reader.Read<Geometry>(geoJson);

                // Additional geometry validation if needed
                return geometry != null && geometry.IsValid;
            }
            catch (Exception)
            {
                // Invalid GeoJSON format or other
                return false;
            }
        }

        public static Geometry ConvertGeoJsonToGeometry(string geoJson)
        {
            var reader = new GeoJsonReader();
            return reader.Read<Geometry>(geoJson);
        }
    }
}
