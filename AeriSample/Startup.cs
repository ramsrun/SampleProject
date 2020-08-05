using AeriSample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using AutoMapper;
using AeriSample.Service.Model;

namespace AeriSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterAppServices();
            services.RegisterJWTAuthentication(Configuration);
            services.RegisterCORSPolicies(Configuration);
            services.AddAutoMapper();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            services.AddDbContext<AeriContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.RegisterSwagger(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.RegisterGlobalExceptionLogger();
            app.UseCors("AllowSpecificOrigins");
            app.UseSwagger(configure => configure.PostProcess = (document, _) =>
            {
                document.Schemes = new[] { SwaggerSchema.Https, SwaggerSchema.Http };
            });
            app.UseSwaggerUi3();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
