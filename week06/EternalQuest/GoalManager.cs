using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public GoalManager()
    {
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = ReadInt("Select a choice from the menu: ", 1);
            Console.WriteLine();

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;   
                case 6: Console.WriteLine("Quitting..."); break;
                default: Console.WriteLine("Invalid choice. Please select a valid option."); break;
            }
            
        }
    }

    // Check if input is non-empty string
    private string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input == null) input = "";
            input = input.Trim();
            if (!string.IsNullOrWhiteSpace(input))
                return input;
            Console.WriteLine("Input cannot be empty. Please try again.");
        }
    }

    // Check if input is non-empty integer
    private int ReadInt(string prompt, int min = int.MinValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input == null) input = "";
            input = input.Trim();

            // If user input is empty, check again
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please enter a number.");
                continue;
            }

            if (int.TryParse(input, out int value))
            {
                if (value >= min)
                    return value;

                Console.WriteLine($"Please enter a number greater than or equal to {min}.");
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter an integer.");
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int type = ReadInt("Which type do you want to create? (1-3): ", 1);
        while (type < 1 || type > 3)
        {
            Console.WriteLine("Please enter 1, 2, or 3.");
            type = ReadInt("Which type do you want to create? (1-3): ", 1);
        }

        string name = ReadNonEmptyString("Name: ");
        string description = ReadNonEmptyString("Description: ");

        int points = ReadInt("Points (integer): ", 0);

        if (type == 1) // SimpleGoal
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("Simple goal created.");
        }
        else if (type == 2) // EternalGoal
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine("Eternal goal created.");
        }
        else if (type == 3) // ChecklistGoal
        {
            int target = ReadInt("Target (how many times to complete to finish): ", 1);
            int bonus = ReadInt("Bonus points on completion (integer): ", 0);
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine("Checklist goal created.");
        }
    }

    public void ListGoalDetails()
    {
        // calculate level based on score
        int level = _score / 100; // 1 level per 100 points
        Console.WriteLine($"You are now Level {level}!");
        
        Console.WriteLine("\nYour Goals:");
        int index = 1;

        foreach (Goal g in _goals)
        {
            string status = g.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{index}. {status} {g.GetDetailsString()}");
            index++;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        ListGoalDetails();
        Console.Write("Enter number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count) return;

        int before = _score;
        _goals[index].RecordEvent();
        int after = before;

        if (_goals[index] is ChecklistGoal cg)
        {
            if (cg.IsComplete())
                _score += cg.Points + 500; 
            else
                _score += cg.Points;
        }
        else
        {
            _score += _goals[index].Points;
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save (ex. goals.txt): ");
        string filename = Console.ReadLine().Trim();

        if (string.IsNullOrEmpty(filename))
        {
            Console.WriteLine("Save cancelled (no filename given).");
            return;
        }

        // make sure .txt extension
        if (Path.GetExtension(filename) == string.Empty)
        {
            filename = filename + ".txt";
        }

        string path = Path.Combine(Directory.GetCurrentDirectory(), filename);

        try
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                // First line: score
                writer.WriteLine(_score);

                // Then each goal as a single line string representation
                foreach (Goal g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Goals saved to: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        // show folder directory
        string folder = Directory.GetCurrentDirectory();
        Console.WriteLine($"Note: files are loaded from the program folder: {folder}");

        while (true)
        {
            Console.Write("Enter filename to load (e.g. goals.txt) or type 'cancel' to return: ");
            string filename = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("No filename entered. Load cancelled.");
                return;
            }

            if (filename.Trim().ToLower() == "cancel")
            {
                Console.WriteLine("Load cancelled.");
                return;
            }

            if (Path.GetExtension(filename) == string.Empty)
            {
                filename = filename + ".txt";
            }

            string path = Path.Combine(folder, filename);

            if (!File.Exists(path))
            {
                Console.WriteLine($"File not found: {path}");
                Console.Write("Would you like to try another filename? (y/n): ");
                string tryAgain = Console.ReadLine().Trim().ToLower();
                if (tryAgain == "y" || tryAgain == "yes")
                {
                    continue; // loop again and prompt for filename
                }
                else
                {
                    Console.WriteLine("Load cancelled.");
                    return;
                }
            }

            try
            {
                string[] lines = File.ReadAllLines(path);
                if (lines.Length == 0)
                {
                    Console.WriteLine("File is empty. Load cancelled.");
                    return;
                }

                _goals.Clear();

                // first line should be score
                if (!int.TryParse(lines[0], out _score))
                {
                    Console.WriteLine("Invalid score in file. Load cancelled.");
                    return;
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');
                    string type = parts[0];

                    if (type == "SimpleGoal")
                    {
                        // Expected format: SimpleGoal|name|description|points|isComplete
                        var g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        
                        if (parts.Length > 4 && bool.TryParse(parts[4], out bool isComplete) && isComplete)
                        {
                            typeof(SimpleGoal)
                                .GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                .SetValue(g, true);
                        }
                        _goals.Add(g);
                    }
                    else if (type == "EternalGoal")
                    {
                        // Expected: EternalGoal|name|description|points
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    }
                    else if (type == "ChecklistGoal")
                    {
                        // Expected: ChecklistGoal|name|description|points|amountCompleted|target|bonus
                        var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                        // restore progress
                        if (parts.Length > 4 && int.TryParse(parts[4], out int amt))
                        {
                            typeof(ChecklistGoal)
                                .GetField("_amountCompleted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                .SetValue(cg, amt);
                        }
                        _goals.Add(cg);
                    }
                    else
                    {
                        Console.WriteLine($"Unknown goal type in file: {type} (line {i+1})");
                    }
                }

                Console.WriteLine("Goals loaded successfully.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                return;
            }
        }
    }
}
