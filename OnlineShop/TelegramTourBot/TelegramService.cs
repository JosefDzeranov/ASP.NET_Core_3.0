using OnlineShop.db;
using OnlineShop.db.Models;
using Telegram.Bot.Types.Enums;
using System.Text;
using User = OnlineShop.db.Models.User;
using Orders;

namespace TelegramTourBot
{
    public class TelegramService
    {
        private readonly IChatBotApi chatBotApi;
        private readonly UserDbRepository userDbRepository;
        private readonly OrdersService ordersService;

        public TelegramService(IChatBotApi chatBotApi, UserDbRepository userDbRepository, OrdersService ordersService)
        {
            this.chatBotApi = chatBotApi;

            chatBotApi.Init();

            chatBotApi.MessageReceive += ChatBotApi_MessageReceive;
            OrdersService.OrderStatusUpdatedEvent += OrdersRepository_OrderStatusUpdatedEvent;

            this.userDbRepository = userDbRepository;
            this.ordersService = ordersService;
        }

        private void OrdersRepository_OrderStatusUpdatedEvent(object sender, OrderStatusUpdatedEventArgs e)
        {
            chatBotApi.SendKeyboard(e.Order.User.TelegramUserId.Value, BuildOrderStatusMessage(e.Order));
        }

        private void ChatBotApi_MessageReceive(object sender, MessageReceivedEventArgs e)
        {
            if (e.MessageType == MessageType.Text)
            {
                var existingUser = userDbRepository.TryGetByTelegramUserId(e.UserId);

                if (existingUser != null)
                {
                    if (e.MessageReceive == "Список заказов")
                    {
                        var msg = BuildOrdersMessage(existingUser);
                        chatBotApi.SendKeyboard(e.ChatId, msg);
                    }

                    if (e.MessageReceive == "Статус заказа")
                    {
                        var orders = ordersService.TryGetByUserId(existingUser.Id);
                        var text = "";
                        foreach (var order in orders)
                        {
                            var msg = BuildOrderStatusMessage(order);
                            text += msg + "\n";
                        }
                        
                        chatBotApi.SendKeyboard(e.ChatId, text);
                    }
                    if (e.MessageReceive == "Наши контакты")
                    {
                        chatBotApi.SendKeyboard(e.ChatId, $"Будем рады видеть Вас в нашем офисе. По адресу:г.Москва, ул.Цветной Бульвар 30. Телефон:+7-123-45-67");
                    }
                    if (e.MessageReceive == "Спецпредложения")
                    {
                        chatBotApi.SendKeyboard(e.ChatId, $"Только сегодня!!! При бронировании тура в Турцию скидка 5%. Торопитесь!!!");
                    }

                    else
                    {
                        chatBotApi.SendKeyboard(e.ChatId, "Введите команду");
                    }

                }
                else
                {
                    chatBotApi.SendContactRequest(e.ChatId);
                }
            }
            else if (e.MessageType == MessageType.Contact)
            {
                var result = userDbRepository.UpdateTelegramUserId(e.Phone, e.UserId);

                if (result)
                {
                    var existingUser = userDbRepository.TryGetByTelegramUserId(e.UserId);
                    //chatBotApi.SendWelcomeMessage(e.ChatId, existingUser.FirstName);
                    chatBotApi.SendKeyboard(e.ChatId, $"Добро пожаловать, {existingUser.FirstName}");
                }
                else
                {
                    chatBotApi.SendKeyboard(e.ChatId, $"Пожалуйста, перейдите по ссылке ... , чтобы зарегестрироваться");
                }
            }

        }

        public string BuildOrdersMessage(User user)
        {
            var orders = ordersService.TryGetByUserId(user.Id);
            if (orders.Count != 0)
            {
                var sb = new StringBuilder();
                foreach (var order in orders)
                {
                    sb.AppendLine($"Заказ #{order.Id}");
                    foreach (var item in order.Items)
                    {
                        sb.AppendLine($"{item.Product.Name} x{item.Amount} {item.Cost}");
                    }
                    sb.AppendLine($"Статус {order.Status}");
                }

                return sb.ToString();
            }
            else
            {
                return "У Вас пока нет заказов";
            }
        }

        public string BuildOrderStatusMessage(Order order)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Заказ #{order.Id}");
            sb.AppendLine($"Статус {order.Status}");

            return sb.ToString();
        }
    }
}

