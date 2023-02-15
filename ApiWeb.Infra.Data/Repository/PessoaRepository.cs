
using ApiBase.Domain.Interfaces.Repositories;
using ApiBase.Infra.Data.Repository;
using ApiWeb.Domain.Entidades;
using ApiWeb.Infra.Data.Context;

namespace ApiWeb.Infra.Data.Repository;

public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
{
    public PessoaRepository(ApiWebDbContext context) : base(context) { }
}

