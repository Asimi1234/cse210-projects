using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a scripture with reference and text
        Reference scriptureReference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        Scripture scripture = new Scripture(scriptureReference, scriptureText);

        // Main loop for the program
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideWords();
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}

// Class representing a word in the scripture
class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string GetDisplayText()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

// Class representing the scripture reference (e.g., "Proverbs 3:5-6")
class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetReference()
    {
        return _startVerse == _endVerse
            ? $"{_book} {_chapter}:{_startVerse}"
            : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

// Class that manages the scripture text and hiding words
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public void Display()
    {
        Console.WriteLine(_reference.GetReference());
        Console.WriteLine(string.Join(" ", _words.Select(word => word.GetDisplayText())));
    }

    public void HideWords()
    {
        int wordsToHide = 3;

        List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        for (int i = 0; i < wordsToHide && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden);
    }
}
