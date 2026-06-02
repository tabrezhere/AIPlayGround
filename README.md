# Employee Management System

## Prerequisites
- .NET 9 SDK
- SQL Server

## How to Run Locally
1. Clone the repository.
2. Navigate to the API project folder.
3. Run `dotnet run`.

## Environment Variables
- `ConnectionStrings__DefaultConnection`: Connection string for SQL Server.
- `Jwt:Key`: Secret key for JWT.
- `Jwt:Issuer`: Issuer for JWT.
- `Jwt:Audience`: Audience for JWT.

## API Endpoints
- `GET /api/employee`: Get all employees.
- `GET /api/employee/{id}`: Get employee by ID.
- `POST /api/employee`: Add a new employee.
- `PUT /api/employee`: Update an existing employee.
- `DELETE /api/employee/{id}`: Delete an employee.
- `POST /api/auth/login`: Authenticate user and get JWT.

## Architecture Overview
This application follows Clean Architecture principles, separating concerns into four layers: Domain, Application, Infrastructure, and API.