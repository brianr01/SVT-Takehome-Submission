# SVT-Takehome-Submission
## Running
Clone the repository.
`$ git clone git@github.com:brianr01/SVT-Takehome-Submission.git`
1. Open the repository in Visual Studio 2019.
2. Switch to the `Release` configuration.
3. Switch to the `SVT_Takehome_Submission` profile.
4. Run the solution.
## Testing
Base Url: `http://localhost:5000/api/`
### Endpoints
### Robots Closest
Path: `robots/closest` <br>
Example Payload
```
{
    "loadId": 2,
    "x": 21,
    "y": 152
}
```
Example Response
```
{
    "robotId": 54,
    "distanceToGoal": 54.00925846556311,
    "batteryLevel": 46
}
```

## What is next?
### Use a map of the environment.
---
While the closest distance between two points is a line, it would be a big problem is a self was between the robot and the payload.
#### Node Map
Given a map of the enivonment, a set of connected nodes can be generated to reduce the complexcity of the problem.
#### A*
Given the set of connected nodes, a path search algorithm (a* for example) can be implemented to get a better approximation for the navigation distance of a robot. 

### Add error handling.
---
Locations to add gracefull erro handling.
1. When getting error response from robot api.
2. When the robot api returns a list of 0 robots.
3. When the in proper parameters are passed to the endpoint.

### Make the endpoint more efficient.
---
The endpoint is specifically for robots, but if the endpoint were to be generalized it could be a good idea to add this optimization. The calculation of a square root is not efficient. To help minimize this inefficiency robots that are definitely too far away need to be ruled out quickly. For example: if a point returned a distance of 11 units in the x direction and 1000 units in y direction it is pretty obvious that it is not with 10 units. Given a robot is purely in the x or y direction it is quite easy to tell the distance. For example (0, 10) or (100, 0). It gets more difficult to estimate as the ratio between x and y changes. When x = y the distance away from its perceived value is at its peak. The value of x + y given x = y can be calculated at given the distance. (Note: This optimization will only help if some of the points are outside the set distance)
### Calculating the approximation.
From the previous example x and y were used for the distance between two points in the x and y directions.  For the calculation a and b will be used instead of x and y.
```
Given a = b calculate the value of a + b.
c = sqrt(a^2 + b^2)
c = sqrt(2 * a^2)
c^2 = 2 * a^2
(c^2)/2 = a^2
sqrt((c^2)/2) = a
sqrt(c^2) / sqrt(2) = a
c/sqrt(2) = a
c/sqrt(2) * 2 = a + b
```
### Usage
A pseudo code example.
```
c = 10; // The distance is 10 units.
aPlusBMax = c/sqrt(2) * 2
for point in points {
    if (xDistance + yDistance > aPlusBMax) {
        // The distance from point (x, y) is definitly greater than 10.
    }
    // Calculate the true distance with the distance formula.
}
```
