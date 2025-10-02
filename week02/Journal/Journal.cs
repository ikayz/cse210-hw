using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        bool isCsv = filename.EndsWith(".csv");
        using (StreamWriter writer = new StreamWriter(filename))
        {
            if (isCsv)
            {
                writer.WriteLine("Date,Prompt,Response,Mood,WordCount");
                foreach (Entry entry in _entries)
                {
                    string responseEscaped = entry._response.Replace("\"", "\"\"");
                    writer.WriteLine($"{entry._date},\"{entry._prompt}\",\"{responseEscaped}\",{entry._mood},{entry._wordCount}");
                }
            }
            else
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}|{entry._mood}|{entry._wordCount}");
                }
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        bool isCsv = filename.EndsWith(".csv");
        foreach (string line in File.ReadAllLines(filename))
        {
            if (isCsv)
            {
                if (line.StartsWith("Date")) continue;
                string[] parts = line.Split(',');
                if (parts.Length >= 5)
                {
                    string date = parts[0];
                    string prompt = parts[1].Trim('"');
                    string response = parts[2].Trim('"');
                    string mood = parts[3];
                    int wordCount = int.TryParse(parts[4], out int wc) ? wc : 0;
                    Entry entry = new Entry(date, prompt, response, mood, wordCount);
                    _entries.Add(entry);
                }
            }
            else
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 5)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3], int.TryParse(parts[4], out int wc) ? wc : 0);
                    _entries.Add(entry);
                }
            }
        }
    }
}
