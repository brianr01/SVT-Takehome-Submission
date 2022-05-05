# SVT-Takehome-Submission
## Running
Clone the repository.
$ git clone git@github.com:brianr01/SVT-Takehome-Submission.git
Open the repository in VS2019, and build the solution.
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
