using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using TelegramTourBot;

namespace TelegramBotExperiments
{
    class Program
    {
       static TelegramBotClient Bot;
        static void Main(string[] args)
        {
            var chat = new ChatBotAPI();
            chat.Init();
            Console.ReadLine();
        }

    }
}