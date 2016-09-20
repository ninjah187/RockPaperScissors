using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Services;

namespace RockPaperScissors
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=RockPaperScissorsDb;Trusted_Connection=true";

            services
                .AddDbContext<AppDbContext>(options => options.UseSqlServer(connection))
                .AddScoped<IPlayerService, PlayerService>()
                .AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseDeveloperExceptionPage()
                .UseStaticFiles()
                .UseMvcWithDefaultRoute();
        }
    }
}
