using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    // trackers to avoid repeats until all used
    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;

    public ReflectingActivity()
        : base("Reflecting Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // initialize unused trackers
        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine();
        Console.WriteLine("You may begin in: ");
        ShowCountDown(5); // give 5 seconds to prepare
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine();
            Console.Write($" - {question} ");
            ShowSpinner(4); // spinner while thinking
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    // returns a random prompt, avoiding repeats until all are used
    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
            _unusedPrompts = new List<string>(_prompts);

        int index = _rand.Next(_unusedPrompts.Count);
        string p = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return p;
    }

    // returns a random question, avoiding repeats until all are used
    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
            _unusedQuestions = new List<string>(_questions);

        int index = _rand.Next(_unusedQuestions.Count);
        string q = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);
        return q;
    }
}
