using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using WebApp.Data;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
                options.AddPolicy("CashierOnly", p => p.RequireClaim("Position", "Cashier"));
                /** INSERT INTO AspNetUserClaims VALUES ('6091345e-6bd9-4284-ab92-0da0ec8b3da7', 'Position', 'Cashier')
                    INSERT INTO AspNetUserClaims VALUES ('b6f74a33-ae38-4d7f-9e46-f552c82bac4d', 'Position', 'Admin'*/
            });

            // DI for In-Memory Data Store
            //services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
            //services.AddScoped<IProductRepository, ProductInMemoryRepository>();
            //services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();

            // DI for Data Store
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            //categories
            services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
            services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            //products
            services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
            services.AddTransient<IAddProductUseCase, AddProductUseCase>();
            services.AddTransient<IEditProductUseCase, EditProductUseCase>();
            services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IViewProductsByCategoryIdUseCase, ViewProductsByCategoryIdUseCase>();
            services.AddTransient<ISellProductUseCase, SellProductUseCase>();
            //transactions
            services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
            services.AddTransient<IGetTodayTransactionUseCase, GetTodayTransactionUseCase>();
            services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}