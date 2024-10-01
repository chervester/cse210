using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Entry
{
    public DateTime Date { get; private set; } // Keeps track of when the entry was created
    public string Prompt { get; private set; } // The prompt for the entry
    public string Response { get; private set; } // The user's response to the prompt

    // Constructor initializes an entry with the current date, a prompt, and a response
    public Entry(string prompt, string response)
    {
        Date = DateTime.Now; // Set the date to the current time
        Prompt = prompt; // Store the prompt
        Response = response; // Store the user's response
    }

    // Method to format the entry as a string for display purposes
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n----------------------";
    }
}

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private static Random random = new Random();

    // List of prompts specific to the journal
    private static readonly List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    // Method to write a new entry
    public void WriteNewEntry()
    {
        string prompt = GetRandomPrompt(); // Get a random prompt
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        entries.Add(new Entry(prompt, response)); // Add a new Entry with prompt and response
        Console.WriteLine("Entry saved."); // Confirmation message
    }

    // Method to display journal entries
    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (var entry in entries)
        {
            Console.WriteLine(entry); // Uses the ToString method of Entry
        }
    }

    // Method to save the journal to a file
    public void SaveJournalToFile()
    {
        Console.Write("Enter filename to save the journal: ");
        string filename = Console.ReadLine();
        string json = JsonSerializer.Serialize(entries);
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved."); // Confirmation message
    }

    // Method to load journal entries from a file
    public void LoadJournalFromFile()
    {
        Console.Write("Enter filename to load the journal: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
            Console.WriteLine("Journal loaded."); // Confirmation message
        }
        else
        {
            Console.WriteLine("File not found."); // Error message
        }
    }

    // Private method to get a random prompt
    private string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index]; // Returns a random prompt from the list
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournalToFile();
                    break;
                case "4":
                    journal.LoadJournalFromFile();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!"); // Exit message
    }
}
