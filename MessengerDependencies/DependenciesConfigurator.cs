using MessangerBL.Interfaces;
using MessangerBL.Options;
using MessangerBL.Services;
using MessangerData.Interfaces;
using MessangerData.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessengerDependencies
{
    public static class DependenciesConfigurator
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<NotificationOptions>(configuration.GetSection("Notification"));

            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddSingleton<IMessageService, MessageService>();
            services.AddSingleton<INotificationService, NotificationService>();
        }
    }
}
