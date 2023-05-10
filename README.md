
# Share A Meal - SSWF Project

Share a Meal is a full-stack web application written primarily in C# using the ASP.NET Core MVC framework with Entity Framework. The main goal of this project is to create an application that helps combat food waste in schools by collecting non-eaten food scraps and turning them into food packets that employees can publish, and students can reserve for a lower price than normal, all through the application.




## Main Features

- Authentication and authorization using ASP.NET Core Identity
- Entity Framework for database interactions and migrations
- Onion architecture for better separation of concerns
- Utilizes both a RESTFul Web API (RMM 2) and a GraphQL API for data from an SQL database
- Unit and integration testing with XUnit and Moq (Triggered on deployment)
- Swagger API documentation



## Technologies Used

- C#
- ASP.NET Core MVC
- Entity Framework
- SQL
- XUnit
- Moq
- Swagger
- Azure DevOps
- GraphQL
- Postman





## Deployment

The project follows a continuous deployment approach, utilizing a development pipeline that automatically triggers a build when changes are pushed to the main branch. The pipeline then proceeds to run unit tests and deploy the application automatically on success.



