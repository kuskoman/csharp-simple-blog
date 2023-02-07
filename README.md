# SimpleBlog

Project built using C#, that allows functionalities like creating users, posts and comments.

## Running project

### Prerequisites

Following tools are required to run this project:

- [Dotnet 7](https://dotnet.microsoft.com/en-us/download)
- [Node >= 19](https://nodejs.org/)

or:

- [Docker](https://www.docker.com/)

Recommended tools:

- [Make](https://www.gnu.org/software/make/)

## Project details

### Architecture

The project is divided into three projects:

- [SimpleBlog](./SimpleBlog): Contains the API
- [SimpleBlog.Web](./SimpleBlog.Web): Contains the web application written in Vue
- [SimpleBlog.Tests](./SimpleBlog.Tests): Contains API tests

Each project has its own README file with more information.

#### Database

The project uses Microsoft SQL Server as database. The connection string is defined in the [appsettings.json](./SimpleBlog/appsettings.json) file.
To run the project, you need to run the database server and create the database. The database name is defined in the connection string.
For more information about migrations see [API documentation](./SimpleBlog/README.md).

You can also use the [docker-compose.yml](./docker-compose.yml) file to run the database server.

```sh
docker-compose up -d
```

#### Auth

The project used HttpOnly cookies to store the authentication token. The token is generated by
Microsoft Identity. For more information see into [the implementation](./SimpleBlog/Utils/AuthSetup.cs).
