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
## How to run

**Requirements:** .NET 10 SDK and [TaskManagerAPI](https://github.com/zahra88esmaeli-lgtm/TaskManagerAPI), which **must be running first**.

```
git clone https://github.com/zahra88esmaeli-lgtm/TaskManagerWeb.git
cd TaskManagerWeb/TaskManager
```

In `appsettings.json`, set `ApiSettings:BaseUrl` to the **API address** (not the Web's own address):

```json
"ApiSettings": { "BaseUrl": "http://localhost:5280" }
```

```
dotnet run
```

Then open the address printed in the output (for example `http://localhost:5217`) in your browser.
## Related Repository
- - TaskManager API:[TaskManagerApi] (https://github.com/zahra88esmaeli-lgtm/TaskManagerAPI.git)

## Author
Niki
