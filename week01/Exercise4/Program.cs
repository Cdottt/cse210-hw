using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();

        int userInputNumber = -1;
        
        while (userInputNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string userResponse = Console.ReadLine();
            userInputNumber = int.Parse(userResponse);
            
            if (userInputNumber != 0)
            {
                numbers.Add(userInputNumber);
            }
        }

        // Show Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Show Average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Show Largest Number
        int largestNumber = numbers[0];

        foreach (int number in numbers)
        {
            if (number > largestNumber)
            {
                largestNumber = number;
            }
        }

        Console.WriteLine($"The largest number is: {largestNumber}");

    }
}