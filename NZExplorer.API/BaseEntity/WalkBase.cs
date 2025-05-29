namespace NZExplorer.API.BaseEntity
{
    public class WalkBase
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public string? ImageURL { get; set; }

    }
}
