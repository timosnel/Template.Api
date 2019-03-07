using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Name
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    // TODO: Configure authentication.
                });

            services
                .AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters(ConfigureJsonFormatters);

            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseCors(ConfigureCors)
                .UseAuthentication()
                .UseHealthChecks("/health")
                .UseSecurityHeaders()
                .UseMvc();
        }

        private void ConfigureJsonFormatters(JsonSerializerSettings settings)
        {
            settings.Converters.Add(new StringEnumConverter());
        }

        private void ConfigureCors(CorsPolicyBuilder builder)
        {
            // TODO: Configure CORS.
        }
    }
}
