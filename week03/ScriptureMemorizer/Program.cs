using System;

class Program
{
    static void Main()
    {
        Reference scriptureReference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        Scripture scripture = new Scripture(scriptureReference, scriptureText);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideWords();
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}
