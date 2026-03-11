using ChatGram.Core.DTOs.Chats;
using ChatGram.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGram.Core.Abstractions
{
    public interface IPrivateChatRepository
    {
        void Add(PrivateChat chat);
        Task<List<PrivateChatDto>> GetPrivateChats(string userId, int offset, int limit);
        Task<PrivateChatDto> GetPrivateChat(Guid chatId);
        Task<bool> IsPrivateChatExistsAsync(string senderId, string receiverId);
        Task<int> SaveChangesAsync();
    }
}
