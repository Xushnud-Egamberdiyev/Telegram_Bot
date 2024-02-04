using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_2_imtihon_Telegram_Bot.Instagram
{
    public class InstagramClass
    {
        public static async Task<string> RunApi(string link)
        {
            string encodedUrl = WebUtility.UrlEncode(link);
            Console.WriteLine(encodedUrl);

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-downloader-download-instagram-videos-stories1.p.rapidapi.com/?url={encodedUrl}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "16e48dfbd2msh7371fe5e63f3af1p180fe6jsnee0363ed0461"  },
                    { "X-RapidAPI-Host", "instagram-downloader-download-instagram-videos-stories1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
