using Ecommerce.Api.Search.CustomersService;
using Ecommerce.Api.Search.OrdersService;
using Ecommerce.Api.Search.ProductCategoryService;
using Ecommerce.Api.Search.ProductsService;
using Ecommerce.Api.Search.SearchService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search
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
            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<IOrdersService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductsCategoryService, ProductsCategoryService>();

            services.AddHttpClient("OrdersService", configureClient =>
            {
                configureClient.BaseAddress = new Uri(Configuration["Services:Orders"]);
            });
            services.AddHttpClient("ProductsService", configureClient =>
            {
                configureClient.BaseAddress = new Uri(Configuration["Services:Products"]);
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)));
            services.AddHttpClient("CustomersService", configureClient =>
            {
                configureClient.BaseAddress = new Uri(Configuration["Services:Customers"]);
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)));
            services.AddHttpClient("ProductsCategoryService", configureClient =>
            {
                configureClient.BaseAddress = new Uri(Configuration["Services:ProductsCategory"]);
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)));
            //ProductsCategory
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
