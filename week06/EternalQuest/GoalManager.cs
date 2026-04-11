using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool isRunning = true;

        while (isRunning)
        {
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            int choice = PromptForInt("Select a choice from the menu: ");

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid menu option.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {GetLevel()}");
        Console.WriteLine($"Title: {GetTitle()}");
        Console.WriteLine($"Badges: {GetBadges()}");
        Console.WriteLine("----------------------------------------");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int goalType = PromptForInt("Which type of goal would you like to create? ");

        if (goalType < 1 || goalType > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = PromptForInt("What is the amount of points associated with this goal? ");

        if (goalType == 1)
        {
            Goal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (goalType == 2)
        {
            Goal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (goalType == 3)
        {
            int target = PromptForInt("How many times does this goal need to be accomplished to be complete? ");
            int bonus = PromptForInt("What is the bonus for accomplishing it that many times? ");

            Goal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }

        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        int goalNumber = PromptForInt("Which goal did you accomplish? ");
        int goalIndex = goalNumber - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int oldScore = _score;
        int oldLevel = GetLevel();

        int pointsEarned = _goals[goalIndex].RecordEvent();
        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points.");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("That goal is already complete, so no points were earned.");
        }

        int newLevel = GetLevel();

        if (newLevel > oldLevel)
        {
            Console.WriteLine($"Nice work. You leveled up to Level {newLevel}.");
        }

        ShowNewBadges(oldScore, _score);
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        _goals.Clear();

        string[] firstLineParts = lines[0].Split("|");

        if (firstLineParts.Length == 2 && firstLineParts[0] == "Score")
        {
            _score = int.Parse(firstLineParts[1]);
        }
        else
        {
            Console.WriteLine("The file format is invalid.");
            return;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            Goal goal = CreateGoalFromSavedData(parts);

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private Goal CreateGoalFromSavedData(string[] parts)
    {
        string goalType = parts[0];

        if (goalType == "SimpleGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);

            return new SimpleGoal(name, description, points, isComplete);
        }
        else if (goalType == "EternalGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            return new EternalGoal(name, description, points);
        }
        else if (goalType == "ChecklistGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            int target = int.Parse(parts[4]);
            int bonus = int.Parse(parts[5]);
            int amountCompleted = int.Parse(parts[6]);

            return new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
        }

        return null;
    }

    private int PromptForInt(string prompt)
    {
        int value;
        bool isValid = false;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out value);

            if (!isValid)
            {
                Console.WriteLine("Please enter a valid whole number.");
            }

        } while (!isValid);

        return value;
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private string GetTitle()
    {
        if (_score >= 10000)
        {
            return "Quest Master";
        }
        else if (_score >= 6000)
        {
            return "Disciplined Finisher";
        }
        else if (_score >= 3000)
        {
            return "Consistent Builder";
        }
        else if (_score >= 1000)
        {
            return "Steady Climber";
        }
        else
        {
            return "Beginner";
        }
    }

    private string GetBadges()
    {
        List<string> badges = new List<string>();

        if (_score >= 1000)
        {
            badges.Add("First Milestone");
        }

        if (_score >= 3000)
        {
            badges.Add("Focused");
        }

        if (_score >= 6000)
        {
            badges.Add("Consistent");
        }

        if (_score >= 10000)
        {
            badges.Add("Quest Master");
        }

        if (badges.Count == 0)
        {
            return "None yet";
        }

        return string.Join(", ", badges);
    }

    private void ShowNewBadges(int oldScore, int newScore)
    {
        if (oldScore < 1000 && newScore >= 1000)
        {
            Console.WriteLine("New badge unlocked: First Milestone");
        }

        if (oldScore < 3000 && newScore >= 3000)
        {
            Console.WriteLine("New badge unlocked: Focused");
        }

        if (oldScore < 6000 && newScore >= 6000)
        {
            Console.WriteLine("New badge unlocked: Consistent");
        }

        if (oldScore < 10000 && newScore >= 10000)
        {
            Console.WriteLine("New badge unlocked: Quest Master");
        }
    }
}