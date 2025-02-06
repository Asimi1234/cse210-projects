using System;
using System.Collections.Generic;

public class Comment
{
    // Represents a comment on a YouTube video
    public string CommenterName { get; set; }
    public string Text { get; set; }

    // Constructor for Comment class
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    // Override ToString method to display comment information
    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

public class Video
{
    // Represents a YouTube video
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> Comments { get; set; }

    // Constructor for Video class
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to get the count of comments
    public int GetCommentCount()
    {
        return Comments.Count;
    }

    // Method to display video details and comments
    public void DisplayInfo()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Creating sample videos
        var video1 = new Video("Python OOP Tutorial", "TechGuru", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Thanks, this was helpful."));
        video1.AddComment(new Comment("Charlie", "Can you cover inheritance next?"));

        var video2 = new Video("Fitness Tips", "HealthyLiving", 450);
        video2.AddComment(new Comment("Dave", "Loved the workout suggestions."));
        video2.AddComment(new Comment("Eve", "Very informative, thanks!"));
        video2.AddComment(new Comment("Sammy", "Very helpful, thanks!"));

        var video3 = new Video("Guitar Chords Basics", "MusicMan", 700);
        video3.AddComment(new Comment("Frank", "Easy to follow, thanks!"));
        video3.AddComment(new Comment("Grace", "Can you do a tutorial on bar chords?"));
        video3.AddComment(new Comment("Alice", "Great explanation!"));

        // Storing videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Displaying all video details
        Console.WriteLine("YouTube Video Tracker\n" + new string('-', 30));
        foreach (var video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine(new string('-', 30));
        }
    }
}
