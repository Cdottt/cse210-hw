using System;

        /*
         EXCEEDS REQUIREMENTS:
        - Added feature to check if enter is pressed accidentally when selecting menu options.
          If so, prompts user to make a valid selection instead of crashing.
        - Also added feature to calculate and display player level based on score. Shown when listing goals.
        */

class Program

{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
