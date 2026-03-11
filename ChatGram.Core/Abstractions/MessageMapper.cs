using ChatGram.Core.DTOs.Messages;
using ChatGram.Core.Entities.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGram.Core.Abstractions
{
    public static class MessageMapper
    {
        public static MessageDto Map(MessageBase message, string nickname)
        {
            return message switch
            {
                TextMessage text => new TextMessageDto
                {
                    Id = message.Id,
                    UserId = message.UserId,
                    Nickname = nickname,
                    CreatedAt = message.CreatedAt,
                    Text = (message as TextMessage).Text
                },

                FileMessage file => new FileMessageDto
                {
                    Id = message.Id,
                    UserId = message.UserId,
                    Nickname = nickname,
                    CreatedAt = message.CreatedAt,
                    Text = (message as FileMessage)?.Text,
                    FilePath = (message as FileMessage).FilePath
                },

                GeoMessage geo => new GeoMessageDto
                {
                    Id = message.Id,
                    UserId = message.UserId,
                    Nickname = nickname,
                    CreatedAt = message.CreatedAt,
                    Latitude = (message as GeoMessage).Latitude,
                    Longitude = (message as GeoMessage).Longitude
                },

                _ => throw new NotSupportedException($"Unknown message type {message.GetType()}")
            };
        }
    }
}
