using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.NomeDaBase;
using Domain.Interfaces.Uow;
using Havan.Persistence.ConnectionStrings;
using Infra.Data.Context;
using Infra.Data.Repositories.ItlSys;
using Infra.Data.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IConfiguration configuration, IServiceCollection services)
        {
            //AppService
            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IFornecedorAppService, FornecedorAppService>();

            //Repository
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoUnitOfWork, ProdutoUnitOfWork>();

            ////Contexto
            services.AddDbContextPool<ProdutoContext>((sp, ob) =>
            {
                var cs = sp.GetRequiredService<IConnectionStringProvider>().GetConnectionString("ProdutoAPI");
                ob.UseSqlServer(cs);
            });
        }
    }
}
