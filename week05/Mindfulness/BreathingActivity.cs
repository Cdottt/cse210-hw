using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        // alternate breathe in/out until time's up
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(4); // 4 second inhale
            Console.WriteLine();

            if (DateTime.Now >= endTime) break;

            Console.Write("Breathe out... ");
            ShowCountDown(6); // 6 second exhale
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
