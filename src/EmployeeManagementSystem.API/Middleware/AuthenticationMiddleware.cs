using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.API.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Custom authentication logic can be added here
        await _next(context);
    }
}