using System;

//EXCCED REQUIREMENT: Program work with different scriptures rather than a single one. Choose scriptures at random.
class Program
{
    static void Main(string[] args)
    {
         List<Scripture> scriptureLibrary = new List<Scripture>()
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son," +
                " that whosoever believeth in him should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding." +
                " In all thy ways acknowledge him, and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("1 Nephi", 3, 7),
                "And it came to pass that I, Nephi, said unto my father:" +
                " I will go and do the things which the Lord hath commanded," +
                " for I know that the Lord giveth no commandments unto the children of men," +
                " save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
            )
        };

        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to stop.");

            string input = Console.ReadLine().Trim().ToLower();
            if (input == "quit")
                break;

            scripture.HideRandomWords(3);  

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Well done!");
                break;
            }
        }
    
    }
}