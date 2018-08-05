using MessangerBL.Interfaces;
using MessangerBL.Models;
using MessangerBL.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MessangerBL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationOptions notificationOptions;

        public NotificationService(IOptions<NotificationOptions> notificationOptions)
        {
            this.notificationOptions = notificationOptions.Value;
        }

        public async Task<bool> SendMessageToNotificationServiceAsync(NotificationDTO notification)
        {
            var result = false;
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(notification);
                    client.BaseAddress = new Uri(notificationOptions.Url);
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("notification", json)
                    });
                    var httpResult = await client.PostAsync(notificationOptions.RequestUri, content);
                    var resultContent = await httpResult.Content.ReadAsStringAsync();
                    result = true;
                }
            }
            catch { }
            return result;
        }
    }
}
