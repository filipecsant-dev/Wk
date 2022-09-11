using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Domain.Interfaces;
using Wk.Domain.Models;
using Wk.Domain.Services;
using Wk.Infrastructure.Context;
using Wk.Infrastructure.Repository;

namespace Wk.Application.DI
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUOW), typeof(UOW));


            services.AddScoped(typeof(IBaseRepository<Categorias>), typeof(CategoriasRepository));
            services.AddScoped(typeof(CategoriasService));
            services.AddScoped(typeof(IBaseRepository<Produtos>), typeof(ProdutosRepository));
            services.AddScoped(typeof(ProdutosService));
        }
    }
}
