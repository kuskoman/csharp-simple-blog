# SimpleBog API

Project built using C#, that allows functionalities like creating users, posts and comments.

## Installation

### Prerequisites

Following tools are required to run this project:

- [Dotnet 7](https://dotnet.microsoft.com/en-us/download)
- [Dotnet EF (globally installed)](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

### Running project

To run the project, you need to run the database server and create the database. The database name is defined in the connection string.

```sh
dotnet ef database update
```

After that, you can run the project using the following command:

```sh
dotnet run
```

You can also start the project in watch mode:

```sh
dotnet watch run
```

## API Documentation (Swagger)

The project uses Swagger to document the API. To access the documentation, you need to run the project and access the following URL: [localhost:5000/swagger](http://localhost:5000/swagger)
