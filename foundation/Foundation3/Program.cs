using System;
using System.Collections.Generic;

// Abstract base class for all activities
public abstract class Activity
{
    // Protected attributes to allow access in derived classes
    protected DateTime _date;
    protected int _minutes;

    // Constructor
    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Public properties to expose date and minutes
    public DateTime Date => _date;
    public int Minutes => _minutes;

    // Virtual methods for derived classes to override
    public virtual double GetDistance() => 0; // Default implementation returns 0
    public virtual double GetSpeed() => 0;    // Default implementation returns 0
    public virtual double GetPace() => 0;     // Default implementation returns 0

    // GetSummary method that calls virtual methods
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():F1}, Speed {GetSpeed():F1}, Pace: {GetPace():F1}";
    }
}

// Derived class for Running
public class Running : Activity
{
    // Private attribute for distance
    private double _distance; // in miles

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    // Override methods to provide specific implementations
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // Speed in mph
    }

    public override double GetPace()
    {
        return Minutes / GetDistance(); // Pace in minutes per mile
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    // Private attribute for speed
    private double _speed; // in mph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    // Override methods to provide specific implementations
    public override double GetDistance()
    {
        return (GetSpeed() * Minutes) / 60; // Distance in miles
    }

    public override double GetSpeed()
    {
        return _speed; // Speed is already in mph
    }

    public override double GetPace()
    {
        return 60 / GetSpeed(); // Pace in minutes per mile
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    // Private attribute for laps
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    // Override methods to provide specific implementations
    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0; // Distance in kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // Speed in kph
    }

    public override double GetPace()
    {
        return Minutes / GetDistance(); // Pace in minutes per kilometer
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} (Laps: {_laps})";
    }
}

// Main program class to run the application
class Program
{
    static void Main(string[] args)
    {
        // Create a list to store activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 5), 20, 10)
        };

        // Display the summary of each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
