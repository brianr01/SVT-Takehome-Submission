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
        public static List<Robot> Robots()
        {
            HttpResponseMessage response = Get("robots");
            List<Robot> robots = response.Content.ReadAsAsync<List<Robot>>().Result;

            return robots;
        }

        private static HttpResponseMessage Get(string path)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Environment.GetEnvironmentVariable("ROBOT_API_URL") + path).Result;

            return response;
        }
    }
}
