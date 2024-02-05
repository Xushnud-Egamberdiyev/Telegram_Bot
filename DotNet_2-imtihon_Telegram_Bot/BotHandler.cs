using DotNet_2_imtihon_Telegram_Bot.Admin;
using DotNet_2_imtihon_Telegram_Bot.Instagram;
using DotNet_2_imtihon_Telegram_Bot.Youtube;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.WebRequestMethods;

namespace DotNet_2_imtihon_Telegram_Bot
{
    public class BotHandler
    {
        public string link { get; set; }
        public long admin = 943861214;
        public int son = 0;
        public string reklama = "https://t.me/T_Odilov";


        //public string Malumot;

        public BotHandler(string token)
        {
            link = token;
        }

        public async Task BotHandle()
        {
            var botClient = new TelegramBotClient(token: $"{link}");

            using CancellationTokenSource cts = new();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();

            //}

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {


                var handlar = update.Type switch
                {
                    UpdateType.Message => HandlaMessageAsync(botClient, update, cancellationToken),
                    UpdateType.EditedMessage => HandleVideoMessageAync2(botClient, update, cancellationToken),
                    UpdateType.CallbackQuery => HandleCallBackQueryAsymc(botClient, update, cancellationToken),
                    _ => HandlaUnkowMessageAsync(botClient, update, cancellationToken)
                };


                try
                {
                    await handlar;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Chiqdi! {ex.Message}");
                }








            }

        async Task HandlaUnkowMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task HandleCallBackQueryAsymc(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task HandleVideoMessageAync2(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task HandlaMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
                // Only process Message updates: https://core.telegram.org/bots/api#message
                Console.WriteLine($"Received a '{update.Message.Text}' message in chat ,{update.Message.Chat.LastName} {update.Message.Chat.FirstName} {update.Message.Chat.Id} ");
                
                if (update.Message is not { } message)
                    return;

                // Only process text messages
                var chatId = message.Chat.Id;

                var handlar = update.Message.Type switch
                {
                    MessageType.Contact => ContactAsyncText(botClient, update, cancellationToken),
                    MessageType.Text => TextAsync(botClient, update, cancellationToken),
                    _ => TextAsync(botClient, update, cancellationToken)

                };







                //if (message.Text == null)
                //{
                //    return;
                //}
                //else if (message.Text.StartsWith("https://www.instagram.com"))
                //{
                //    string replaceMessage = message.Text!.Replace("www.", "dd");

                //    try
                //    {
                //        Console.WriteLine("Qale");
                //        await botClient.SendVideoAsync(
                //           chatId: message.Chat.Id,
                //           video: $"{replaceMessage}",
                //           supportsStreaming: true,
                //           cancellationToken: cancellationToken);
                //    }
                //    catch (Exception) { }

                //    try
                //    {
                //        await botClient.SendPhotoAsync(chatId: message.Chat.Id, photo: $"{replaceMessage}", cancellationToken: cancellationToken);
                //    }
                //    catch (Exception) { }
                //}



                

            }
        }

        private async Task TextAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            if (update.Message is not { } message) return;
            //if (message.Chat.Id is not { } chatId) return;

            Crud.Create(new BotUser()
            {
                chatID = message.Chat.Id,
                status = 0,
                phoneNumber = ""
            });

            if (message.Contact != null)
            {
                Crud.Update(message.Chat.Id, message.Contact.PhoneNumber);
            }

            if (message.Text == "/start" && update.Message.Chat.Id == admin)
            {
                system_admin system_Admin = new system_admin();
                system_Admin.AdminWork(botClient, update, cancellationToken);

            }else if (message.Text == "/start")
            {
                if (Crud.IsPhoneNumberNull(message.Chat.Id) == false)
                {

                    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                        {
                        KeyboardButton.WithRequestContact("Contact ☎️")
                        })

                    {
                        ResizeKeyboard = true
                    };

                    await botClient.SendTextMessageAsync(
                     chatId: message.Chat.Id,
                     text: "Assalomu elykum! Botimizga hush kelibsiz\nBu bot orqali Video,Musica saqlab olishingiz mumkin✅\n" +
                       "Botdan tolliq foydalanish uchun Telefon nomeringizni qoldiring!",
                     replyMarkup: replyKeyboardMarkup,
                     cancellationToken: cancellationToken);
                    Crud.ChangeStatusCode(message.Chat.Id, 0);
                    son = 0;
                    return;
                }


            }

            if (message.Text == "User ma'lumotlarini pdf shaklida yuklash")
            {
                string malumot;
                using(StreamReader streader= new StreamReader(@"C:\Users\hp\user.json")) malumot= streader.ReadToEnd();
                 //string Malumot = JsonConvert.DeserializeObject<List<BotUser>>(@"C:\Users\hp\user.json");

                Admin_PDF admin_PDF = new Admin_PDF();
                admin_PDF.SendAllUsers2(malumot, @"C:\Users\hp\");

                await using Stream stream = System.IO.File.OpenRead(@"C:\Users\hp\hello.pdf");
                 
                await botClient.SendDocumentAsync(
                    chatId: update.Message.Chat.Id,
                    document: InputFile.FromStream(stream: stream, fileName: "Users.pdf"),
                    caption: "Userlarning barcha ma'lumotlari");
            }
            

            if (message.Contact != null)
            {
                Crud.Update(message.Chat.Id, message.Contact.PhoneNumber);
            }
            if (Crud.IsPhoneNumberNull(message.Chat.Id) == false && update.Message.Chat.Id != admin)
            {

                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {
                KeyboardButton.WithRequestContact("Phone number☎️")
                    })
                {
                    ResizeKeyboard = true
                };
                Message sentMessage1 = await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Botdan tolliq foydalanish uchun Telefon nomeringizni qoldiring ☎️!",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);


            }

            if (message.Text.StartsWith("https://www.instagram.com"))
            {
                await SendInstagramClass.EssentialFunction(botClient, update, cancellationToken);
            }
            else if (message.Text.StartsWith("https://www.youtube.com") || message.Text.StartsWith("https://youtu.be"))
            {
                await SendYoutube.EssentialFunction(botClient, update, cancellationToken);

                //await SendYoutubeMp3.EssentialFunction(botClient, update, cancellationToken);
            }
            else if(message.Text == "Reklamani jonatish")
            {
                string JRead;
                using(StreamReader reader = new StreamReader(@"C:\Users\hp\user.json")) 
                {
                    JRead = reader.ReadToEnd();
                }
                List<BotUser> person = JsonSerializer.Deserialize<List<BotUser>>(JRead);
                foreach (BotUser malumot in person)
                {
                    await botClient.SendTextMessageAsync(
                    chatId: malumot.chatID,
                        text: $" \n\nTohir aka bilsaz bilasiz uji rekdasiz😂\n\n {reklama}",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                }
            }

        }

        async Task ContactAsyncText(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;

            var chatId = message.Chat.Id;

            if (message.Contact != null)
            {
                Crud.Update(message.Chat.Id, message.Contact.PhoneNumber);
            }


            await botClient.SendTextMessageAsync(
                           chatId: chatId,
                           text: "Contagingiz qabul qilindi✅\n bot orqali Video,Musica saqlab olishingiz mumkin",
                           replyMarkup: new ReplyKeyboardRemove(),
                           cancellationToken: cancellationToken);
        }



        async Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
        }
    }
}
