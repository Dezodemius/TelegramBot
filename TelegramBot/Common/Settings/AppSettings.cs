namespace Common.Settings;

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
  public string ConnectionString { get; set; }
}