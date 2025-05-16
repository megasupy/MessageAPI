using System.Collections;

namespace api.Services;

public interface IRepository<TEntity, TId> where TEntity : class
{
    void Create(TEntity entity);
    void Delete(TId id);
    IEnumerable Get();
    TEntity Get(TId id);
    void Update(TId id, TEntity entity);
}