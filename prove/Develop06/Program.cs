using System;
using System.Collections.Generic;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isCompleted;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isCompleted = false;
    }

    public abstract void RecordProgress();
    public abstract bool IsComplete();
    public abstract void DisplayGoal();

    public int GetPoints()
    {
        return _points;
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordProgress()
    {
        _isCompleted = true;
        Console.WriteLine($"You earned {_points} points for completing '{_name}'!");
    }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ {(IsComplete() ? "X" : " ")} ] {_name} - {_description}");
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordProgress()
    {
        Console.WriteLine($"You earned {_points} points for progress on '{_name}'!");
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never marked as fully complete.
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[  ] {_name} - {_description} (Eternal Goal)");
    }
}

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonus = bonus;
    }

    public override void RecordProgress()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            Console.WriteLine($"You earned {_points} points! Progress: {_currentCount}/{_targetCount}");
            if (_currentCount == _targetCount)
            {
                _isCompleted = true;
                Console.WriteLine($"Goal complete! You earned a bonus of {_bonus} points!");
            }
        }
    }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ {(IsComplete() ? "X" : " ")} ] {_name} - {_description} (Completed {_currentCount}/{_targetCount})");
    }
}

public class QuestTracker
{
    private List<Goal> _goals;
    private int _totalPoints;

    public QuestTracker()
    {
        _goals = new List<Goal>();
        _totalPoints = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordProgress();
            _totalPoints += goal.GetPoints();
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].DisplayGoal();
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Points: {_totalPoints}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        QuestTracker tracker = new QuestTracker();

        SimpleGoal runMarathon = new SimpleGoal("Run Marathon", "Complete a marathon", 1000);
        EternalGoal readScriptures = new EternalGoal("Read Scriptures", "Read scriptures daily", 100);
        ChecklistGoal templeVisits = new ChecklistGoal("Temple Visits", "Attend the temple", 50, 10, 500);

        tracker.AddGoal(runMarathon);
        tracker.AddGoal(readScriptures);
        tracker.AddGoal(templeVisits);

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Score");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    tracker.DisplayGoals();
                    break;
                case "2":
                    Console.WriteLine("Enter goal number:");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    tracker.RecordEvent(goalIndex);
                    break;
                case "3":
                    tracker.DisplayScore();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
