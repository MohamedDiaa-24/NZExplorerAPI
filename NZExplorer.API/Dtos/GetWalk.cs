using NZExplorer.API.BaseEntity;
using NZExplorer.API.Models;

namespace NZExplorer.API.Dtos
{
    public class GetWalk : WalkBase
    {
        public Guid Id { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
