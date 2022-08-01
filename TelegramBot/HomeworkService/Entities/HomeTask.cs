namespace HomeworkService;

/// <summary>
/// Домашнее задание.
/// </summary>
public class HomeTask
{
  /// <summary>
  /// ИД задания.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Текст задания.
  /// </summary>
  public string Text { get; set; }

  /// <summary>
  /// Оценка за задание.
  /// </summary>
  public Grade Grade { get; set; }

  /// <summary>
  /// Дата выдачи задания.
  /// </summary>
  public DateTime StartDate { get; set; }

  /// <summary>
  /// Дата сдачи задания.
  /// </summary>
  public DateTime CheckDate { get; set; }

  /// <summary>
  /// Срок выполнения задания.
  /// </summary>
  public DateTime DueDate { get; set; }
}

