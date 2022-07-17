using System.IO;
using YamlDotNet.Serialization.NamingConventions;

namespace TelegramBot.Configuration;

/// <summary>
/// Менеджер конфигом бота.
/// </summary>
public class BotConfigManager
{
  /// <summary>
  /// Имя файла с конфигом.
  /// </summary>
  private const string CONFIG_FILENAME = "botSettings.yml";

  /// <summary>
  /// Файл с конфигом.
  /// </summary>
  private readonly FileInfo configFile = new FileInfo(CONFIG_FILENAME);

  /// <summary>
  /// Получить настройки бота из файла.
  /// </summary>
  /// <returns>Настройки бота.</returns>
  public BotSettings GetSettings()
  {
    var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
      .IgnoreUnmatchedProperties()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .Build();
    return deserializer.Deserialize<BotSettings>(File.ReadAllText(this.configFile.FullName));
  }
}