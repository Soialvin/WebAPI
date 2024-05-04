using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _Context;
        public RegionRepository(NZWalksDbContext Context)
        {
            _Context = Context;
        }

        public async Task<Region> AddAsycn(Region region)
        {
            region.Id = Guid.NewGuid();
            await _Context.Regions.AddAsync(region);
            await _Context.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsycn(Guid id)
        {
            var region = await _Context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }

            _Context.Regions.Remove(region);
            await _Context.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _Context.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await _Context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsycn(Guid id, Region region)
        {
            var existingRegion = await _Context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Area = region.Area;
            existingRegion.Name = region.Name;
            existingRegion.Lat = region.Lat;
            existingRegion.Population = region.Population;
            existingRegion.Long = region.Long;
            await _Context.SaveChangesAsync();

            return existingRegion;
        }
    }
}
