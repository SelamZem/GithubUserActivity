using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; 
using GitHubUserActivity.Models;

namespace GitHubUserActivity.Services
{
    internal class GitHubActivityService
    {
        private static readonly string ApiUrlTemplate = "https://api.github.com/users/{0}/events";
        private readonly HttpClient _httpClient;

        public GitHubActivityService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHubUserActivityCLI");
        }

        public async Task<List<Event>> GetUserEventsAsync(string username)
        {
            var url = string.Format(ApiUrlTemplate, username);
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch events: {response.StatusCode} - {response.ReasonPhrase}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<Event>>(json);
            return events ?? new List<Event>();
        }
    }
}
