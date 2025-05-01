# GitHubUserActivity

[This is a simple C# project that fetches a GitHub user's recent activity using GitHub’s public API.]
(https://roadmap.sh/projects/github-user-activity)

## What this project does

- Takes a GitHub username as input.
- Builds a URL to request that user's recent events from GitHub.
- Sends a GET request to GitHub’s API.
- Reads the JSON response.
- Converts the response into C# objects.
- Returns a list of events that include useful info like event type, repository name, action.

### Example of what it can fetch:
- Someone pushed code (`PushEvent`)
- Starred a repo (`WatchEvent`)

### I only selected the important fields from the GitHub API response, like:
- `id`
- `type`
- `repo`
- `payload.action` and `payload.size`(for push events manily)
- `created_at`

This makes the project cleaner, more readable, and easier to learn from.

## What you need to run this

- .NET installed
- Visual Studio or any C# editor
- Newtonsoft.Json package (for deserializing JSON)

## How to use it

1. Open the project in Visual Studio.
2. Run the app.
3. Enter any GitHub username when asked.
4. The app fetches and shows their recent GitHub events.

![screenshot]<img width="260" alt="UserActivity" src="https://github.com/user-attachments/assets/e863dc4e-5289-4b07-a3d5-eca45487a999" />

