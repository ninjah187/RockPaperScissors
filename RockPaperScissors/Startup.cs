﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RockPaperScissors.Services;
using RockPaperScissors.Models;

namespace RockPaperScissors
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=RockPaperScissorsDb;Trusted_Connection=true";

            services
                .AddDbContext<AppDbContext>(options => options.UseSqlServer(connection))
                .AddScoped<DbContext, AppDbContext>()
                .AddScoped<IPlayerService, PlayerService>()
                .AddScoped<IGamesRepository, GamesRepository>()
                .AddScoped<IRepository<Game>, Repository<Game>>()
                .AddScoped<IRepository<GameStage>, Repository<GameStage>>()
                .AddScoped<IRepository<Player>, Repository<Player>>()
                .AddSingleton<IAccessorsProvider, AccessorsProvider>()
                .AddSingleton<IModelUpdateService, ModelUpdateService>()
                .AddSingleton<IAccessCodeGenerator, AccessCodeGenerator>()
                .AddScoped<IGameService, GameService>()
                .AddScoped<IGameSearchService, GameSearchService>()
                .AddMvc();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseStatusCodePages()
                .UseDeveloperExceptionPage()
                .UseStaticFiles()
                .UseMvcWithDefaultRoute();
                //.UseMvc();
        }
    }
}
