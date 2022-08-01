namespace HomeworkService;

/// <summary>
/// Студент.
/// </summary>
public class Student
{
  /// <summary>
  /// ID студента.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Полное имя студента.
  /// </summary>
  public string FullName { get; set; }

  /// <summary>
  /// Никнейм студента.
  /// </summary>
  public string Nickname { get; set; }

  /// <summary>
  /// Группа студента.
  /// </summary>
  public Group Group { get; set;  }
}