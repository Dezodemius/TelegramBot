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
  /// Дата выдачи задания.
  /// </summary>
  public DateTime StartDate { get; set; }

  /// <summary>
  /// Срок выполнения задания.
  /// </summary>
  public DateTime DueDate { get; set; }
}

