# Employee Management System

## Overview
This is an Employee Management System built with .NET 9 Web API and Blazor Server, utilizing a SQL Server database and JWT for authentication.

## Prerequisites
- .NET 9 SDK
- SQL Server
- Docker (optional)

## How to Run Locally
1. Clone the repository.
2. Navigate to the project directory.
3. Run `dotnet restore` to restore dependencies.
4. Run `dotnet ef database update` to apply migrations.
5. Run `dotnet run` to start the application.

## Environment Variables
- `ConnectionStrings__DefaultConnection`
- `Jwt__Key`
- `Jwt__Issuer`
- `Jwt__Audience`

## API Endpoints
- `GET /api/employee`
- `GET /api/employee/{id}`
- `POST /api/employee`
- `PUT /api/employee`
- `DELETE /api/employee/{id}`
- `POST /api/auth/login`
- `POST /api/auth/register`

## Architecture Overview
The application follows Clean Architecture principles, separating concerns into Domain, Application, Infrastructure, and API layers.