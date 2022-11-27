using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientXML.Repositories
{
    public interface IRepository<EntityType, KeyType>: IDisposable where EntityType : class
    {
        Task<EntityType> GetAsync(KeyType id);
        Task<List<EntityType>> GetAllAsync();
        Task CreateAsync(EntityType item);
        Task CreateRangeAsync(IEnumerable<EntityType> items);
        Task UpdateAsync(EntityType item);
        Task UpdateRangeAsync(IEnumerable<EntityType> items);
        Task DeleteAsync(KeyType id);
        Task DeleteRangeAsync(IEnumerable<KeyType> ids);
    }
}
