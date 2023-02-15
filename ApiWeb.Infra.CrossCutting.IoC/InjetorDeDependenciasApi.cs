using ApiBase.Infra.Data;
using ApiBase.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiWeb.Infra.Data.Context;
using ApiBase.Domain.Interfaces.Repositories;
using ApiWeb.Infra.Data.Repository;

namespace ApiBase.Infra.CrossCutting.IoC;

public static class InjetorDeDependenciasApi
{
    public static IServiceCollection InjetarDependenciasApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //services.AddAutoMapper(typeof(AutoMapperConfig));

        return services
            .InjetarAppServices()
            .InjetarRepositories()
            .InjetarDbContext(configuration);
    }

    private static IServiceCollection InjetarAppServices(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection InjetarRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPessoaRepository, PessoaRepository>();
        return services;
    }

    private static IServiceCollection InjetarDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiWebDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}
