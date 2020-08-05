using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.SwaggerGeneration.Processors.Security;

namespace AeriSample
{
    public static partial class RegisterNFRModules
    {
        public static void RegisterJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtBearerOptions>(configuration.GetSection("Authentication:Cognito"));
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IOptions<JwtBearerOptions> authOptions = serviceProvider.GetService<IOptions<JwtBearerOptions>>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.MetadataAddress = authOptions.Value.MetadataAddress;
                options.SaveToken = authOptions.Value.SaveToken;

                options.IncludeErrorDetails = authOptions.Value.IncludeErrorDetails;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = authOptions.Value.TokenValidationParameters.ValidateAudience
                };
            });
        }



        public static void RegisterCORSPolicies(this IServiceCollection services, IConfiguration configuration)
        {
            string[] corsOrigins = configuration["AppSettings:CORS origins"].Split(',');

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins(corsOrigins).AllowAnyMethod().AllowAnyHeader();
                    });
            });
        }

        public static void RegisterSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerDocument(config =>
            {
                config.Title = "Aeri";
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("Id Token"));
                config.DocumentProcessors.Add(
                    new SecurityDefinitionAppender("Id Token", new SwaggerSecurityScheme
                    {
                        Type = SwaggerSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        Description = "Bearer *Id Token*",
                        In = SwaggerSecurityApiKeyLocation.Header
                    }));
            });
        }


        public static void RegisterGlobalExceptionLogger(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
