using MessangerBL.Interfaces;
using MessangerBL.Models;
using Messenger.Controllers;
using Messenger.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Messanger.Test
{
    public class MessageControllerTest
    {
        [Fact]
        public void SaveAsync_SendTrue_Successes()
        {
            var messagerServiceMoq = new Mock<IMessageService>();
            var saveAsyncExpectResult = Guid.NewGuid().ToString();
            messagerServiceMoq.Setup(m => m.SaveAsync(It.IsAny<MessageDTO>())).Returns(Task.FromResult(saveAsyncExpectResult));

            var notificationServiceMoq = new Mock<INotificationService>();
            notificationServiceMoq.Setup(n => n.SendMessageToNotificationServiceAsync(It.IsAny<NotificationDTO>())).Returns(Task.FromResult(true));

            MessageController mc = new MessageController(messagerServiceMoq.Object, notificationServiceMoq.Object);

            var result = mc.SaveAsync(new CreateMessageViewModel());
            Assert.NotNull(result.Result);
            Assert.Equal(result.Result, saveAsyncExpectResult);
        }

        [Fact]
        public void SaveAsync_SendFalse_Successes()
        {
            var messagerServiceMoq = new Mock<IMessageService>();
            var saveAsyncExpectResult = Guid.NewGuid().ToString();
            messagerServiceMoq.Setup(m => m.SaveAsync(It.IsAny<MessageDTO>())).Returns(Task.FromResult(saveAsyncExpectResult));

            var notificationServiceMoq = new Mock<INotificationService>();
            notificationServiceMoq.Setup(n => n.SendMessageToNotificationServiceAsync(It.IsAny<NotificationDTO>())).Returns(Task.FromResult(false));

            MessageController mc = new MessageController(messagerServiceMoq.Object, notificationServiceMoq.Object);

            var result = mc.SaveAsync(new CreateMessageViewModel());
            Assert.NotNull(result.Result);
            Assert.Equal(result.Result, saveAsyncExpectResult);
        }

        [Fact]
        public void AllAsync_Successes()
        {
            var messagerServiceMoq = new Mock<IMessageService>();
            IEnumerable<MessageDTO> allAsyncExpectResult = new List<MessageDTO>() { new MessageDTO() };
            messagerServiceMoq.Setup(m => m.AllAsync()).Returns(Task.FromResult(allAsyncExpectResult));

            var notificationServiceMoq = new Mock<INotificationService>();
            MessageController mc = new MessageController(messagerServiceMoq.Object, notificationServiceMoq.Object);

            var result = mc.AllAsync();
            Assert.NotNull(result.Result);
            Assert.Equal(result.Result.Count(), allAsyncExpectResult.Count());
            Assert.Equal(result.Result.First().Body, allAsyncExpectResult.First().Body);
            Assert.Equal(result.Result.First().Id, allAsyncExpectResult.First().Id);
            Assert.Equal(result.Result.First().IsSent, allAsyncExpectResult.First().IsSent);
            Assert.Equal(result.Result.First().Subject, allAsyncExpectResult.First().Subject);
        }
    }
}
