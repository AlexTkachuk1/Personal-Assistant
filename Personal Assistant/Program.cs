using Telegram.Bot;
using Telegram.Bot.Types;


var bot = new TelegramBotClient("6739379242:AAHvghOdD3vh7nu68o7VVMFvRcomhg_-_YI");

var me = await bot.GetMeAsync();
using var cts = new CancellationTokenSource();

bot.StartReceiving(HandleUpdateAsync, PollingErrorHandler, null, cts.Token);

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadKey();

async static Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
{
    var message = update.Message;
    if (message != null && message.Text != null)
    {
        await Console.Out.WriteLineAsync($"{message.Chat.Username} - {message.Text}");
        if (message.Text.ToLower().Contains("здорово"))
        {
            await client.SendTextMessageAsync(message.Chat.Id, "Здоровее видали");
            return;
        }
    }
}

async static Task PollingErrorHandler(ITelegramBotClient client, Exception exeption, CancellationToken token)
{
    await Console.Out.WriteLineAsync("Ошибочка");
    return;
}