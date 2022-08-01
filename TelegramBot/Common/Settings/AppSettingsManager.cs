using YamlDotNet.Serialization.NamingConventions;

namespace Common.Settings;

/// <summary>
/// Менеджер конфига приложения.
/// </summary>
public static class AppSettingsManager
{
  /// <summary>
  /// Настройки из конфига.
  /// </summary>
  public static AppSettings Settings { get; }

  /// <summary>
  /// Имя файла с конфигом.
  /// </summary>
  private const string CONFIG_FILENAME = "botSettings.yml";

  /// <summary>
  /// Файл с конфигом.
  /// </summary>
  private static readonly FileInfo configFile = new FileInfo(CONFIG_FILENAME);

  /// <summary>
  /// Получить настройки из файла.
  /// </summary>
  /// <returns>Настройки.</returns>
  private static AppSettings GetSettings()
  {
    var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
      .IgnoreUnmatchedProperties()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .Build();
    return deserializer.Deserialize<AppSettings>(File.ReadAllText(configFile.FullName));
  }

  static AppSettingsManager()
  {
    Settings = GetSettings();
  }
}