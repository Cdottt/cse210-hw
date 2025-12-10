using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
         EXCEEDS REQUIREMENTS:

         Added feature to ensure no prompt in ReflectingActivity repeats until all items have been used at least once
         during the session.
        */

        List<Activity> activities = new List<Activity>()
        {
            new BreathingActivity(),
            new ReflectingActivity(),
            new ListingActivity()
        };

        while (true)
        {
            ShowMenu();
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "4" || choice.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            if (choice == "1" || choice == "2" || choice == "3")
            {
                int idx = int.Parse(choice) - 1;
                activities[idx].Run();
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to menu..."); // pause before showing menu again
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Quit");
        Console.WriteLine();
    }
}
