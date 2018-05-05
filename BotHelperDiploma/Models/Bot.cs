using BotHelperDiploma.Models.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

using Telegram.Bot;

namespace BotHelperDiploma.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandList;


        public static IReadOnlyList<Command> Commands { get => commandList.AsReadOnly(); }

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandList = new List<Command>();
            commandList.Add(new HelloCommand());
            commandList.Add(new TestCommand());

            //TODO: more commands init here

            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url);
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}