using System;

class Program
{
    static void Main(string[] args)
    {
        // Built-in scripture library
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
            new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy.")
        };
        Random rand = new Random();
        bool running = true;
        while (running)
        {
            Console.WriteLine("Scripture Memorizer Menu:");
            Console.WriteLine("1. Pick a random scripture to memorize");
            Console.WriteLine("2. Quit");
            Console.Write("Choose an option: ");
            string menu = Console.ReadLine();
            Console.Clear();
            switch (menu)
            {
                case "1":
                    Scripture scripture = scriptures[rand.Next(scriptures.Count)];
                    // Memorization loop
                    while (true)
                    {
                        Console.Clear();
                        scripture.Display();
                        if (scripture.AllWordsHidden())
                        {
                            Console.WriteLine("\nAll words are hidden.");
                            Console.Write("Would you like to save this scripture to a file? (yes/no): ");
                            string save = Console.ReadLine().Trim().ToLower();
                            if (save == "yes")
                            {
                                Console.Write("Enter filename to save: ");
                                string filename = Console.ReadLine();
                                using (var writer = new System.IO.StreamWriter(filename, true))
                                {
                                    writer.WriteLine(scripture.ToString());
                                }
                                Console.WriteLine($"Scripture saved to {filename}.");
                                Console.WriteLine("Press Enter to return to menu.");
                                Console.ReadLine();
                            }
                            break;
                        }
                        Console.WriteLine("\nPress Enter to hide more words, type 'hint' for a hint, or type 'quit' to return to menu.");
                        string input = Console.ReadLine();
                        if (input.Trim().ToLower() == "quit")
                            break;
                        else if (input.Trim().ToLower() == "hint")
                        {
                            RevealHintWord(scripture);
                            Console.WriteLine("A hidden word has been revealed! Press Enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            scripture.HideRandomWords(3);
                        }
                    }
    // Creative feature: Reveal a random hidden word as a hint to fill in a missing word in the blanks
    static void RevealHintWord(Scripture scripture)
    {
        var type = scripture.GetType();
        var wordsField = type.GetField("_words", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var words = (System.Collections.IList)wordsField.GetValue(scripture);
        var hiddenWords = new System.Collections.Generic.List<object>();
        foreach (var w in words)
        {
            var isHidden = (bool)w.GetType().GetMethod("IsHidden").Invoke(w, null);
            if (isHidden)
                hiddenWords.Add(w);
        }
        if (hiddenWords.Count > 0)
        {
            var rand = new Random();
            var word = hiddenWords[rand.Next(hiddenWords.Count)];
            word.GetType().GetMethod("Unhide").Invoke(word, null);
        }
    }
                    break;
                case "2":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        }
    }
}
