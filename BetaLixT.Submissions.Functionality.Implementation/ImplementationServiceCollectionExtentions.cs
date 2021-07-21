using BetaLixT.Submissions.Functionality.Implementation.Context;
using BetaLixT.Submissions.Functionality.Implementation.CoreServices;
using BetaLixT.Submissions.Functionality.Implementation.Scripts;
using BetaLixT.Submissions.Functionality.Interface.CoreServices;
using BetaLixT.Submissions.Functionality.Interface.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Implementation
{
    public static class ImplementationServiceCollectionExtentions
    {
        public static void RegisterDatabaseService(
               this IServiceCollection services,
               string databaseConnectionString)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(databaseConnectionString, ServerVersion.AutoDetect(databaseConnectionString))
            );
        }

        public static void RegisterServiceServices(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseScripts, DatabaseScripts>();
            services.AddTransient<INamespaceService, NamespaceService>();
        }
    }
}
