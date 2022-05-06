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
        private static readonly string robotApiUrl = "https://60c8ed887dafc90017ffbd56.mockapi.io/";
        /// <summary>
        /// Gets the list of robots from the robot api.
        /// </summary>
        /// <returns>A list of the robot model.</returns>
        public static List<Robot> Robots()
        {
            HttpResponseMessage response = Get("robots");
            List<Robot> robots = response.Content.ReadAsAsync<List<Robot>>().Result;

            return robots;
        }

        /// <summary>
        /// Makes a get request to the robots api.
        /// </summary>
        /// <returns>The http response message.</returns>
        private static HttpResponseMessage Get(string path)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(robotApiUrl + path).Result;

            return response;
        }
    }
}
