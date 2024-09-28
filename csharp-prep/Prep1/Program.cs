using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their first name
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();  // Reads the first name input from the user

        // Prompt the user for their last name
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();  // Reads the last name input from the user

        // Display the name in the required format
        Console.WriteLine($"Your name is {last}, {first} {last}.");  // Output the name in the format
    }
}
