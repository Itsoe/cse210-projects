using System;

class Program
{
    static void Main(string[] args)

    {   Console.WriteLine("Hello World! This is the Mindfulness Project.");


        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                ReturnToMenu();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                ReturnToMenu();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                ReturnToMenu();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter and try again.");
                Console.ReadLine();
            }
        }
    }

    static void ReturnToMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}