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

## Explicacion

Hacker News API estaba un poco limitado. Existe un requerimiento en donde se solicita crear un buscador en el UI del front-end, pero esto no era posible ya que solo existe una forma de traer datos de esa API que se proporciono, ya que es por medio de firebase.

![369190262-6eae0e48-7248-48c6-af30-603bc1e82f6e](https://github.com/user-attachments/assets/1691c4ef-5171-4676-a2b6-83c5a455fa99)

NOTA: El firebase de Hacker News Api no tiene configurado el firebase, aqui tiene el ejemplo de como se deberia ver:

![369190721-51ee94be-15b2-46b1-b23c-b52030afed7e](https://github.com/user-attachments/assets/b6960f66-83fa-4196-8685-c7dde029f476)

Aqui la respuesta que arrojaba:

![369190985-a2fb26dd-9231-4732-abf4-fda8f4248ab2](https://github.com/user-attachments/assets/69897aed-4799-4dab-b1d3-cf681fe8b25f)

No se pueden hacer busquedas por "title" que en este caso es el campo solicitado por el requerimiento para filtrar la busqueda, busque varias maneras de hacerlo pero no me quedo de otra opcion mas que implmentar SQLite con una base de datos que guardaba las "stories", la base de datos se llena de datos al iniciar el proyecto por medio de un Job inicial, y con otro Job, que inserta nuevas historias (si las hay) cada 5 minutos, que al estar corriendo el programa vuelve a buscar datos del Hacker News API e inserta las nuevas noticias que no se encuentren en la base de datos, y de ahi aplico el filtro para la busqueda por titulo (claro tiene indice para acelerar el proceso de busqueda), asi como traer las ultimas "stories".

Honestamente, me gusto mucho el poder experimentar con formas de solucionarlo, no voy a mentir, si batalle pero para todo siempre hay una solucion y hay que adaptarse. Muchas gracias por esta experiencia!
