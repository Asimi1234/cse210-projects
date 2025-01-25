using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private List<string> _moods = new List<string>
    {
        "Happy",
        "Sad",
        "Neutral",
        "Excited",
        "Anxious"
    };

    public void AddEntry()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your Response: ");
        string response = Console.ReadLine();

        Console.WriteLine("Select your mood:");
        for (int i = 0; i < _moods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_moods[i]}");
        }
        Console.Write("Enter the number corresponding to your mood: ");
        int moodIndex;
        while (!int.TryParse(Console.ReadLine(), out moodIndex) || moodIndex < 1 || moodIndex > _moods.Count)
        {
            Console.Write("Invalid choice. Please enter a valid number: ");
        }

        string mood = _moods[moodIndex - 1];
        _entries.Add(new Entry(prompt, response, mood));
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo journal entries found.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            foreach (var line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    _entries.Add(new Entry(parts[1], parts[2], parts[3]) { Date = parts[0] });
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
