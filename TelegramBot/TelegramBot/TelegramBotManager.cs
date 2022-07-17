using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot;

/// <summary>
/// Telegram-bot manager.
/// </summary>
public class TelegramBotManager
{
  #region Fields and Properties

  /// <summary>
  /// Клиент для работы с телеграмом.
  /// </summary>
  private readonly TelegramBotClient client;

  #endregion

  #region Methods

  /// <summary>
  /// Обработчик команд бота.
  /// </summary>
  /// <param name="botClient">Бот клиент.</param>
  /// <param name="update">Обновление.</param>
  /// <param name="cancellationToken">Отменяющий токен.</param>
  private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, 
    CancellationToken cancellationToken)
  {
    Console.WriteLine(JsonConvert.SerializeObject(update));
    if(update.Type == UpdateType.Message)
    {
      var message = update.Message;
      if (message.Text.ToLower() == "/start")
      {
        await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!", cancellationToken: cancellationToken);
        return;
      }
      await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!", cancellationToken: cancellationToken);
    }
  }

  /// <summary>
  /// Обработчик получения ошибок от бота.
  /// </summary>
  /// <param name="botClient">Бот клиент.</param>
  /// <param name="exception">Исключение.</param>
  /// <param name="cancellationToken">Отменяющий токен.</param>
  private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
    CancellationToken cancellationToken)
  {
    Console.WriteLine(JsonConvert.SerializeObject(exception));
  }

  /// <summary>
  /// Стартовать бота.
  /// </summary>
  /// <param name="cancellationToken">Отменяющий токен.</param>
  public void StartBot(CancellationToken cancellationToken)
  {
    var receiverOpts = new ReceiverOptions
    {
        AllowedUpdates = { }
    };
    this.client.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOpts, cancellationToken);
  }

    #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="token">Токен для бота.</param>
  public TelegramBotManager(string token)
  {
    this.client = new TelegramBotClient(token);
  }

  #endregion
}