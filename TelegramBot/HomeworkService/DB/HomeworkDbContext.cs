using Microsoft.EntityFrameworkCore;

namespace HomeworkService.DB;

/// <summary>
/// Контекст для работы с БД.
/// </summary>
public sealed class HomeworkDbContext : DbContext
{
  #region Поля и свойства.

  /// <summary>
  /// Строка подключения к БД.
  /// </summary>
  private readonly string connectionString;

  /// <summary>
  /// Данные о студентах.
  /// </summary>
  public DbSet<Student> Students { get; set; }

  /// <summary>
  /// Данные о группах.
  /// </summary>
  public DbSet<Group> Groups { get; set; }

  /// <summary>
  /// Данные о заданиях.
  /// </summary>
  public DbSet<HomeTask> HomeTasks { get; set; }

  #endregion

  #region Базовый класс

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite(this.connectionString);
  }

  #endregion


  #region Методы

  /// <summary>
  /// Выполнить команду с последующим сохранением.
  /// </summary>
  /// <param name="action">Действие.</param>
  public void ExecuteCommandWithSave(Action action)
  {
    try
    {
      action();
      this.SaveChanges();
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="connectionString">Строка подключения.</param>
  public HomeworkDbContext(string connectionString)
  {
    this.connectionString = connectionString;
    Database.EnsureCreated();
  }

  #endregion

}