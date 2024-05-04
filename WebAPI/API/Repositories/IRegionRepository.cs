using API.Models.Domain;

namespace API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid id);
        Task<Region> AddAsycn(Region region);
        Task<Region> DeleteAsycn(Guid id);
        Task<Region> UpdateAsycn(Guid id, Region region);
    }
}