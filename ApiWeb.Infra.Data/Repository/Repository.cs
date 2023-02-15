using Microsoft.EntityFrameworkCore;
using ApiBase.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ApiWeb.Infra.Data.Context;

namespace ApiBase.Infra.Data.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected ApiWebDbContext Db;
    protected DbSet<TEntity> DbSet;

    public Repository(ApiWebDbContext context)
    {
        Db = context;
        DbSet = Db.Set<TEntity>();
    }

    public virtual TEntity Adicionar(TEntity obj)
    {
        EntityEntry<TEntity> objreturn = DbSet.Add(obj);
        return objreturn.Entity;
    }

    public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual void Atualizar(TEntity obj)
    {
        DbSet.Update(obj);
    }

    public virtual void Remover(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    protected virtual IQueryable<TEntity> Obter()
    {
        return DbSet;
    }

    protected virtual IQueryable<TEntity> ObterAsNoTracking()
    {
        return DbSet.AsNoTrackingWithIdentityResolution();
    }

    public void Dispose()
    {
        Db.Dispose();
        GC.SuppressFinalize(this);
    }
}

