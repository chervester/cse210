using System;
using System.Threading;

class MindfulnessActivity
{
    protected string activityName;
    protected string description;
    protected int duration;

    public MindfulnessActivity(string name, string desc)
    {
        activityName = name;
        description = desc;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting: {activityName}");
        Console.WriteLine(description);
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
    }

    public void EndActivity()
    {
        Console.WriteLine($"Good job! You've completed the {activityName} for {duration} seconds.");
        PauseWithAnimation(3);
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); // 1-second pause for animation
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.") { }

    public void Run()
    {
        StartActivity();
        for (int i = 0; i < duration; i += 6)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(3);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(3);
        }
        EndActivity();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself through this experience?",
        "How can you apply this experience in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on your strengths and resilience.") { }

    public void Run()
    {
        StartActivity();
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Length)]);

        for (int i = 0; i < duration; i += 5)
        {
            Console.WriteLine(questions[random.Next(questions.Length)]);
            PauseWithAnimation(5);
        }
        EndActivity();
    }
}

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect by listing positive things in your life.") { }

    public void Run()
    {
        StartActivity();
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Length)]);
        Console.WriteLine("Start listing items:");

        int itemCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"Item {++itemCount}: ");
            Console.ReadLine();
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
