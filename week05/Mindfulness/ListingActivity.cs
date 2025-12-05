using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _items; // items entered by user
    private List<string> _unusedPrompts; // to avoid repeats until all used

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _items = new List<string>();
        _unusedPrompts = new List<string>(_prompts);
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("You may begin in: ");
        ShowCountDown(5); // give 5 seconds to prepare
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                _items.Add(input.Trim());
            }
            // loop will check time again; user may still be typing when time expires.
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {_items.Count} items:");
        foreach (var it in _items)
        {
            Console.WriteLine($" - {it}");
        }

        DisplayEndingMessage();
        // clear items for next session
        _items.Clear();
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
            _unusedPrompts = new List<string>(_prompts);

        int index = _rand.Next(_unusedPrompts.Count);
        string p = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return p;
    }
}
