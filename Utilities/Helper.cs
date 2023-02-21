using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using core_h.w.Services;
using core_h.w.Interface;
using core_h.w.Utilities;

namespace core_h.w.Utilities
{
    public static class Helper
    {
        public static void addMission(this IServiceCollection service)
        {
            service.AddSingleton<IMissionService, MissionService>();
        }
    }
}