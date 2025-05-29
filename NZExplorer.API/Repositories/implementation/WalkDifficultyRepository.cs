using NZExplorer.API.Models;
using NZExplorer.API.Repositories.interfaces;

namespace NZExplorer.API.Repositories.implementation
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        public Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficulty?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            throw new NotImplementedException();
        }
    }
}
