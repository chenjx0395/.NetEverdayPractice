/* 
此 C# 控制台应用程序旨在：
- 使用数组存储学生姓名和作业分数。
- 使用 `foreach` 语句作为外部程序循环遍历学生姓名。
- 在外部循环中使用 `if` 语句来识别当前学生姓名并访问该学生的作业分数。
- 在外部循环中使用 `foreach` 语句遍历作业分数数组并求和。
- 在外部循环中使用算法来计算每个学生的平均考试分数。
- 在外部循环中使用 `if-elseif-else` 结构来评估平均考试分数并自动分配字母等级。
- 在计算学生的最终分数和字母等级时整合额外学分分数，如下所示：
- 根据学生分数数组中的元素数量检测额外学分作业。
- 将额外学分作业的值除以 10，然后将额外学分分数添加到考试分数总和中。
- 使用以下报告格式报告学生成绩：

    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-
*/
int examAssignments = 5;

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

int[] studentScores = new int[10];

string currentStudentLetterGrade = "";
int currentStudentExamScore = 0;
int currentStudentExtraCredit = 0;

// 显示分数/成绩的标题行
Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall Grade\tLetter Grade\n");

/*
外部 foreach 循环用于：
- 遍历学生姓名
- 将学生成绩分配给学生分数数组
- 计算作业分数总和（内部 foreach 循环）
- 计算数字和字母等级
- 编写分数报告信息
*/
foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;

    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;

    else if (currentStudent == "Logan")
        studentScores = loganScores;

    int sumAssignmentScores = 0;

    decimal currentStudentGrade = 0;

    int gradedAssignments = 0;

/* 
内部 foreach 循环对作业分数进行求和
额外学分作业占考试成绩的 10%
*/
    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
            sumAssignmentScores += score;

        else
            sumAssignmentScores += score / 10;
    }

    currentStudentGrade = (decimal)(sumAssignmentScores) / examAssignments;

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

    // Student         Grade
    // Sophia:         92.2    A-
    
    Console.WriteLine($"{currentStudent}\t\t{currentStudentExamScore}\t\t{currentStudentGrade}\t{currentStudentLetterGrade}\t{currentStudentExtraCredit}(0 pts)");
}

// 在 VS  中运行所需（保持输出窗口打开以查看结果）
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();
