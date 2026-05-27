# Employee Management System

## Overview
A simple employee management system built with .NET 9 Web API and Blazor Server.

## Prerequisites
- .NET 9 SDK
- SQL Server
- Docker (optional)

## How to Run Locally
1. Clone the repository.
2. Run `dotnet restore` to restore dependencies.
3. Update the connection string in `appsettings.json`.
4. Run `dotnet ef database update` to apply migrations.
5. Run `dotnet run` to start the application.

## Environment Variables
- `ConnectionStrings__DefaultConnection`
- `Jwt__Key`
- `Jwt__Issuer`

## API Endpoints
- `GET /api/employee/{id}` - Get employee by ID
- `GET /api/employee` - Get all employees
- `POST /api/employee` - Create a new employee
- `PUT /api/employee` - Update an employee
- `DELETE /api/employee/{id}` - Delete an employee
- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Login and get JWT

## Architecture
The application follows Clean Architecture principles with four layers: Domain, Application, Infrastructure, and API.