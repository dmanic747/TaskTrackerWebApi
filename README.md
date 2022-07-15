# TaskTracker WebApi
This is a Web API for entering project data into the database. Every project contains of one or many related tasks while every task belongs to only one project.

## Technologies
* [ASP.NET Core 5 Web API](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [SQL Server 2019 Express Edition](https://www.microsoft.com/en-us/download/details.aspx?id=101064)
* [xunit](https://xunit.net/), [Moq](https://github.com/moq)
* [Postman](https://www.postman.com/)

## Installation Instructions

### Install SQL Server

To run this project, you need to install the Microsoft® SQL Server® 2019 Express first.

https://www.microsoft.com/en-us/download/details.aspx?id=101064

Once you install SQL Server, make sure it's running.

### Install SSMS

After that you need to install SQL Server Management Studio (SSMS)

https://aka.ms/ssmsfullsetup

This one is going to be needed for executing SQL scripts.

### Create & Populate the Database

Run SSMS and connect to your local SQL Server instance.

After that open new query tab and then copy and paste all SQL statements from the taskTrackerScript.sql file.

Run all SQL statements. This will create all necessary tables and seed test data.

### Build & Run

To build and run web api project you need to install .NET SDK or runtime on your machine.

https://dotnet.microsoft.com/en-us/download

You will need to build the project to create an exe at this point. 

Afer that you have to change DefaultConnection in ConnectionStrings section of appsettings.json file to point out to your local database. 

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
This layer contains all application logic that is services, interfaces and DTO's. It is dependent on the data layer, but has no dependencies on any other layer or project. This layer defines interfaces that are used in presentation layer

### TaskTracker.WebApi
This is a WebApi layer which contains controllers and all presentation logic

### TaskTracker.WebApi.UnitTests
This is project where all unit tests for Project controller methods are implemented