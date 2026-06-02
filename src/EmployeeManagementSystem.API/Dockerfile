FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY [YOUR_PROJECT_NAME].sln .
COPY src/EmployeeManagementSystem.API/*.csproj src/EmployeeManagementSystem.API/
COPY src/EmployeeManagementSystem.Application/*.csproj src/EmployeeManagementSystem.Application/
COPY src/EmployeeManagementSystem.Domain/*.csproj src/EmployeeManagementSystem.Domain/
COPY src/EmployeeManagementSystem.Infrastructure/*.csproj src/EmployeeManagementSystem.Infrastructure/
RUN dotnet restore
COPY . .
WORKDIR /src/src/EmployeeManagementSystem.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeManagementSystem.API.dll"]