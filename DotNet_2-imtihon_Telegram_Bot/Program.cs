using DotNet_2_imtihon_Telegram_Bot;

class Project
{
    static async Task Main(string[] args)
    {
        string link = "6970760432:AAHeRpC3tnHzISQmZ1l_9nRYI0MefjidEhM";

        BotHandler botHandler =new BotHandler(link);

        await botHandler.BotHandle();

        try
        {
            await botHandler.BotHandle();
        }
        catch
        {
            await botHandler.BotHandle();
        }
    }
}
