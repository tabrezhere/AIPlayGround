# Employee Management System

## Prerequisites
- .NET 9 SDK
- SQL Server

## How to Run Locally
1. Clone the repository.
2. Navigate to the `src` directory.
3. Run `docker-compose up` to start the application.

## Environment Variables
- `ConnectionStrings__DefaultConnection`: SQL Server connection string.
- `Jwt__Key`: Secret key for JWT.
- `Jwt__Issuer`: Issuer for JWT.
- `Jwt__Audience`: Audience for JWT.

## API Endpoint List
- `GET /api/employee`: Get all employees.
- `GET /api/employee/{id}`: Get employee by ID.
- `POST /api/employee`: Create a new employee.
- `PUT /api/employee`: Update an existing employee.
- `DELETE /api/employee/{id}`: Delete an employee.
- `POST /api/auth/login`: Login and get JWT token.

## Architecture Overview
This application follows the Clean Architecture pattern, separating concerns into Domain, Application, Infrastructure, and API layers.