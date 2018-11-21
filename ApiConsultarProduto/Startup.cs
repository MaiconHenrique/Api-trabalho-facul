using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConsultarProduto.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ApiConsultarProduto
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
            {
                policy
                .WithOrigins(_configuration["mercadoWeb"], _configuration["mercadoapp"])
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }));

            services.AddResponseCaching();
            
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddResponseCaching();

            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<ApiConsultarProdutoContext>(opts => opts.UseNpgsql(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            
            app.UseCors("CorsPolicy");
            app.UseResponseCaching();
            app.UseMvcWithDefaultRoute();
        }
    }
}
