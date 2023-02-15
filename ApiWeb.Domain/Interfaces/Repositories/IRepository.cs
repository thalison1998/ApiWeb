
namespace ApiBase.Domain.Interfaces.Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    TEntity Adicionar(TEntity obj);
    Task<TEntity> ObterPorIdAsync(Guid id);
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    void Atualizar(TEntity obj);
    void Remover(TEntity entity);
}


