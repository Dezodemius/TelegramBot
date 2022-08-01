namespace TelegramBot.Configuration;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Токен телеграм-бота.
  /// </summary>
  public string Token { get; set; }

  /// <summary>
  /// Строка подключения к БД.
  /// </summary>
  public string SqlConnectionString { get; set; }
}