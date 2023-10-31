using System; using System.IO;

namespace assignment3;

class Student
{
    public string Name { get; set; }
    public int ExamScore { get; set; }
    public string Grade { get; set; }

    public Student(string name, int examScore)
    {
        Name = name;
        ExamScore = examScore;
        Grade = CalculateGrade(examScore);
    }

    private string CalculateGrade(int score)
    {
        if (score >= 90) return "A";
        else if (score >= 70 && score < 90) return "B";
        else if (score >= 50 && score < 70) return "C";
        else if (score >= 40 && score < 50) return "D";
        else return "F";
    }
}