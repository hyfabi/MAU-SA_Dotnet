﻿using At.Mausa.Grasmaster.Infrastructure.Context;

using Microsoft.Extensions.DependencyInjection;


namespace At.Mausa.Grasmaster.Infrastructure{
    public static class SqlExtensions {
        public static void ConfigureSqlite(this IServiceCollection services, string connectionString) {
            services.AddDbContext<ApplicationDbContext>(options => {
                
            });
        }
    }
}