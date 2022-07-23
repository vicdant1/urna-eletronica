using Application.IServices;
using Application.Mapping;
using Application.Services;
using Domain.IRepository;
using Infra.Data.DataContext;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString("defaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            ));

            services.AddScoped<ICandidatoService, CandidatoService>();
            services.AddScoped<IVotoService, VotoService>();

            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<IVotoRepository, VotoRepository>();

            services.AddAutoMapper(typeof(UrnaMappingProfile));

            return services;
        }
    }
}