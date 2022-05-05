using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SVT_Takehome_Submission.Helpers.Gateways;
using SVT_Takehome_Submission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVT_Takehome_Submission.Controllers
{
    [Route("api/robots/[controller]")]
    [ApiController]
    public class ClosestController : ControllerBase
    {
        private static readonly int shortDistance = 10;

        /// <summary>
        /// Returns the details for the optimal robot to navigate to the load.
        /// </summary>
        /// <param name="load">The load model containing the location and id.</param>
        /// <returns>
        /// The robot id, distance to goal (payload), and battery level.
        /// It is returned in the form {robotId: int, distanceToGoal: double, batteryLevel: int}
        /// </returns>
        [HttpPost]
        public IActionResult Post(Load load)
        {

            List<Robot> robots = RobotApiGateway.Robots();

            bool hasFoundCloseRobot = false;

            Robot optimalRobot = null;
            double? closestDistance = null;

            foreach(var robot in robots)
            {
                double distance = GetDistance(robot.x, robot.y, load.x, load.y);

                if (distance < shortDistance)
                {
                    hasFoundCloseRobot = true;
                    if (optimalRobot.batteryLevel < robot.batteryLevel)
                    {
                        optimalRobot = robot;
                        closestDistance = distance;
                    }
                    continue;
                }

                if ((!hasFoundCloseRobot && distance < closestDistance) || optimalRobot is null)
                {
                    optimalRobot = robot;
                    closestDistance = distance;
                }
            }

            OptimalRobotReturn robotReturn = new OptimalRobotReturn
            {
                robotId = Convert.ToInt32(optimalRobot.robotId),
                distanceToGoal = closestDistance,
                batteryLevel = optimalRobot.batteryLevel
            };

            return Ok(robotReturn);
        }

        /// <summary>
        /// Calculates the distance between 2 sets of coordinates.
        /// </summary>
        /// <param name="x1">The x value of the first coordinate.</param>
        /// <param name="y1">The y value of the first coordinate.</param>
        /// <param name="x2">The x value of the second coordinate.</param>
        /// <param name="y2">The y value of the second coordinate.</param>
        /// <returns>The distance.</returns>
        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(
                Math.Pow(x1 - x2, 2)
                +
                Math.Pow(y1 - y2, 2)
            );
        }
    }
}
