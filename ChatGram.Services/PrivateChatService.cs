using ChatGram.Core.Abstractions;
using ChatGram.Core.DTOs.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGram.Services
{
    public class PrivateChatService
    {
        private readonly IPrivateChatRepository _privateChatRepository;

        public PrivateChatService(IPrivateChatRepository privateChatRepository)
        {
            _privateChatRepository = privateChatRepository;
        }

        public async Task<List<PrivateChatDto>> GetUserPrivateChats(string userId)
        {
            return await _privateChatRepository.GetPrivateChats(userId, 0, 10);
        }

        public async Task<PrivateChatDto?> GetUserPrivateChat(Guid chatId, string userId)
        {
            PrivateChatDto chat =  await _privateChatRepository.GetPrivateChat(chatId);
            if (chat == null || (chat.SenderId != userId && chat.ReceiverId != userId) )
            {
                return null;
            }

            return chat;
        }
    }
}
