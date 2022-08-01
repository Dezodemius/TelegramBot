using System;
using System.Threading;
using Common.Settings;

namespace TelegramBot
{
  /// <summary>
  /// Точка входа в программу.
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// Главный метод программы.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    public static void Main(string[] args)
    {
      var botManager = new TelegramBotManager(AppSettingsManager.Settings.Token);

      var cts = new CancellationTokenSource();
      botManager.StartBot(cts.Token);
      WaitForExit(cts);
    }

    private static void WaitForExit(CancellationTokenSource cts)
    {
      var isWaitingForExit = true;
      while (isWaitingForExit)
      {
        if (cts.IsCancellationRequested)
          Environment.Exit(1);
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Escape)
          isWaitingForExit = false;
      }
      Environment.Exit(0);
    }
  }
}
