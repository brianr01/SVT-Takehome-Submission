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


            // Select the first robot as the default.
            Robot optimalRobot = robots.First();
            double distanceForOptimalRobot = GetDistance(optimalRobot.x, optimalRobot.y, load.x, load.y);
            bool hasFoundNearbyRobot = distanceForOptimalRobot < shortDistance;


            foreach (var robot in robots.Skip(1))
            {
                double distance = GetDistance(robot.x, robot.y, load.x, load.y);

                // If the robot is nearby.
                if (distance < shortDistance)
                {
                    // If a nearby robot has not been found already.
                    if (!hasFoundNearbyRobot)
                    {
                        optimalRobot = robot;
                        distanceForOptimalRobot = distance;
                        hasFoundNearbyRobot = true;
                        continue;   
                    }

                    // Compare the battery with the other robot that has been found nearby
                    if (optimalRobot.batteryLevel < robot.batteryLevel)
                    {
                        optimalRobot = robot;
                        distanceForOptimalRobot = distance;
                    }
                }

                // Don't check robots that are far away if a close one has already been found.
                if (hasFoundNearbyRobot)
                {
                    continue;
                }

                // If the robot is closer than the current optimal robot.
                if (distance < distanceForOptimalRobot)
                {
                    optimalRobot = robot;
                    distanceForOptimalRobot = distance;
                }
            }

            OptimalRobotReturn robotReturn = new OptimalRobotReturn
            {
                robotId = Convert.ToInt32(optimalRobot.robotId),
                distanceToGoal = distanceForOptimalRobot,
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
