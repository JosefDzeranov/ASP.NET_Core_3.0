using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using Telegram.Bot.Types.ReplyMarkups;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Telegram.Bot.Types.Enums;



namespace TelegramTourBot
{
    public class ChatBotAPI : IChatBotApi
    {
        ITelegramBotClient bot;

        private IConnection rabbitConnection;
        private IModel rabbitChannel;

        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

        public event MessageReceivedEventHandler MessageReceive;

      

        private async Task HandleUpdateAsync( // функция, которая получает сообщения из ТГ
            ITelegramBotClient botClient, 
            Update update,
            CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message;

                if (message.Type == MessageType.Text || message.Type == MessageType.Contact)
                {
                    MessageReceive?.Invoke(
                        this,
                        new MessageReceivedEventArgs()
                        {
                            MessageId = message?.MessageId ?? 0,
                            MessageReceive = message?.Text,
                            UserId = message.From.Id,
                            Phone = message.Contact?.PhoneNumber,
                            MessageType = message.Type,
                            ChatId = message.Chat.Id
                        });
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Пожалуйста, введите команду");
                }
            }
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, //Обработчик ошибок из примера
            CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        public void Init() //инициализация бота
        {
            //Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            if (bot == null)
            {
                bot = new TelegramBotClient("5536396998:AAFidsNkJWyN9oDSMvx1WZsgwYMBZ1i81kw");
                var cts = new CancellationTokenSource();
                var cancellationToken = cts.Token;
                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = { }, // receive all update types
                };
                bot.StartReceiving(
                    HandleUpdateAsync,
                    HandleErrorAsync,
                    receiverOptions,
                    cancellationToken
                );
            }

            InitRabbit();
        }

        void InitRabbit()
        {
            ConnectionFactory factory = new ConnectionFactory();

            // "guest"/"guest" by default, limited to localhost connections
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = "localhost";

            // this name will be shared by all connections instantiated by
            // this factory
            factory.ClientProvidedName = "app:audit component:event-consumer";

            rabbitConnection = factory.CreateConnection();

            rabbitChannel = rabbitConnection.CreateModel();
            {
                rabbitChannel.ExchangeDeclare("dev-ex", ExchangeType.Fanout, true);
                rabbitChannel.QueueDeclare("dev-queue", true, false, false, null);
                rabbitChannel.QueueBind("dev-queue", "dev-ex", "15672", null);
            }

            var consumer = new EventingBasicConsumer(rabbitChannel);

            consumer.Received += Consumer_Received;

            // this consumer tag identifies the subscription
            // when it has to be cancelled
            string consumerTag = rabbitChannel.BasicConsume("dev-queue", false, consumer);
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            // copy or deserialise the payload
            // and process the message
            // ...
            //var msg = Encoding.UTF8.GetString(body.ToArray());
            rabbitChannel.BasicAck(e.DeliveryTag, false);
        }

        public async void SendContactRequest(long chatId)
        {
            var button = KeyboardButton.WithRequestContact("Send contact");
            var keyboard = new ReplyKeyboardMarkup(button);

            await bot.SendTextMessageAsync(chatId, "Please send contact", replyMarkup: keyboard);
        }

        public async void SendWelcomeMessage(long chatId, string firstName)
        {
            await bot.SendTextMessageAsync(chatId, $"Добро пожаловать, {firstName}");
        }

        public async void SendResponse(long chatId, string text)
        {
            await bot.SendTextMessageAsync(chatId, text);
        }

        public async void SendKeyboard(long chatId, string text)
        {
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] {"Список заказов", "Статус заказа"},
                new KeyboardButton[] {"Наши контакты", "Спецпредложения"}
            });

            await bot.SendTextMessageAsync(chatId, text, replyMarkup: keyboard);
        }

        //public async Task HandleMessage(ITelegramBotClient bot, Message message)
        //{
        //    if (message.Text == "/start")
        //    {
        //        await bot.SendTextMessageAsync(message.Chat.Id, "Выберите меню:/inline| keyboard");
        //    }

        //    if (message.Text == "/keyboard")
        //    {
        //        ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
        //        {
        //            new KeyboardButton[] {"Список заказов", "Статус заказа"},
        //            new KeyboardButton[] {"Наши контакты", "Спецпредложения"}
        //        });


        //        await bot.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: keyboard);

        //    }
        //}
    }
}
