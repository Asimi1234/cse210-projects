using System;

class GuessMyNumberGame
{
    static void Main()
    {
        Random randomGenerator = new Random();
        string playAgain = "yes";
        
        // Game loop
        while (playAgain == "yes")
        {
            
            int magicNumber = randomGenerator.Next(1, 101);  
            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Welcome to Guess My Number!");

            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Thanks for playing!");
    }
}
