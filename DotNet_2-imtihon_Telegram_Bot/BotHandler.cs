using DotNet_2_imtihon_Telegram_Bot.Admin;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DotNet_2_imtihon_Telegram_Bot
{
    public class BotHandler
    {
        public string link { get; set; }

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
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages

            #region crud
            var chatId = message.Chat.Id;
            Console.WriteLine($"Received a '{update.Message.Text}' message in chat ,{update.Message.Chat.LastName} {update.Message.Chat.FirstName} {update.Message.Chat.Id} ");


            //if (message.Text == "/start" && update.Message.Chat.Id == 1633746526)
            //{
            //    system_admin system_Admin = new system_admin();
            //    system_Admin.AdminWork(botClient, update, cancellationToken);

            //}

            //if(message.Text == "Reklamani jonatish")
            //{
            //    system_admin system_Admin = new system_admin();
            //    system_Admin.Reklama(botClient, update, cancellationToken);
            //}

            //Crud.Create(new BotUser()
            //{
            //    chatID = chatId,
            //    status = 0,
            //    phoneNumber = ""
            //});


            if (message.Text == "/start")
            {

                if (Crud.IsPhoneNumberNull(chatId) == false)
                {

                    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                    {
                KeyboardButton.WithRequestContact("Phone number☎️")
            })
                    {
                        ResizeKeyboard = true
                    };
                    await botClient.SendTextMessageAsync(
                           chatId: chatId,
                           text: "Assalomu elykum! Botimizga hush kelibsiz\nBu bot orqali Video,Musica saqlab olishingiz mumkin✅\n" +
                           "Botdan tolliq foydalanish uchun Telefon nomeringizni qoldiring!",
                           replyMarkup: replyKeyboardMarkup,
                           cancellationToken: cancellationToken);
                    return;

                }
                
                
                
                
            }
            #endregion




            #region Phone number
            if (message.Contact != null)
            {
                Crud.Update(chatId, message.Contact.PhoneNumber);
            }
            if (Crud.IsPhoneNumberNull(chatId) == false)
            {

                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {   



                KeyboardButton.WithRequestContact("Phone number☎️")
            })
                {
                    ResizeKeyboard = true
                };
                Message sentMessage1 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Botdan tolliq foydalanish uchun Telefon nomeringizni qoldiring!",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);


            }
            else if (Crud.IsPhoneNumberNull(chatId) == true)
            {
                await botClient.SendTextMessageAsync(
                       chatId: chatId,
                       text: $"Contagingiz qabul qilindi✅    {message.Chat.LastName} {message.Chat.FirstName}",
                       cancellationToken: cancellationToken);
                return;
            }
            #endregion


            if (message.Text == null)
            {
                return;
            }
            else if (message.Text.StartsWith("https://www.instagram.com"))
            {
                string replaceMessage = message.Text!.Replace("www.", "dd");

                try
                {
                    Console.WriteLine("Qale");
                    await botClient.SendVideoAsync(
                       chatId: message.Chat.Id,
                       video: $"{replaceMessage}",
                       supportsStreaming: true,
                       cancellationToken: cancellationToken);
                }
                catch (Exception) { }

                try
                {
                    await botClient.SendPhotoAsync(chatId: message.Chat.Id, photo: $"{replaceMessage}", cancellationToken: cancellationToken);
                }
                catch (Exception) { }
            }

        }

        async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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
