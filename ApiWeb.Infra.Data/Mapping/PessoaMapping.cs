
using ApiWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Infra.Data.Mapping;

public class PessoaMapping : BaseMapping<Pessoa>
{
    public override void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        base.Configure(builder);

        builder.ToTable("Pessoas");

        builder.Property(x => x.CPF).IsRequired();
    }
}

