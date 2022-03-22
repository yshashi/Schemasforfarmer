using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Schemasforfarmer.DataAccessLayer;
using Schemasforfarmer.DataAccessLayer.Interfaces;
using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIProject", Version = "v1" });
            });
            services.AddDbContext<AgricultureContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("SQLConnectionString"));
            });
            services.AddCors(option =>
            {
                option.AddPolicy(name: "CorsPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            services.AddSingleton<ICropDao, CropDao>();
            services.AddSingleton<ISellDao, SellDao>();
            services.AddSingleton<IBidDao, BidDao>();
            services.AddSingleton<IMarketPlace, MarketPlaceDao>();
            services.AddSingleton<IWelcomePage, WelcomePageDao>();
            services.AddSingleton<ISellRequest, SellRequestDao>();
            services.AddSingleton<ISoldHistory, SoldHistoryDao>();
            services.AddSingleton<ILoginInfo, LoginDao>();
            services.AddSingleton<IUserInfo, UserInfoDao>();
            services.AddSingleton<IUserDetail, UserDetailDao>();
            services.AddSingleton<IApplyforPolicyDao, ApplyforPolicyDao>();
            services.AddSingleton<IBankDetailsDao, BankDetailsDao>();
            services.AddSingleton<IClaimInsuranceDao, ClaimInsuranceDao>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiProject v1"));
            }
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
