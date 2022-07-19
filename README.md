# TaskTracker WebApi
This is the Web API for entering project data into the database. Every project contains of one or many related tasks while every task belongs to only one project.

## Technologies
* [ASP.NET Core 5 Web API](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [SQL Server 2019 Express Edition](https://www.microsoft.com/en-us/download/details.aspx?id=101064)
* [xunit](https://xunit.net/), [Moq](https://github.com/moq)
* [Postman](https://www.postman.com/)

## Installation Instructions

### Install SQL Server

To run this project, you need to install the Microsoft® SQL Server® 2019 Express first.

[Download SQL Server Express](https://www.microsoft.com/en-us/download/details.aspx?id=101064)

Once you install SQL Server, make sure it's running.

### Create & Populate the Database

#### Option 1 (Using SQL Server Management Studio/SSMS)

- Download & install [SSMS](https://aka.ms/ssmsfullsetup)

- Run SSMS and connect to your local SQL Server instance.

- After that open file `taskTrackerScript.sql` (File -> Open -> File...).

- Run all SQL statements. This will create all necessary tables and seed test data.

#### Option 2 (Using sqlcmd Utility)

- Download & install [sqlcmd Utility](https://docs.microsoft.com/en-us/sql/tools/sqlcmd-utility?view=sql-server-ver16)

- After that open Command Prompt (cmd).

- Type the following command: `sqlcmd -S COMP\SQLEXPRESS -E -i C:\taskTrackerScript.sql`
  - The –S value is to specify the SQL Server name of the instance
  - The -E flag is to specify a trusted connection
  - The -i is used to specify the input, you specify the script file with the queries (an absolute path to the file)

### Build & Run

To build and run web api project you need to install .NET SDK or runtime on your machine.

[Download .NET SDK/Runtime](https://dotnet.microsoft.com/en-us/download)

You will need to build the project to create an exe at this point. 

Afer that you have to change DefaultConnection in ConnectionStrings section of `appsettings.json` file to point out to your local database. 

### Test

To test the API you can use Postman or SwaggerUI.

Just head over to the: ```http://localhost:5000/api/projects``` 
and you should see some test projects returned.

## Current Features
* Ability to create / view / edit / delete information about projects
* Ability to create / view / edit / delete task information
* Ability to add and remove tasks from a project
* Ability to view all tasks in the project
* Ability to filter and sort projects with various methods (StartAt, EndAt, Range, ExactValue)

### Examples
- Range filtering: `http://localhost:5000/api/projects?startAt=2022-08-15&endAt=2022-08-20`
- Exact value filtering: `http://localhost:5000/api/projects?status=3`
- Exact value filtering2: `http://localhost:5000/api/projects?name=Project1`
- Sorting: `http://localhost:5000/api/projects?sortBy=name&isSortAscending=true`

## Project Overview
Project architecture is 3-layered:

### TaskTracker.Data
This data layer contains entities, enums, filters, extensions, entity configurations, migrations and repository logic specific to the domain model

### TaskTracker.Business
This layer contains all application logic that is services, interfaces and DTO's. It is dependent on the data layer, but has no dependencies on any other layer or project. This layer defines interfaces that are used in the presentation layer

### TaskTracker.WebApi
This is the WebApi layer which contains controllers and all presentation logic

### TaskTracker.WebApi.UnitTests
This is the project where all unit tests for Project controller methods are implemented