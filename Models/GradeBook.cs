namespace Encapsulation.Models;

class GradeBook
{
    public string StudentName { get; private set; }
    private int[] _grades;
    public int[] Grades
    {
        get => _grades;
        private set => _grades = value;
    }

    public GradeBook(string studentName, int[] grades)
    {
        StudentName = studentName;
        _grades = new int[grades.Length];
        Array.Copy(grades, _grades, grades.Length);
    }

}