using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using OnlineShop.db;
using OnlineShop.db.Models;
using TelegramTourBot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Linq;
using System.Text;
using User = OnlineShop.db.Models.User;

namespace OnlineShopWebApp.Services
{
    public class TelegramService
    {
        private readonly IChatBotApi chatBotApi;
        private readonly UserDbRepository userDbRepository;
        private readonly IOrdersRepository ordersRepository;

        public TelegramService(IChatBotApi chatBotApi, UserDbRepository userDbRepository, IOrdersRepository ordersRepository)
        {
            this.chatBotApi = chatBotApi;

            chatBotApi.Init();

            chatBotApi.MessageReceive += ChatBotApi_MessageReceive;
            
            this.userDbRepository=userDbRepository;
            this.ordersRepository=ordersRepository;
            
        }

        private void ChatBotApi_MessageReceive(object sender, MessageReceivedEventArgs e)
        {
            if (e.MessageType == MessageType.Text)
            {
                var existingUser = userDbRepository.TryGetByTelegramUserId(e.UserId.ToString());

                if (existingUser != null)
                {
                    if (e.MessageReceive == "Список заказов")
                    {
                        var msg = BuildOrdersMessage(existingUser);
                        chatBotApi.SendKeyboard(e.ChatId, msg);
                    }


                    else
                    {
                        chatBotApi.SendKeyboard(e.ChatId, "Введите команду");
                    }
;
                }
                else 
                {
                    chatBotApi.SendContactRequest(e.ChatId);
                }
            }
            else if(e.MessageType==MessageType.Contact)
            {
                var result = userDbRepository.UpdateTelegramUserId(e.Phone, e.UserId.ToString());

                if (result)
                {
                    var existingUser = userDbRepository.TryGetByTelegramUserId(e.UserId.ToString());
                    //chatBotApi.SendWelcomeMessage(e.ChatId, existingUser.FirstName);
                    chatBotApi.SendKeyboard(e.ChatId, $"Добро пожаловать, {existingUser.FirstName}");
                }
                else
                {
                    
                }
            }

        }

        public string BuildOrdersMessage(User user)
        {
            var orders = ordersRepository.TryGetByUserId(user.Id);
            if (orders.Count != 0)
            {
                var sb = new StringBuilder();
                foreach (var item in orders)
                {
                    sb.Append($"Заказ #{item.Id} Статус {item.Status}");
                }

                return sb.ToString();
            }
            else
            {
                return "У Вас пока нет заказов";
            }
        }

    }
}

