﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using Telegram.Bot.Types.ReplyMarkups;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types.Enums;

namespace TelegramTourBot
{
    public class ChatBotAPI : IChatBotApi
    {
        ITelegramBotClient bot;

        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

        public event MessageReceivedEventHandler MessageReceive;

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
                    MessageReceive?.Invoke(
                        this,
                        new MessageReceivedEventArgs()
                        {
                            MessageId = message?.MessageId ?? 0,
                            MessageReceive = message?.Text,
                            UserId = message.From?.Id,
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

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        public void Init()
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
                new KeyboardButton[] {"Привет", "Пока"}
            });

            await bot.SendTextMessageAsync(chatId, text, replyMarkup: keyboard);
        }

        public async Task HandleMessage(ITelegramBotClient bot, Message message)
        {
            if (message.Text == "/start")
            {
                await bot.SendTextMessageAsync(message.Chat.Id, "Выберите меню:/inline| keyboard");
            }

            if (message.Text == "/keyboard")
            {
                ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton[] {"Список заказов", "Статус заказа"},
                    new KeyboardButton[] {"Привет", "Пока"}
                });


                await bot.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: keyboard);

            }
        }
    }
}
