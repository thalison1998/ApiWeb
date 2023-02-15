
using ApiWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiWeb.Infra.Data.Context;

public class ApiWebDbContext : DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

