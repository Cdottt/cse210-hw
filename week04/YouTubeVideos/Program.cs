using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Tony", 480);
        video1.AddComment(new Comment("Maria", "This helped a lot!"));
        video1.AddComment(new Comment("Leo", "My pasta finally tastes good."));
        video1.AddComment(new Comment("Jenny", "Great tutorial!"));
        videos.Add(video1);

        // Video 2 
        Video video2 = new Video("Learn C# in 10 Minutes", "CodeMaster", 620);
        video2.AddComment(new Comment("Ethan", "Super clear explanation."));
        video2.AddComment(new Comment("Sarah", "Saved me on my assignment!"));
        video2.AddComment(new Comment("Mike", "Thanks for this!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Best Places to Visit in Japan", "TravelNow", 300);
        video3.AddComment(new Comment("Anna", "Adding this to my travel list."));
        video3.AddComment(new Comment("Tom", "Beautiful shots!"));
        video3.AddComment(new Comment("Kiko", "I live in Tokyo, great picks!"));
        videos.Add(video3);

        // Display all videos
        foreach (Video vid in videos)
        {
            vid.Display();
        }
    }
}