using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes"; // Variable to control the game loop

        while (playAgain == "yes")
        {
            // Generate a random number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1; // Initialize the guess variable
            int guessCount = 0; // To count the number of guesses

            // Loop until the guess matches the magic number
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine()); // Read the user's guess
                guessCount++; // Increment the guess count

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower(); // Convert the response to lowercase
        }

        Console.WriteLine("Thanks for playing!"); // End message
    }
}
