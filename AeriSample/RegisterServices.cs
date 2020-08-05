using AeriSample.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AeriSample
{
    public static class RegisterServices
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<ProductService>();
            services.AddTransient<ProductService>();

        }
    }
}
