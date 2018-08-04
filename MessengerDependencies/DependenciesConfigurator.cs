using MessengerBL.Interfaces;
using MessengerBL.Services;
using MessengerData.Interfaces;
using MessengerData.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MessengerDependencies
{
    public static class DependenciesConfigurator
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddSingleton<IMessageService, MessageService>();
        }
    }
}
