using Common.Repository.EfCore.Extensions;
using Common.Repository.EfCore.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MikheilBerishvili.Final.Persistence.Database;

namespace MikheilBerishvili.Final.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEfCoreDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MikheilBerishvili.Final") ?? "",
                    x => x.UseNetTopologySuite());
            },
            repositoryOptions: options => { options.SaveChangeStrategy = SaveChangeStrategy.PerOperation; });

        services.AddUnitOfWork();

        return services;
    }
}