using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Portfolio.Models
{
    public class GitProject
    {
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static List<GitProject> GetProjects()
        {
            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest("search/repositories");
            request.AddParameter("q", "Shruti1808");
            request.AddParameter("sort", "stars");
            request.AddParameter("order", "desc");
            request.AddParameter("per_page", "3");
            client.AddDefaultHeader("Authorization", "token " + EnvironmentVariables.AuthToken);
            request.AddHeader("User-Agent", "Epicodus Portfolio Project");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var items = jsonResponse["items"];
            var projectList = new List<GitProject> { };

            for (int i = 0; i < items.Count(); i++)
            {
                GitProject newProject = new GitProject();
                newProject.Name = items[i]["name"].ToString();
                newProject.HtmlUrl = items[i]["html_url"].ToString();
                newProject.Description = items[i]["description"].ToString();
                projectList.Add(newProject);
            }
            //ViewBag.myString = response.Content.ToString();
            return projectList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}
