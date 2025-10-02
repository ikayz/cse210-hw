using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create first video
        Video video1 = new Video("Learning C# in 10 Minutes", "CodeMaster", 600);
        video1.AddComment("John Doe", "Great tutorial, very helpful!");
        video1.AddComment("Alice Smith", "Could you make more videos like this?");
        video1.AddComment("Bob Johnson", "I finally understand C# classes!");
        videos.Add(video1);

        // Create second video
        Video video2 = new Video("Making the Perfect Pizza", "ChefCooking", 900);
        video2.AddComment("FoodLover", "Tried this recipe, turned out amazing!");
        video2.AddComment("HomeChef", "What type of flour do you recommend?");
        video2.AddComment("PizzaFan", "Best pizza tutorial ever!");
        video2.AddComment("CookingNewbie", "Very clear instructions, thanks!");
        videos.Add(video2);

        // Create third video
        Video video3 = new Video("Daily Workout Routine", "FitnessGuru", 1200);
        video3.AddComment("GymBro", "Great routine for beginners!");
        video3.AddComment("HealthyLife", "Do you recommend this for seniors?");
        video3.AddComment("WorkoutBeginner", "Feeling the burn already!");
        videos.Add(video3);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"\nVideo: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment._commenterName}: {comment._commentText}");
            }
        }
    }
}
