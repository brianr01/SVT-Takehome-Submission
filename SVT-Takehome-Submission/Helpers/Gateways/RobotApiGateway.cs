using SVT_Takehome_Submission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SVT_Takehome_Submission.Helpers.Gateways
{
    public class RobotApiGateway
    {
        public List<Robot> Robots()
        {
            HttpResponseMessage response = Get("robots");
            List<Robot> robots = null;
            robots = response.Content.ReadAsAsync<List<Robot>>().Result;

            return robots;
        }

        private HttpResponseMessage Get(string path)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://60c8ed887dafc90017ffbd56.mockapi.io/" + path).Result;

            return response;
        }
    }
}
