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
        }

    }
}
