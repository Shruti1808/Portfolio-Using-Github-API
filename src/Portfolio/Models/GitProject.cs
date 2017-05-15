using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

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
            var request = new RestRequest("users/Shruti1808/repos", Method.GET);
            
            ////q = The search keywords, as well as any qualifiers and value=string.
            //request.AddParameter("q", "Shruti1808");
            ////Searches and sorts repositories based on the number of stars.
            //request.AddParameter("sort", "stars");
            ////The sort order if sort parameter is provided. One of asc or desc. Default: desc
            //request.AddParameter("order", "desc");
            ////to display your three most-starred repositories.
            //request.AddParameter("per_page", "3");
            request.AddHeader("User-Agent", "Shruti1808");
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            var response = new RestResponse();
            Console.WriteLine(response);
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            //JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            //var items = jsonResponse["items"];
            //var projectList = new List<GitProject> { };

            //for (int i = 0; i < items.Count(); i++)
            //{
            //    GitProject newProject = new GitProject();
            //    newProject.Name = items[i]["name"].ToString();
            //    newProject.HtmlUrl = items[i]["html_url"].ToString();
            //    newProject.Description = items[i]["description"].ToString();
            //    projectList.Add(newProject);
            //}
            //return projectList;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            //string jsonOutput = jsonResponse["repositories"].ToString();
            //Console.WriteLine(jsonOutput);
            var projectList = JsonConvert.DeserializeObject<List<GitProject>>(jsonResponse.ToString());
            Console.WriteLine(projectList[0].Name);
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
