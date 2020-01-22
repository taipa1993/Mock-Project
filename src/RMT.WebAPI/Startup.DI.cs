using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RMT.ApplicationCore.Interfaces;
using RMT.ApplicationCore.Services;
using RMT.Infrastructure.Data;
using RMT.WebAPI.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMT.WebAPI
{
    public partial class Startup
    {
        public void AddDiServices(IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICVRepository, CVRepository>();
            services.AddScoped<ICVService, CVService>();

            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<ILevelService, LevelService>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IRoundRepository, RoundRepository>();
            services.AddScoped<IRoundService, RoundService>();

            services.AddScoped<IUserRoundRepository, UserRoundRepository>();
            services.AddScoped<IUserRoundService, UserRoundService>();
        }
    }
}
