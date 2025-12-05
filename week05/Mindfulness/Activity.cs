using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration; // seconds
    protected static readonly Random _rand = new Random();

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // common behavior: start message
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        SetDuration();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // common behavior: ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of {_name}.");
        ShowSpinner(3);
    }

    // ask user for duration (in seconds)
    public void SetDuration()
    {
        int seconds = 0;
        while (true)
        {
            Console.Write("How long in seconds would you like for your session? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out seconds) && seconds > 0)
            {
                _duration = seconds;
                break;
            }
            Console.WriteLine("Please enter a positive integer for seconds.");
        }
    }

    // expose duration to derived classes
    protected int GetDuration()
    {
        return _duration;
    }

    // spinner animation for n seconds
    public void ShowSpinner(int seconds)
    {
        string[] sequence = new string[] { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(sequence[i % sequence.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    // countdown animation: shows numbers from seconds down to 1
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // a short pause helper (using spinner)
    protected void PauseSeconds(int seconds)
    {
        ShowSpinner(seconds);
    }

    // main activity behavior implemented by derived classes
    public abstract void Run();
}
