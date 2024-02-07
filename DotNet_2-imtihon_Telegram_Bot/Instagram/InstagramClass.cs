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
                    { "X-RapidAPI-Key",  "f927051de5msh33c089150223b61p1e384ajsn0b24f85919fd"},
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
