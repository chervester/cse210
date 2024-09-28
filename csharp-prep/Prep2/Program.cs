using System;

class Program
{
    static void Main(string[] args)
    {
        // Core requirement: Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input); // Convert the input to an integer

        string letter = "";  // Variable to store the letter grade
        string sign = "";    // Variable to store the + or - sign

        // Determine the letter grade based on the percentage
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (+, -, or nothing) only if the grade is not "A" or "F"
        if (letter != "A" && letter != "F")
        {
            int lastDigit = percentage % 10; // Get the last digit of the percentage

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = ""; // No sign for middle-range grades
            }
        }

        // Handle the case where there is no A+ grade, only A or A-
        if (letter == "A" && percentage >= 90 && percentage < 93)
        {
            sign = "-";
        }

        // Handle the case where there is no F+ or F-, only F
        if (letter == "F")
        {
            sign = ""; // No sign for F
        }

        // Print the final letter grade with sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Check if the user passed (70 or above)
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up, better luck next time!");
        }
    }
}
