using BuildingBlocks.Core.Domain.Entities;

namespace BuildingBlocks.Core.Interfaces
{
    public interface IWriteRepository<T> where T : Entity
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<T> GetById(Guid id);
    }
}
