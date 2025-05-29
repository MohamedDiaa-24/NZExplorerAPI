namespace NZExplorer.API.BaseEntity
{
    public class RegionBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        public string? ImageURL { get; set; }
    }
}
