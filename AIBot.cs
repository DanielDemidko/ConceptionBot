using System;
using System.Threading;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

class AIBot
{
    private readonly TelegramBotClient Bot;
    private readonly ExperienceMemory Experience;
    TrigersMemory Triggers;
    Action<String> Logger;

    private static readonly Random Randomizer = new Random();

    private void BotOnMessage(Object sender, MessageEventArgs e)
    {
        if (e.Message.Type != MessageType.TextMessage)
        {
            return;
        }
        // log
        Logger?.Invoke($"@{e.Message.From.Username}: {e.Message.Text}");
        if (Triggers.IsTrigger(e.Message.Text))
        {
            Thread.Sleep(TimeSpan.FromSeconds(10 + Randomizer.Next(20)));
            var aswer = Experience.GetAnswer(e.Message.Text);
            Bot.SendTextMessageAsync(e.Message.Chat.Id, $"@{e.Message.From.Username} {aswer}");
            // log
            Logger?.Invoke($"@{Name}: {e.Message.Text}");
        }
    }

    public String Name => Bot.GetMeAsync().Result.Username;


    public AIBot(String accessToken, String memoryPath, String triggersPath, Action<String> log = null)
    {
        Bot = new TelegramBotClient(accessToken);
        Experience = new ExperienceMemory(memoryPath);
        Triggers = new TrigersMemory(triggersPath);
        Logger = log;
        Bot.OnMessage += BotOnMessage;
        Bot.StartReceiving();
    }
}
