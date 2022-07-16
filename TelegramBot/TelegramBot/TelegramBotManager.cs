using Telegram.Bot;

namespace TelegramBot;

public class TelegramBotManager
{
  private readonly TelegramBotClient client;

  public TelegramBotManager(string token)
  {
    this.client = new TelegramBotClient(token);
  }
}