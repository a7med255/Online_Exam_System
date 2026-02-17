# Online Exam System

Online Exam System is an ASP.NET Core MVC application for managing and taking online exams.

## Tech Stack
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity

## Solution Structure
- `Online Exam System/` – web application (UI, controllers, views, startup)
- `OnlineExam.BLL/` – business logic layer
- `OnlineExam.DAL/` – data access and migrations
- `OnlineExam.Domain/` – domain models

## Prerequisites
- .NET SDK 8.0+
- SQL Server instance

## Setup
1. Update the SQL Server connection string in:
   - `Online Exam System/appsettings.json`
2. Apply migrations (if needed):
   ```bash
   dotnet ef database update --project OnlineExam.DAL --startup-project "Online Exam System"
   ```
3. Run the application:
   ```bash
   dotnet run --project "Online Exam System"
   ```

## Default Route
The app starts at the user login page:
- `/User/Login`

## Notes
- Authentication and authorization are configured using ASP.NET Core Identity.
- Admin routes are enabled through ASP.NET Core Areas.
