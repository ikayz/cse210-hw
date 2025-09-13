using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;
    public int _wordCount;

    public Entry(string date, string prompt, string response, string mood = "", int wordCount = 0)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
        _wordCount = wordCount > 0 ? wordCount : (response == null ? 0 : response.Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries).Length);
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        if (!string.IsNullOrEmpty(_mood))
            Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Word Count: {_wordCount}\n");
    }
}
