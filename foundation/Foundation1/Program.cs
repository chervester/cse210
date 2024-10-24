using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }  // Length in minutes

    // Stores a list of comments
    private List<Comment> _comments = new List<Comment>();

    // Method to add a comment to the list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Method to display video information and comments
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {Length} minutes");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");

        foreach (var comment in _comments)
        {
            Console.WriteLine($"Comment by {comment.Name}: {comment.Text}");
        }
    }
}

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
    
        List<Video> videos = new List<Video>();


        Video video1 = new Video { Title = "C# Basics", Author = "John Doe", Length = 15 };
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        video1.AddComment(new Comment("Charlie", "Can you cover advanced topics?"));


        Video video2 = new Video { Title = "C# OOP Concepts", Author = "Jane Smith", Length = 20 };
        video2.AddComment(new Comment("Dave", "Good explanation of abstraction."));
        video2.AddComment(new Comment("Eve", "Clear and concise!"));
        video2.AddComment(new Comment("Frank", "Nice video."));

        Video video3 = new Video { Title = "LINQ in C#", Author = "Steve Johnson", Length = 25 };
        video3.AddComment(new Comment("Grace", "Very informative!"));
        video3.AddComment(new Comment("Hannah", "Learned a lot, thanks!"));
        video3.AddComment(new Comment("Isaac", "Can you do more LINQ examples?"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine(); 
        }
    }
}