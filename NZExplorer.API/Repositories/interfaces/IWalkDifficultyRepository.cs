using NZExplorer.API.Models;

namespace NZExplorer.API.Repositories.interfaces
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty?> GetByIdAsync(Guid id);
        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty?> UpdateAsync(Guid id, WalkDifficulty walkDifficulty);
        Task<WalkDifficulty?> DeleteAsync(Guid id);
    }
}
