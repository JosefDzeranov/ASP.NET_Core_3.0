using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace TelegramTourBot
{
    public class ChatBotAPI : IChatBotApi
    {
        ITelegramBotClient bot;

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
        }

        public async void SendContactRequest(long chatId)
        {
            var button = KeyboardButton.WithRequestContact("Send contact");
            var keyboard = new ReplyKeyboardMarkup(button);

            await bot.SendTextMessageAsync(chatId, "Please send contact", replyMarkup: keyboard);
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
    }
}
