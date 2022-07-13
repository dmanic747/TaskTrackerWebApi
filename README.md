# TaskTracker WebApi
This is a Web API for entering project data into the database. Every project contains of one or many related tasks while every task belongs to only one project.

## Technologies
* [ASP.NET Core 5](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [xunit](https://xunit.net/), [Moq](https://github.com/moq)
* [SQL Server 2019 Express Edition](https://www.microsoft.com/en-us/download/details.aspx?id=101064)
* [Postman](https://www.postman.com/)

## Installation Instructions
You will need to build the project to create an exe at this point. Afer that you have to change DefaultConnection in ConnectionStrings section of appsettings.json file to point out to your local database. To test the API you can use Postman or SwaggerUI.

## Current Features
* Ability to create / view / edit / delete information about projects
* Ability to create / view / edit / delete task information
* Ability to add and remove tasks from a project
* Ability to view all tasks in the project
* Ability to filter and sort projects with various methods (StartAt, EndAt, Range, ExactValue)

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