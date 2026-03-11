using ChatGram.Core.Abstractions;
using ChatGram.Core.DTOs.Messages;
using ChatGram.Core.Entities.Message;
using Microsoft.AspNetCore.SignalR;

namespace ChatGram.Services.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IMessageRepository _messageRepository;

        public MessageHub(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task SendTextMessage(TextMessage message)
        {
            TextMessageDto textMessageDto = (await _messageRepository.GetMessage(message.Id) as TextMessageDto);
            await Clients.All.SendAsync("ReceiveTextMessage", textMessageDto);
        }

        public async Task SendFileMessage(FileMessage message)
        {
            FileMessageDto fileMessageDto = (await _messageRepository.GetMessage(message.Id) as FileMessageDto);
            await Clients.All.SendAsync("ReceiveFileMessage", fileMessageDto);
        }

        public async Task SendGeoMessage(GeoMessage message)
        {
            GeoMessageDto geoMessageDto = (await _messageRepository.GetMessage(message.Id) as GeoMessageDto);
            await Clients.All.SendAsync("ReceiveGeoMessage", geoMessageDto);
        }
    }
}
