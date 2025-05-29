﻿using NZExplorer.API.Models;

namespace NZExplorer.API.Repositories.interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> AddAsync(Region region);

        Task<Region?> DeleteAsync(Guid id);

        Task<Region> UpdateAsync(Guid id, Region region);
    }
}
