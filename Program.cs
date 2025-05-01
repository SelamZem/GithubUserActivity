using System;
using System.Threading.Tasks;
using GitHubUserActivity.Services;

namespace GitHubUserActivity
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("Error: Please provide a valid GitHub username as an argument.");
                Console.WriteLine("Usage: dotnet run -- <github-username>");
                return;
            }
            string username = args[0];
            var service = new GitHubActivityService();

            try
            {
                var events = await service.GetUserEventsAsync(username);
                if (events.Count == 0)
                {
                    Console.WriteLine("No recent public activity found.");
                    return;
                }

                foreach (var e in events)
                {
                    if (e.type == "PushEvent")
                    {
                        int count = e.payload?.size ?? 0;
                        Console.WriteLine($"Pushed {count} commits to {e.repo?.name}");
                    }
                    else if (e.type == "IssuesEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"{e.payload.action} issue in {e.repo?.name}");
                    }
                    else if (e.type == "WatchEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"{e.payload.action} {e.repo?.name}");
                    }
                    else if (e.type == "CreateEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"Created something in {e.repo?.name}");
                    }
                    else if (e.type == "DeleteEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"Deleted something in {e.repo?.name}");
                    }
                    else if (e.type == "PullRequestEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"{e.payload.action} pull request in {e.repo?.name}");
                    }
                    else if (e.type == "ForkEvent")
                    {
                        Console.WriteLine($"Forked {e.repo?.name}");
                    }
                    else if (e.type == "ReleaseEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"{e.payload.action} release in {e.repo?.name}");
                    }
                    else if (e.type == "PublicEvent")
                    {
                        Console.WriteLine($"Made {e.repo?.name} public");
                    }
                    else if (e.type == "MemberEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"{e.payload.action} member in {e.repo?.name}");
                    }
                    else if (e.type == "GollumEvent")
                    {
                        Console.WriteLine($"Updated wiki in {e.repo?.name}");
                    }
                    else if (e.type == "CommitCommentEvent")
                    {
                        Console.WriteLine($"Commented on commit in {e.repo?.name}");
                    }
                    else if (e.type == "PullRequestReviewEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"{e.payload.action} pull request review in {e.repo?.name}");
                    }
                    else if (e.type == "PullRequestReviewCommentEvent")
                    {
                        Console.WriteLine($"Commented on pull request review in {e.repo?.name}");
                    }
                    else if (e.type == "IssueCommentEvent" && e.payload?.action != null)
                    {
                        Console.WriteLine($"{e.payload.action} issue comment in {e.repo?.name}");
                    }
                    else
                    {
                        Console.WriteLine($"{e.type} in {e.repo?.name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
