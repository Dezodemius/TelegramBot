using TelegramBot.Configuration;

namespace TelegramBot
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      var token = new BotConfigManager().GetSettings().Token;
      var botManager = new TelegramBotManager(token);
    }
  }
}
