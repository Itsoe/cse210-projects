using System;

class Program
{
    static void Main(string[] args)
    {
        // The additional things I did to Exceed the requirements:
        // I added a mood rating to each journal entry. The user now rates the day from 1 to 5, and that mood is
        // displayed, saved to the file, and loaded back from the file.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Write");
            Console.WriteLine("  2. Display");
            Console.WriteLine("  3. Load");
            Console.WriteLine("  4. Save");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string answer = Console.ReadLine();

                Console.Write("How would you rate your day from 1 to 5? ");
                string mood = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = answer;
                entry._mood = mood;

                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                Console.WriteLine();
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye, thank you!");
            }
            else
            {
                Console.WriteLine("You entered an invalid choice.");
            }

            Console.WriteLine();
        }
    }
}
