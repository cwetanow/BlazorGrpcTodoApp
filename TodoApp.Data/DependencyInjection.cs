using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApp.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddDbContext<TodoAppContext>();
            services.AddScoped<DbContext>(p => p.GetRequiredService<TodoAppContext>());


            return services;
        }
    }
}
