using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_2_imtihon_Telegram_Bot.Youtube
{
    public class AdaptiveFormat
    {
        public int itag { get; set; }
        public string url { get; set; }
        public string mimeType { get; set; }
        public int bitrate { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public InitRange initRange { get; set; }
        public IndexRange indexRange { get; set; }
        public string lastModified { get; set; }
        public string contentLength { get; set; }
        public string quality { get; set; }
        public int fps { get; set; }
        public string qualityLabel { get; set; }
        public string projectionType { get; set; }
        public int averageBitrate { get; set; }
        public string approxDurationMs { get; set; }
        public ColorInfo colorInfo { get; set; }
        public bool? highReplication { get; set; }
        public string audioQuality { get; set; }
        public string audioSampleRate { get; set; }
        public int? audioChannels { get; set; }
        public double? loudnessDb { get; set; }
    }

    public class ColorInfo
    {
        public string primaries { get; set; }
        public string transferCharacteristics { get; set; }
        public string matrixCoefficients { get; set; }
    }

    public class Format
    {
        public int itag { get; set; }
        public string url { get; set; }
        public string mimeType { get; set; }
        public int bitrate { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string lastModified { get; set; }
        public string quality { get; set; }
        public int fps { get; set; }
        public string qualityLabel { get; set; }
        public string projectionType { get; set; }
        public string audioQuality { get; set; }
        public string approxDurationMs { get; set; }
        public string audioSampleRate { get; set; }
        public int audioChannels { get; set; }
    }

    public class IndexRange
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class InitRange
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class RootYoutube
    {
        public string status { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string lengthSeconds { get; set; }
        public List<string> keywords { get; set; }
        public string channelTitle { get; set; }
        public string channelId { get; set; }
        public string description { get; set; }
        public List<Thumbnail> thumbnail { get; set; }
        public bool allowRatings { get; set; }
        public string viewCount { get; set; }
        public bool isPrivate { get; set; }
        public bool isUnpluggedCorpus { get; set; }
        public bool isLiveContent { get; set; }
        public string expiresInSeconds { get; set; }
        public List<Format> formats { get; set; }
        public List<AdaptiveFormat> adaptiveFormats { get; set; }
        public string pmReg { get; set; }
        public bool isProxied { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
