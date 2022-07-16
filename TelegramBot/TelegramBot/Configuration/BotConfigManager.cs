using System.IO;
using YamlDotNet.Serialization.NamingConventions;

namespace TelegramBot.Configuration;

public class BotConfigManager
{
  private const string CONFIG_FILENAME = "botSettings.yml";

  private readonly FileInfo configFile = new FileInfo(CONFIG_FILENAME);

  public BotSettings GetSettings()
  {
    var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
        .IgnoreUnmatchedProperties()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();
    return deserializer.Deserialize<BotSettings>(File.ReadAllText(this.configFile.FullName));
  }
}