using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace DotNet_2_imtihon_Telegram_Bot.Admin
{
    public class system_admin
    {
        public async Task AdminWork(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;

            var chatId = message.Chat.Id;


            if (message.Text == "/start" && update.Message.Chat.Id == 5921666026)
            {

               

                    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                    {
                KeyboardButton.WithRequestContact("Reklamani jonatish"),
                KeyboardButton.WithRequestContact("User ma'lumotlarini pdf shaklida yuklash")



            })
                    {
                        ResizeKeyboard = true
                    };
                    await botClient.SendTextMessageAsync(
                           chatId: chatId,
                           text: "Assalomu elykum! Botimizga hush kelibsiz\nBu botga admin paneli orqali kirdingiz",
                           replyMarkup: replyKeyboardMarkup,
                           cancellationToken: cancellationToken);
                    return;

                
                
            }
        }

        public async Task Reklama(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message.Text == "Reklamani jonatish")
            {
                Console.WriteLine("Keldi");
            }
        }
    }

    
}
