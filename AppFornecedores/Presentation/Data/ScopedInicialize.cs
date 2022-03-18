using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Data
{
    public static class ScopedInicialize
    {
        public static void InicializeScope(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<FornecedorBll>(serviceProvider =>
            {
                return new FornecedorBll();
            });



        }
    }
}
