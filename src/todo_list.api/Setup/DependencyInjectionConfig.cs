using Microsoft.Extensions.DependencyInjection;
using todo_list.api.Data.Context;
using todo_list.api.Data.Interfaces;
using todo_list.api.Data.Repository;
using todo_list.api.Notifications;
using todo_list.api.Services;
using todo_list.api.Services.Interfaces;

namespace todo_list.api.Setup
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<ITodoService, TodoService>();

            services.AddSingleton<TodoContext>();

            services.AddScoped<INotifier, Notifier>();
        }
    }
}
