using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Load scriptures from file or predefined list
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        // Main program loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Memorization Challenge! Press enter to begin or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            // Randomly select a scripture from the library
            Random random = new Random();
            Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

            // Initialize how many words to hide at a time
            int wordsToHide = 1;

            // Memorization loop
            while (!selectedScripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetScriptureText());
                Console.WriteLine("\nPress enter to hide more words, or type 'quit' to exit.");
                input = Console.ReadLine();
                if (input.ToLower() == "quit") break;

                // Hide words incrementally, increasing difficulty
                selectedScripture.HideRandomWords(wordsToHide);
                wordsToHide++; // Increase the number of words to hide each round
            }

            Console.WriteLine("Well done! You've memorized the scripture.");
            Console.WriteLine("Would you like to repeat the scripture? (yes/no)");
            string repeat = Console.ReadLine();
            if (repeat.ToLower() == "no") break;
        }

        Console.WriteLine("Program ending.");
    }

    // Load scriptures from a text file
    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        var scriptures = new List<Scripture>();
        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                var reference = parts[0].Trim(); // Reference part
                var text = parts[1].Trim(); // Scripture text
                // Assume a simple reference format like "Proverbs 3:5-6"
                var refParts = reference.Split(' ');
                var book = refParts[0];
                var chapterVerse = refParts[1].Split(':');
                var chapter = int.Parse(chapterVerse[0]);
                var verses = chapterVerse[1].Split('-');
                var startVerse = int.Parse(verses[0]);
                var endVerse = verses.Length > 1 ? int.Parse(verses[1]) : startVerse;

                scriptures.Add(new Scripture(new Reference(book, chapter, startVerse, endVerse), text));
            }
        }
        return scriptures;
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    // Hide a specific number of words randomly
    public void HideRandomWords(int count)
    {
        int hiddenCount = 0;
        while (hiddenCount < count)
        {
            int index = _random.Next(_words.Count);
            if (!_words[index].IsHidden()) 
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    // Check if all words are hidden
    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }

    // Return the scripture text, hiding words as needed
    public string GetScriptureText()
    {
        return _reference.ToString() + " " + string.Join(" ", _words.ConvertAll(word => word.GetDisplayText()));
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_startVerse == _endVerse)
            return $"{_book} {_chapter}:{_startVerse}";
        else
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string GetDisplayText()
    {
        if (_hidden)
            return new string('_', _text.Length);
        else
            return _text;
    }
}
