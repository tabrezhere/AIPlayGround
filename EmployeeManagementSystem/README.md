# Employee Management System

## Overview
This is a simple Employee Management System built using .NET 9 Web API and Blazor Server.

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
- `GET /api/employee/{id}` - Get employee by ID
- `GET /api/employee` - Get all employees
- `POST /api/employee` - Create a new employee
- `PUT /api/employee` - Update an existing employee
- `DELETE /api/employee/{id}` - Delete an employee
- `POST /api/auth/login` - Authenticate and get JWT

## Architecture
The application follows Clean Architecture principles with four layers: Domain, Application, Infrastructure, and API.