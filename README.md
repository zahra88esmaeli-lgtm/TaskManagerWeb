[فارسی](README.fa.md) | English
# TaskManager Web

A task management web application built with ASP.NET Core MVC.
It communicates with a separate REST API (TaskManager API) using JWT authentication.

## Features
- User registration and login (JWT token stored in Session)
- Change password and delete account
- Create, edit, delete and list personal tasks
- Friendly error messages when the API is unavailable

## Tech Stack
- C#, ASP.NET Core MVC
- Typed HttpClient for calling the API
- JWT authentication, Session
- Bootstrap

## How to Run
1. Clone and run the TaskManager API first.
2. Set the API address in `appsettings.json` (use the key name from your project):

       "ApiSettings": { "BaseUrl": "https://localhost:7244/" }

3. Run this project:

       dotnet run

## Related Repository
- - TaskManager API: [TaskManagerApi](https://github.com/YOUR-USERNAME/TaskManagerApi)

## Author
Niki