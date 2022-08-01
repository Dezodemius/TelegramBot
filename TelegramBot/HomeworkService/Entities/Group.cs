namespace HomeworkService;

/// <summary>
/// Группа студентов.
/// </summary>
public class Group
{
  /// <summary>
  /// ИД группы.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Название группы.
  /// </summary>
  public string GroupName { get; set; }

  /// <summary>
  /// Организация, в которой обучается группа.
  /// </summary>
  public string Organization { get; set; }
}