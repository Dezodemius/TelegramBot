using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Settings;
using HomeworkService.DatabaseProvider;
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
      switch (message.Text.ToLower())
      {
        case BotCommand.Start:
        {
          await using var dbContext = new HomeworkDbContext(AppSettingsManager.Settings.ConnectionString);
          await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!", cancellationToken: cancellationToken);
          break;
        }
        case BotCommand.AddGroup:
        {
        }
        case BotCommand.AddStudent:
        {
          break;
        }
        case BotCommand.AddHomework:
        {
          break;
        }
        default:
          await botClient.SendTextMessageAsync(message.Chat, "Я не знаю такой команды.", cancellationToken: cancellationToken);
          break;
      }
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