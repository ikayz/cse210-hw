using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _rand = new Random();

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0) return null;
        return _scriptures[_rand.Next(_scriptures.Count)];
    }

    public void LoadFromFile(string filename)
    {
        _scriptures.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            // Format: Book|Chapter|Verse|[EndVerse]|Text
            string[] parts = line.Split('|');
            if (parts.Length == 5)
            {
                Reference r = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                _scriptures.Add(new Scripture(r, parts[4]));
            }
            else if (parts.Length == 4)
            {
                Reference r = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
                _scriptures.Add(new Scripture(r, parts[3]));
            }
        }
    }
}
