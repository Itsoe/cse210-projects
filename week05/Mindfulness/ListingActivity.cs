using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _unusedPrompts;
    private Random _random;

    public ListingActivity()
        : base("Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _random = new Random();

        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");

        _unusedPrompts = new List<string>(_prompts);
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();

        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine();

        _count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (item != "")
            {
                _count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);

        return prompt;
    }
}