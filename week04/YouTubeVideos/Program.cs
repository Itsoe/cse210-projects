using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video video1 = new Video("How to Start a Small Business", "Itai Mentor", 420);
        Video video2 = new Video("Top 5 Marketing Tips", "Growth Hub", 315);
        Video video3 = new Video("Beginner Budgeting Guide", "Finance Basics", 510);
        Video video4 = new Video("How to Pitch to Investors", "Startup World", 390);

        // Add comments to video 1
        video1.AddComment(new Comment("Tariro", "This was very helpful."));
        video1.AddComment(new Comment("John", "I liked the examples."));
        video1.AddComment(new Comment("Musa", "Can you make another video on funding?"));

        // Add comments to video 2
        video2.AddComment(new Comment("Sarah", "These tips are practical."));
        video2.AddComment(new Comment("Blessing", "I learned a lot from this."));
        video2.AddComment(new Comment("Mike", "Very clear explanation."));

        // Add comments to video 3
        video3.AddComment(new Comment("Anna", "This made budgeting easy to understand."));
        video3.AddComment(new Comment("Peter", "Thanks for sharing this."));
        video3.AddComment(new Comment("Rudo", "I will try this method."));

        // Add comments to video 4
        video4.AddComment(new Comment("James", "Pitching is harder than it looks."));
        video4.AddComment(new Comment("Chipo", "This gave me confidence."));
        video4.AddComment(new Comment("Lerato", "Please do one about investor questions."));

        // Put videos in a list
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display video details and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLengthInSeconds()}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}