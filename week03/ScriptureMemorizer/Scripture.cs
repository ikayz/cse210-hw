using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var notHidden = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < count && notHidden.Count > 0; i++)
        {
            int idx = rand.Next(notHidden.Count);
            notHidden[idx].Hide();
            notHidden.RemoveAt(idx);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }
}
