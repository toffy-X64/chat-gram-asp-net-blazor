using ChatGram.Core.Abstractions;
using ChatGram.Core.DTOs.Chats;
using ChatGram.Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGram.Services.Hubs
{
    public class ChatHub : Hub
    {
        private IPrivateChatRepository _privateChatRepository;

        public ChatHub(IPrivateChatRepository privateChatRepository)
        {
            _privateChatRepository = privateChatRepository;
        }

        public async Task AssignNewPrivateChat(PrivateChat privateChat)
        {
            PrivateChatDto dto = await _privateChatRepository.GetPrivateChat(privateChat.Id);
            await Clients.All.SendAsync("ReceiveNewChat", privateChat);
        }
    }
}
