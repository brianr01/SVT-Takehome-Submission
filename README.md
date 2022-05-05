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
* Use a map of the environment.
* Add error handling.
* Deploy to Azure.
* Move "GetDistance" method its own math package.
