using Microsoft.EntityFrameworkCore;
using NZExplorer.API.Data;
using NZExplorer.API.Models;
using NZExplorer.API.Repositories.interfaces;

namespace NZExplorer.API.Repositories.implementation
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly AppDBContext _dBContext;

        public WalkDifficultyRepository(AppDBContext appDBContext)
        {
            _dBContext = appDBContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();

            await _dBContext.WalkDifficulty.AddAsync(walkDifficulty);
            await _dBContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty?> DeleteAsync(Guid id)
        {
            var WalkDiffculty = await _dBContext.WalkDifficulty.FindAsync(id);

            if (WalkDiffculty is not null)
            {
                _dBContext.WalkDifficulty.Remove(WalkDiffculty);
                await _dBContext.SaveChangesAsync();
                return WalkDiffculty;
            }
            return null;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await _dBContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty?> GetByIdAsync(Guid id)
        {
            return await _dBContext.WalkDifficulty.FindAsync(id);
        }

        public async Task<WalkDifficulty?> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDiffculty = await _dBContext.WalkDifficulty.FindAsync(id);

            if (walkDifficulty is not null)
            {
                existingWalkDiffculty.Code = walkDifficulty.Code;
                await _dBContext.SaveChangesAsync();
                return existingWalkDiffculty;
            }
            return null;

        }
    }
}
