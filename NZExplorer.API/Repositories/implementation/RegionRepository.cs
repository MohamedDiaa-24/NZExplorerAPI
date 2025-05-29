using Microsoft.EntityFrameworkCore;
using NZExplorer.API.Data;
using NZExplorer.API.Models;
using NZExplorer.API.Repositories.interfaces;

namespace NZExplorer.API.Repositories.implementation
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDBContext _dbContext;

        public RegionRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await _dbContext.Regions.FindAsync(id);

            if (region is not null)
            {
                _dbContext.Regions.Remove(region);
                await _dbContext.SaveChangesAsync();
                return region;
            }

            return null;

        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {

            return await _dbContext.Regions.FindAsync(id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _dbContext.Regions.FindAsync(id);

            if (existingRegion is not null)
            {
                existingRegion.Code = region.Code;
                existingRegion.Name = region.Name;
                existingRegion.Area = region.Area;
                existingRegion.Lat = region.Lat;
                existingRegion.Long = region.Long;
                existingRegion.Population = region.Population;

                await _dbContext.SaveChangesAsync();
                return existingRegion;
            }

            return null;


        }
    }
}
