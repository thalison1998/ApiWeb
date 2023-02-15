
using ApiWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWeb.Infra.Data.Mapping;

public abstract class BaseMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Base
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
  
        // Exemplo de configuração de uma prop de sombra, como usarei apenas para visualização.
        builder.Property<int>("Codigo").ValueGeneratedOnAdd();
    }
}

