using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGram.Core.Entities.Message
{
    public class TextMessage : MessageBase
    {
        public string Text { get; set; }
    }
}
