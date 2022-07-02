using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace TelegramTourBot
{
    public interface IChatBotApi
    {
        void Init();

        event ChatBotAPI.MessageReceivedEventHandler MessageReceive;
        void SendContactRequest(long chatId);
        void SendWelcomeMessage(long chatId, string firstName);

        void SendResponse(long chatId, string text);

        void SendKeyboard(long chatId, string text);
    }
}
