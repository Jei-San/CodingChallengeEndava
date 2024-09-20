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

## Thoughts on the coding challenge

[Hacker News API](https://github.com/HackerNews/API) was a bit limited. There is a requirement where a search bar should apear in the [front-end](https://github.com/Jei-San/coding-challenge-endava-frontend/tree/main) UI, but this was not posible because there is was only one way to get the data from that API, the reason being is that it's a firebase database.

![image](https://github.com/user-attachments/assets/6eae0e48-7248-48c6-af30-603bc1e82f6e)

**NOTA**: The **Hacker News Api** firebase doesn't have the right configuration to search by title, for example this, it's how it should look:

![image](https://github.com/user-attachments/assets/51ee94be-15b2-46b1-b23c-b52030afed7e)

But here is the response:

![image](https://github.com/user-attachments/assets/a2fb26dd-9231-4732-abf4-fda8f4248ab2)

It cannot be searched by "title" which is the requirement field for the search bar to filter the table, I looked at many other ways to try and get the right data but I ran out of options and I had to implement SQLit with a database that stored the "stories", the database gets populated when the project is started with a Job called InitialJob, and then every 5 minutes a different Job called UpdateStoriesJob searches for new stories in the [Hacker News API](https://github.com/HackerNews/API) firebase compares it to the ones store in the database we created and inserts any new "stories", and from the created database we search by title (The table "Stories" has an index to avoid any performance issues).

Honestly, I loved being able to experiment with ways to solve this issue. I won't lie it was hard, but there is always a solution and one needs to adapt. Thank you very much for this experience!
