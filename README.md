# Employee Management System

## Prerequisites
- .NET 9 SDK
- SQL Server

## How to Run Locally
1. Clone the repository.
2. Run `docker-compose up` to start the application and database.
3. Navigate to `http://localhost` to access the API.

## Environment Variables
- `ConnectionStrings__DefaultConnection`
- `Jwt__Key`
- `Jwt__Issuer`

## API Endpoints
- `POST /auth/register`
- `POST /auth/login`
- `GET /employees/{id}`
- `GET /departments/{id}`

## Architecture Overview
The application follows Clean Architecture principles, separating concerns into Domain, Application, Infrastructure, and API layers.