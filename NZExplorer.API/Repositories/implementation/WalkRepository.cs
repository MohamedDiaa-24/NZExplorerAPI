using Microsoft.EntityFrameworkCore;
using NZExplorer.API.Data;
using NZExplorer.API.Models;
using NZExplorer.API.Repositories.interfaces;

namespace NZExplorer.API.Repositories.implementation
{
    public class WalkRepository : IWalkRepository
    {

        private readonly AppDBContext _dbContext;

        public WalkRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();

            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await _dbContext.Walks.FindAsync(id);
            if (walk is not null)
            {
                _dbContext.Walks.Remove(walk);
                await _dbContext.SaveChangesAsync();
                return walk;
            }

            return null;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _dbContext.Walks.
                Include(x => x.Region)
                .Include(x => x.WalkDifficulty).
                ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walks.
                Include(x => x.Region).
                Include(x => x.WalkDifficulty).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _dbContext.Walks.FindAsync(id);

            if (existingWalk is not null)
            {
                existingWalk.Name = walk.Name;
                existingWalk.Length = walk.Length;
                existingWalk.Description = walk.Description;
                existingWalk.RegionId = walk.RegionId;
                existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
                existingWalk.ImageURL = walk.ImageURL;
                existingWalk.Region = walk.Region;
                existingWalk.WalkDifficulty = walk.WalkDifficulty;
                await _dbContext.SaveChangesAsync();
                return existingWalk;
            }
            return null;
        }
    }
}
