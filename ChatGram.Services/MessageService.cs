using ChatGram.Core.Abstractions;
using ChatGram.Core.DTOs.Messages;
using ChatGram.Core.Entities.Message;
using ChatGram.web.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChatGram.Core.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IHubContext<NotificationHub> _notificationHubContext;

        public MessageService(IMessageRepository messageRepository, IHubContext<NotificationHub> notificationHubContext)
        {
            _messageRepository = messageRepository;
            _notificationHubContext = notificationHubContext;
        }

        public async Task<TextMessage> SendTextMessage(string senderId, string text)
        {
            var msg = new TextMessage
            {
                Id = Guid.NewGuid(),
                UserId = senderId,
                Text = text,
                CreatedAt = DateTime.UtcNow,
            };
            _messageRepository.Add(msg);
            await _messageRepository.SaveChangesAsync();
            await _notificationHubContext.Clients.All.SendAsync("ReceiveNotification");

            return msg;
        }

        public async Task<FileMessage> SendFileMessage(string senderId, string filePath, string? text)
        {
            var msg = new FileMessage
            {
                Id = Guid.NewGuid(),
                UserId = senderId,
                FilePath = filePath,
                Text = text,
                CreatedAt = DateTime.UtcNow,
            };
            _messageRepository.Add(msg);
            await _messageRepository.SaveChangesAsync();
            await _notificationHubContext.Clients.All.SendAsync("ReceiveNotification");

            return msg;
        }

        public async Task<GeoMessage> SendGeoMessage(string senderId, double latitude, double longitude)
        {
            var msg = new GeoMessage
            {
                Id = Guid.NewGuid(),
                UserId = senderId,
                Latitude = latitude,
                Longitude = longitude,
                CreatedAt = DateTime.UtcNow,
            };
            _messageRepository.Add(msg);
            await _messageRepository.SaveChangesAsync();
            await _notificationHubContext.Clients.All.SendAsync("ReceiveNotification");

            return msg;
        }

        public async Task<List<MessageDto>> GetMessages(int limit, int offset)
        {
            return await _messageRepository.GetMessages(limit, offset);
        }
    }
}
