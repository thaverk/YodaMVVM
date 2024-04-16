using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YodaMVVM.Enum;


namespace YodaMVVM.Models
{
    public class ChatMessage
    {
        public ChatMessageTypeEnum MessageType{get;set; }
        public string? MessageBody { get; set; }

    }
}
