using ChatGram.Core.DTOs.Messages;
using ChatGram.Core.Entities.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGram.Core.Abstractions
{
    public interface IMessageRepository
    {
        void Add(MessageBase message);
        Task<List<MessageDto>> GetMessages(int limit, int offset);
        Task<MessageDto> GetMessage(Guid id);
        Task<int> SaveChangesAsync();
    }
}
