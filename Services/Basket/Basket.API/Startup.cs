using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.API.Domain;
using Basket.API.Infra.Repositories;
using Basket.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Basket.API
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

            services.AddControllers();

            /// uncomment to use in memory cache implementation of IDistributedCache
            /// useful during development, or for single server deployments
            services.AddDistributedMemoryCache();

            /// uncomment to use Azure Cache for Redis implementation of IDistributedCache
            /// requires creating the Resource in Azure and copying connection string settings into appsettings.json
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = Configuration.GetConnectionString("RedisConnection");
            //    options.InstanceName = "GloboTicket";
            //});

            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddHttpClient<ICatalogService, CatalogService>(c =>
                   c.BaseAddress = new Uri(Configuration["ApiConfigs:EventCatalog:Uri"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket API V1");

            });

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
