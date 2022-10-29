using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.Enums;

namespace TelegramTourBot
{
    public class QueueMessageModel
    {
        public string MessageReceive { get; set; }

        public int MessageId { get; set; }

        public long UserId { get; set; }

        public string Phone { get; set; }

        public MessageType MessageType { get; set; }

        public long ChatId { get; set; }
    }
}
