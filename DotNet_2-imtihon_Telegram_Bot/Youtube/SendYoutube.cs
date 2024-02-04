using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace DotNet_2_imtihon_Telegram_Bot.Youtube
{
    public class SendYoutube
    {
        public static async Task EssentialFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var url = "";
            string linkY = update.Message.Text;
            var uri = new Uri(linkY);
            var query = HttpUtility.ParseQueryString(uri.Query);
            if (query.AllKeys.Contains("v"))
            {
                url = query["v"];
            }
            else
            {
                url = uri.Segments.Last();
            }

            RootYoutube YoutubeVideoDownload = JsonConvert.DeserializeObject<RootYoutube>(YoutubeClass.RunApi(url).Result);

            await botClient.SendChatActionAsync(
                chatId: update.Message.Chat.Id,
                chatAction: ChatAction.UploadDocument,
                cancellationToken: cancellationToken);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(YoutubeVideoDownload.formats[1].url);
                if (response.IsSuccessStatusCode)
                {
                    byte[] videoContent = await response.Content.ReadAsByteArrayAsync();

                    await botClient.SendVideoAsync(
                       chatId: update.Message.Chat.Id,
                       video: InputFile.FromStream(new MemoryStream(videoContent)),
                       caption: "Formati : " + YoutubeVideoDownload.formats[1].qualityLabel + "\ntitle : " + YoutubeVideoDownload.title + "\nSeconds : " + YoutubeVideoDownload.lengthSeconds,
                       supportsStreaming: true,
                       cancellationToken: cancellationToken);
                }
            }

        }
    }
}
