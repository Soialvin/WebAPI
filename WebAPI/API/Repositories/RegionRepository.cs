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
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _Context.Regions.ToListAsync();
        }
    }
}
