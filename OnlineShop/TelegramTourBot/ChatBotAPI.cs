using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Telegram.Bot.Types.Enums;



namespace TelegramTourBot
{
    public class ChatBotAPI : IChatBotApi
    {
        ITelegramBotClient bot;

        private IConnection rabbitConnectionPublisher;
        private IModel rabbitChannelPublisher;

        private IConnection rabbitConnectionConsumer;
        private IModel rabbitChannelConsumer;

        /// <summary>
        /// Функция, которая получает сообщения из ТГ
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task HandleUpdateAsync( 
            ITelegramBotClient botClient, 
            Update update,
            CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message;

                if (message.Type == MessageType.Text || message.Type == MessageType.Contact)
                {
                    var queueMessageModel = new QueueMessageModel()
                    {
                        MessageId = message?.MessageId ?? 0,
                        MessageReceive = message?.Text,
                        UserId = message.From.Id,
                        Phone = message.Contact?.PhoneNumber,
                        MessageType = message.Type,
                        ChatId = message.Chat.Id
                    };

                    QueueRabbitMessage(queueMessageModel);

                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Пожалуйста, введите команду");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queueMessageModel"></param>
        private void QueueRabbitMessage(QueueMessageModel queueMessageModel)
        {
            var jsonMessage = JsonConvert.SerializeObject(queueMessageModel);

            var body = Encoding.UTF8.GetBytes(jsonMessage);

            rabbitChannelPublisher.BasicPublish(exchange: "dev-ex-to-web", routingKey: "", basicProperties: null, body: body);
        }

        /// <summary>
        /// Обработчик ошибок
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        /// <summary>
        /// Инициализация бота
        /// </summary>
        public void Init() 
        {
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

        /// <summary>
        /// Инициализация Rabbit
        /// </summary>
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
            factory.ClientProvidedName = "online shop";//"app:audit component:event-consumer";

            rabbitConnectionPublisher = factory.CreateConnection();
            rabbitConnectionConsumer = factory.CreateConnection();

            rabbitChannelPublisher = rabbitConnectionPublisher.CreateModel(); //объявляет обмен и очередь в Web
            {
                rabbitChannelPublisher.ExchangeDeclare("dev-ex-to-web", ExchangeType.Direct, true); 
                rabbitChannelPublisher.QueueDeclare("dev-queue-to-web", true, false, false, null);
                rabbitChannelPublisher.QueueBind("dev-queue-to-web", "dev-ex-to-web", "", null);
            }

            rabbitChannelConsumer = rabbitConnectionConsumer.CreateModel(); ////объявляет обмен и очередь в Telegram
            {
                rabbitChannelConsumer.ExchangeDeclare("dev-ex-to-telegram", ExchangeType.Direct, true);
                rabbitChannelConsumer.QueueDeclare("dev-queue-to-telegram", true, false, false, null);
                rabbitChannelConsumer.QueueBind("dev-queue-to-telegram", "dev-ex-to-telegram", "", null);
            }

            var consumer = new EventingBasicConsumer(rabbitChannelConsumer);

            consumer.Received += Consumer_Received;

            // this consumer tag identifies the subscription
            // when it has to be cancelled
            string consumerTag = rabbitChannelConsumer.BasicConsume("dev-queue-to-telegram", false, consumer);
        }

        /// <summary>
        /// Получаем сообщение из рэббита и дессириализуем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var json = Encoding.UTF8.GetString(e.Body.ToArray());

            var message = JsonConvert.DeserializeObject<QueueMessageModel>(json);

            SendKeyboard(message.ChatId, message.MessageReceive);

            rabbitChannelConsumer.BasicAck(e.DeliveryTag, false);
        }

        /// <summary>
        /// Запрос на контакт, до этого пользователь был анонимный
        /// </summary>
        /// <param name="chatId"></param>
        public async void SendContactRequest(long chatId) 
        {
            var button = KeyboardButton.WithRequestContact("Send contact");
            var keyboard = new ReplyKeyboardMarkup(button);

            await bot.SendTextMessageAsync(chatId, "Please send contact", replyMarkup: keyboard);
        }

        /// <summary>
        /// Отправить приветственное письмо
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="firstName"></param>
        public async void SendWelcomeMessage(long chatId, string firstName) 
        {
            await bot.SendTextMessageAsync(chatId, $"Добро пожаловать, {firstName}");
        }

        /// <summary>
        /// Отправить в ТГ сообщение пользователю 
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="text"></param>
        public async void SendResponse(long chatId, string text) 
        {
            await bot.SendTextMessageAsync(chatId, text);
        }

        /// <summary>
        /// Отправить пользователю клавиатуру
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="text"></param>
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
