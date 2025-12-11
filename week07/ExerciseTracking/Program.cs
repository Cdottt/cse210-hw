using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("11 Dec 2025", 40, 21));
        activities.Add(new Cycling("11 Dec 2025", 240, 15, 100));
        activities.Add(new Swimming("11 Dec 2025", 30, 40));

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
