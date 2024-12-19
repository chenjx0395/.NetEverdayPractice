/* 
�� C# ����̨Ӧ�ó���ּ�ڣ�
- ʹ������洢ѧ����������ҵ������
- ʹ�� `foreach` �����Ϊ�ⲿ����ѭ������ѧ��������
- ���ⲿѭ����ʹ�� `if` �����ʶ��ǰѧ�����������ʸ�ѧ������ҵ������
- ���ⲿѭ����ʹ�� `foreach` ��������ҵ�������鲢��͡�
- ���ⲿѭ����ʹ���㷨������ÿ��ѧ����ƽ�����Է�����
- ���ⲿѭ����ʹ�� `if-elseif-else` �ṹ������ƽ�����Է������Զ�������ĸ�ȼ���
- �ڼ���ѧ�������շ�������ĸ�ȼ�ʱ���϶���ѧ�ַ�����������ʾ��
- ����ѧ�����������е�Ԫ������������ѧ����ҵ��
- ������ѧ����ҵ��ֵ���� 10��Ȼ�󽫶���ѧ�ַ�����ӵ����Է����ܺ��С�
- ʹ�����±����ʽ����ѧ���ɼ���

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

// ��ʾ����/�ɼ��ı�����
Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall Grade\tLetter Grade\n");

/*
�ⲿ foreach ѭ�����ڣ�
- ����ѧ������
- ��ѧ���ɼ������ѧ����������
- ������ҵ�����ܺͣ��ڲ� foreach ѭ����
- �������ֺ���ĸ�ȼ�
- ��д����������Ϣ
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
�ڲ� foreach ѭ������ҵ�����������
����ѧ����ҵռ���Գɼ��� 10%
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

// �� VS  ���������裨����������ڴ��Բ鿴�����
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();
