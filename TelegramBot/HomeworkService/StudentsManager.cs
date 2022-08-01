using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace HomeworkService;

/// <summary>
/// Менеджер студентами.
/// </summary>
public class StudentsManager
{
  #region Поля и свойства.

  /// <summary>
  /// Список студентов.
  /// </summary>
  private List<Student> students;

  private readonly Lazy<StudentsManager> instance = new (() => new StudentsManager());

  #endregion

  #region Методы

  /// <summary>
  /// Экземпляр класса.
  /// </summary>
  public StudentsManager Instance => this.instance.Value;

  /// <summary>
  /// Добавить студента.
  /// </summary>
  /// <param name="student">Студент.</param>
  public void AddStudent(Student student)
  {
    this.students.Add(student);
  }

  /// <summary>
  /// Удалить студента.
  /// </summary>
  /// <param name="student">Студент.</param>
  public void RemoveStudent(Student student)
  {
    this.students.Remove(student);
  }

  /// <summary>
  /// Удалить студента.
  /// </summary>
  /// <param name="index">Индекс студента в списке студентов.</param>
  public void RemoveStudent(int index)
  {
    this.students.RemoveAt(index);
  }

  /// <summary>
  /// Получить студента.
  /// </summary>
  /// <param name="index">Индекс студента в списке студентов.</param>
  /// <returns>Найденный студент.</returns>
  public Student GetStudent(int index)
  {
    return this.students[index];
  }

  /// <summary>
  /// Посчитать количество студентов.
  /// </summary>
  /// <returns>Количество студентов.</returns>
  public int GetStudentsCount()
  {
    return this.students.Count;
  }

  /// <summary>
  /// Получить список всех студентов.
  /// </summary>
  /// <returns>Список всех студентов.</returns>
  public List<Student> GetStudents()
  {
    return this.students;
  }

  /// <summary>
  /// Очистить список студентов.
  /// </summary>
  public void DeleteAllStudents()
  {
    this.students.Clear();
  }

  /// <summary>
  /// Удалить студента.
  /// </summary>
  /// <param name="student">Студент.</param>
  public void DeleteStudent(Student student)
  {
    this.students.Remove(student);
  }

  /// <summary>
  /// Удалить студента по ID.
  /// </summary>
  /// <param name="id">ID студента.</param>
  public void DeleteStudent(Guid id)
  {
    var studentToDelete = this.students.Single(s => s.Id == id);
    this.DeleteStudent(studentToDelete);
  }

    #endregion

  #region Конструкторы.

  /// <summary>
  /// Конструктро.
  /// </summary>
  private StudentsManager()
  {
    this.students = new List<Student>();
  }

  #endregion
}