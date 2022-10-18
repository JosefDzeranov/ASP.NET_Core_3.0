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
            //Bot = new TelegramBotClient("5536396998:AAFidsNkJWyN9oDSMvx1WZsgwYMBZ1i81kw");
            //Bot.OnMessage += BotOnMessageReceived; // чтобы подписаться на события и подключить работу с текстом

            //var me = Bot.GetMeAsync().Result; // чтобы получать информацию о боте
            //Console.WriteLine(me.FirstName);
            var chat = new ChatBotAPI();
            chat.Init();
            Console.ReadLine();
        }

        //private static void BotOnMessageReceived(object sender, Telegram.Bot.Args)
        //{
        //    var message= 
        //}
    }
}