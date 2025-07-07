public class GradeSchool
{
    private readonly Dictionary<int, List<string>> _grades = new();
    private readonly Dictionary<string, int> _studentGrade = new();
    public bool Add(string student, int grade)
    {
        if (_studentGrade.ContainsKey(student))
        {
            return false;
        }

        if (!_grades.ContainsKey(grade))
        {
            _grades[grade] = new List<string>();
        }
        _grades[grade].Add(student);
        _studentGrade[student] = grade;

        return true;
    }

    public IEnumerable<string> Roster()
    {
        return _grades.OrderBy(g => g.Key).SelectMany(g => g.Value.OrderBy(name => name));
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (_grades.ContainsKey(grade))
        {
            return _grades[grade].OrderBy(name => name);
        }

        return Enumerable.Empty<string>();
    }
}