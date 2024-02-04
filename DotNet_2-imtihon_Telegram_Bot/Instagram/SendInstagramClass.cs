using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace DotNet_2_imtihon_Telegram_Bot.Instagram
{
    public class SendInstagramClass
    {
        public static async Task EssentialFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            bool isEnter = false;
            string link = update.Message.Text;
            List<RootInstagram> InstagramVideosAndPhotos = JsonConvert.DeserializeObject<List<RootInstagram>>(InstagramClass.RunApi(link).Result);
            foreach (var item in InstagramVideosAndPhotos)
            {
                isEnter = true;
                Console.WriteLine($"\n{item.url}\n");
                await botClient.SendChatActionAsync(
                chatId: update.Message.Chat.Id,
                    chatAction: ChatAction.UploadDocument,
                    cancellationToken: cancellationToken
                );
                if (item.type == "video")
                {
                    await botClient.SendVideoAsync(
                       chatId: update.Message.Chat.Id,
                    video: InputFileUrl.FromUri(item.url),
                       supportsStreaming: true,
                       cancellationToken: cancellationToken);
                }
                else if (item.type == "photo")
                {
                    await botClient.SendPhotoAsync(
                    chatId: update.Message.Chat.Id,
                       photo: InputFileUrl.FromUri(item.url),
                       cancellationToken: cancellationToken);
                }

            }
            if (!isEnter)
            {
                await botClient.SendVideoAsync(
                       chatId: update.Message.Chat.Id,
                       video: InputFileUrl.FromUri(update.Message.Text.Replace("www.", "dd")),
                       supportsStreaming: true,
                       cancellationToken: cancellationToken);
            }
        }
    }
}
