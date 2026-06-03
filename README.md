# Employee Management System

## Prerequisites
- .NET 9 SDK
- SQL Server

## How to Run Locally
1. Clone the repository.
2. Navigate to the project directory.
3. Run `docker-compose up` to start the application and the database.

## Environment Variables
- `ConnectionStrings__DefaultConnection`: Connection string for SQL Server.
- `Jwt__Key`: Secret key for JWT.
- `Jwt__Issuer`: Issuer for JWT.
- `Jwt__Audience`: Audience for JWT.

## API Endpoints
- `GET /api/employee`: Get all employees.
- `GET /api/employee/{id}`: Get employee by ID.
- `POST /api/employee`: Add a new employee.
- `PUT /api/employee/{id}`: Update an employee.
- `DELETE /api/employee/{id}`: Delete an employee.
- `POST /api/auth/register`: Register a new user.
- `POST /api/auth/login`: Login and get JWT token.

## Architecture Overview
This application follows Clean Architecture principles with four layers: Domain, Application, Infrastructure, and API.