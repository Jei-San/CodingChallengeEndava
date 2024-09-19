## Welcome to Coding Challenge Endava

To execute this project it is necessary to run it through Visual Studio 2022 and install SQLite and SQL Server Compact Toolbox Extension
![image](https://github.com/user-attachments/assets/7f285ce6-65ac-4275-a3ea-05e36061c962)

## AppSettings Configuration

Inside the appsettings define the route of where you want the database to be created and read from, example:

`
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "CodingChallengeEndavaConnection": "Data Source=C:\\repos\\CodingChallengeEndava\\CodingChallengeEndava\\Core\\Database\\CodingChallengeEndava.db"
    },
    "HackerNewsApi": {
        "Url": "https://hacker-news.firebaseio.com"
    }
}
`

## Running the project

After this should be set and ready to go, just make sure to add the appsettings correctly, then set CodingChallegeEndava as startup project and click on execute, it will open a swagger with the endpoints existing in the project.

## Testing the project

You can run the tests provided in the Test Project which is in CodingChallengeEndavaTest, by right clicking on the project and clicking on Run Tests
