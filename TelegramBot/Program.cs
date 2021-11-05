using System;
using System.Collections.Generic;
using Telegram_Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;

namespace Telegram_Bot
{
    class Program
    {
        private static string Token { get; set; } = "1780423888:AAHCQVGpy1ATVqcZcGm2sO_kZ7renH7Bqp4";
       
        
        
        private static TelegramBotClient client;

        
        
        
        
        
        
        static void Main(string[] args)
        {
            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($" сообщение с текстом: {msg.Text}");
                switch (msg.Text)
                {
                    case "Стикер":
                        await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "Ссылка на стикер",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;
                    case "image":
                        await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "Ссылка на картинку",
                            replyMarkup: GetButtons());
                        break;

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Выберите команду: ", replyMarkup: GetButtons());
                        break;
                }
            }
        }

       
        
        
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Стикер"}, new KeyboardButton { Text = "image"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "123456789"}, new KeyboardButton { Text = "456"} }
                }
            };
        }
    }
}