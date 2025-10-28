using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pamonharia.Application.Mappings;
using Pamonharia.Application.Services.Implementations;
using Pamonharia.Application.Services.Interfaces;
using Pamonharia.Domain.Interfaces;
using Pamonharia.Infrastructure.Data.Context;
using Pamonharia.Infrastructure.Data.Repositories;

namespace Pamonharia.Infrastructure.IoC
{
    // Esta classe (Factory) centraliza o registro da Injeção de Dependência
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Configuração do EF Core e SQL Server
            services.AddDbContext<PamonhariaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // 2. Registro do AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // 3. Registro dos Serviços de Aplicação
            services.AddScoped<IPamonhaAppService, PamonhaAppService>();

            // 4. Registro dos Repositórios (Infraestrutura)
            services.AddScoped<IPamonhaRepository, PamonhaRepository>();

            return services;
        }
    }
}