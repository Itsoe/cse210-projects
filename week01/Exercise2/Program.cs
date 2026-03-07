using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.WriteLine("What is your grade percentage?");
        string gradePercentage = Console.ReadLine();
        int grade = int.Parse(gradePercentage);

        string letterGrade = "";
        string sign = "";

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        
        int lastDigit = grade % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        if (letterGrade == "A" && sign == "+")
        {
            sign = "";
        }
        else if (letterGrade == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letterGrade}{sign}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed.");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass. Better luck next time!");
        }
    }
}