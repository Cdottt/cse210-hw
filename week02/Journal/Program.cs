using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator _promptGen = new PromptGenerator();
        bool _running = true;

        Console.WriteLine("Welcome to the Journal Program!");
        
        while (_running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Exit");

            Console.Write("What would you like to do? ");
            string _choice = Console.ReadLine();

            switch (_choice)
            {
                case "1":
                    //Write a new journal entry
                    string _prompt = _promptGen.GetRandomPrompt(); //Show a random prompt
                    Console.WriteLine(_prompt);
                    Console.WriteLine("Please write your entry below:");
                    //Add the new entry to the journal with the current date
                    theJournal.AddEntry(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), _prompt, Console.ReadLine()));
                    Console.WriteLine("Entry added!");
                    break;
                case "2":
                    //Display all journal entries
                    theJournal.DisplayAll();
                    break;
                case "3":
                    //Load journal entries from a file
                    Console.WriteLine("Enter the filename to load from (ex. journal):");
                    string _loadFilename = Console.ReadLine();
                    theJournal.LoadFromFile(_loadFilename);
                    break;
                case "4":
                    //Save journal entries to a file
                    Console.WriteLine("Enter the filename to save to (ex. journal):");
                    string _saveFilename = Console.ReadLine();
                    theJournal.SaveToFile(_saveFilename);
                    break;
                case "5":
                    _running = false;
                    break;
                default:
                    //If the user enters an invalid choice
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

    }
}