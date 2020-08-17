using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RetailItemUpdater.DI;
using RetailItemUpdater.Domain.DAL;
using RetailItemUpdater.Domain.DAL.Models;
using RetailItemUpdater.Events;
using RetailOffers.MessagingUtilities;
using RetailOffers.MessagingUtilities.RabbitMq;

namespace RetailItemUpdater
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<RetailDealsDatabaseSettings>(Configuration.GetSection(nameof(RetailDealsDatabaseSettings)));
            services.AddSingleton<IRetailDealsDatabaseSettings>(sp => sp.GetRequiredService<IOptions<RetailDealsDatabaseSettings>>().Value);

            services.AddSingleton<MongoDbContext>();
            services.InjectServices();
            services.SubscribeToQueues();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
