using ApiBase.Domain.Interfaces;
using ApiBase.Infra.Data.Context;

namespace ApiBase.Infra.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApiBaseDbContext _context;

    public UnitOfWork(ApiBaseDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
