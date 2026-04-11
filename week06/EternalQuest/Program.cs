using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // For this project, I wanted to go a little beyond the basic requirements.
        // I added a level system so the user can see growth as they keep working on their goals. I also added titles and badge milestones so progress feels more visible along the way, not just at the end.
        // I also added better input validation for menu choices and number entries so the program handles mistakes better and does not crash easily when the user types something invalid.

        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}