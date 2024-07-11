using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data.Repositories;
using TCCLions.Infrastructure.Services;
using TCCLions.Infrastructure.Services.Interfaces;

namespace TCCLions.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomScopes(this IServiceCollection services){
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IAtaRepository), typeof(AtaRepository));
            services.AddScoped<IAtaService, AtaService>();
            services.AddScoped(typeof(IComissaoRepository), typeof(ComissaoRepository));
            services.AddScoped<IComissaoService, ComissaoService>();
            services.AddScoped(typeof(ITipoComissaoRepository), typeof(TipoComissaoRepository));
            services.AddScoped<ITipoComissaoService, TipoComissaoService>();
            services.AddScoped(typeof(ITipoDespesaRepository), typeof(TipoDespesaRepository));
            services.AddScoped<ITipoDespesaService, TipoDespesaService>();
            services.AddScoped(typeof(IMembroRepository), typeof(MembroRepository));
            services.AddScoped<IMembroService, MembroService>();
            services.AddScoped(typeof(IDespesaRepository), typeof(DespesaRepository));
            services.AddScoped<IDespesaService, DespesaService>();
            services.AddScoped(typeof(IMembroComissaoRepository), typeof(MembroComissaoRepository));
            services.AddScoped<IMembroComissaoService, MembroComissaoService>();
        }
    }
}