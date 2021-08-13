using BetaLixT.Submissions.Api.CoreServices;
using BetaLixT.Submissions.Common.Context;
using BetaLixT.Submissions.Common.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common
{
    public static class ApiServiceCollectionExtentions
    {
        public static void RegisterDatabaseService(
               this IServiceCollection services,
               string databaseConnectionString)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(databaseConnectionString, ServerVersion.AutoDetect(databaseConnectionString))
            );
        }

        public static void RegisterApiServices(this IServiceCollection services)
        {
            services.AddTransient<DatabaseScripts>();
            services.AddTransient<NamespaceService>();
        }
    }
}
