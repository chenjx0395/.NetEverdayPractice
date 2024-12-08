using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

// 学科总量
int currentAssignments = 5;

//学生数组
string[] students = { "Sophia", "Andrew", "Emma", "Logan" };

int[] sophiaGrades = { 90, 86, 87, 98, 100 };
int[] andrewGrades = { 92, 89, 81, 96, 90 };
int[] emmaGrades = { 90, 85, 87, 98, 68 };
int[] loganGrades = { 90, 95, 87, 88, 96 };


Console.WriteLine("Student\t\tGrade\n");
// 存储学生的成绩
int[] studentScores = new int[10];
foreach (string name in students)
{
    string currentStudent = name;
    string currentStudentLetterGrade;

    if (currentStudent == "Sophia")
        studentScores = sophiaGrades;

    else if (currentStudent == "Andrew")
        studentScores = andrewGrades;

    else if (currentStudent == "Emma")
        studentScores = emmaGrades;

    else if (currentStudent == "Logan")
        studentScores = loganGrades;

    int studentSum = 0;

    decimal currentStudentGrade;

    foreach (int score in studentScores)
    {
        studentSum += score;

    }
    currentStudentGrade = (decimal)studentSum / currentAssignments;
    // 分配等级
    if (currentStudentGrade >= 97)
        currentStudentLetterGrade = "A+";

    else if (currentStudentGrade >= 93)
        currentStudentLetterGrade = "A";

    else if (currentStudentGrade >= 90)
        currentStudentLetterGrade = "A-";

    else if (currentStudentGrade >= 87)
        currentStudentLetterGrade = "B+";

    else if (currentStudentGrade >= 83)
        currentStudentLetterGrade = "B";

    else if (currentStudentGrade >= 80)
        currentStudentLetterGrade = "B-";

    else if (currentStudentGrade >= 77)
        currentStudentLetterGrade = "C+";

    else if (currentStudentGrade >= 73)
        currentStudentLetterGrade = "C";

    else if (currentStudentGrade >= 70)
        currentStudentLetterGrade = "C-";

    else if (currentStudentGrade >= 67)
        currentStudentLetterGrade = "D+";

    else if (currentStudentGrade >= 63)
        currentStudentLetterGrade = "D";

    else if (currentStudentGrade >= 60)
        currentStudentLetterGrade = "D-";
    else
        currentStudentLetterGrade = "F";

    Console.WriteLine($"{name}:\t\t {currentStudentGrade} {currentStudentLetterGrade}\t");

}

decimal andrewScore;
decimal emmaScore;
decimal loganScore;




Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();
