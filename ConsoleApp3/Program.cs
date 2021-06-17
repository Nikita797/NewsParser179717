using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Awesome 
{
  class Program
  {
    static ITelegramBotClient botClient;

    static void Main()
    {
      botClient = new TelegramBotClient("1843129045:AAGjJ8lSf95nDbP9j44UmnNQnf2urqC5ioo");

      var me = botClient.GetMeAsync().Result;
      Console.WriteLine(
        $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
      );

      botClient.OnMessage += Bot_OnMessage;
      botClient.StartReceiving();

      Console.WriteLine("Press any key to exit");
      Console.ReadKey();

      botClient.StopReceiving();
    }
    static async void Bot_OnMessage(object sender, MessageEventArgs e)
    {
      if (e.Message.Text == null) return;
      await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: await NewsParser.FindNews(e.Message.Text));
    }
  }
}
  
  