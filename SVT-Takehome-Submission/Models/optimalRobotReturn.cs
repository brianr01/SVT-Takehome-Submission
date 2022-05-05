using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVT_Takehome_Submission.Models
{
    public class OptimalRobotReturn
    {
        public int robotId { get; set; }
        public double? distanceToGoal { get; set; }
        public int batteryLevel { get; set; }
    }

}
