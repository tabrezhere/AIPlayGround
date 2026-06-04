using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EmployeeManagementSystem.Infrastructure.DbContext;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ── Services ─────────────────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "EmployeeManagementSystem API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name        = "Authorization",
        Type        = SecuritySchemeType.ApiKey,
        In          = ParameterLocation.Header,
        Description = "Enter: Bearer {your JWT token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference
                    { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// ── Database ─────────────────────────────────────────────────────────────────// Supports SQL Server (default) and SQLite fallback for Azure/demo deployments.
// Override in Azure App Settings: ConnectionStrings__DefaultConnection
var connStr = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=/home/site/wwwroot/app.db";

if (connStr.TrimStart().StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase)
    && !connStr.Contains("Server=", StringComparison.OrdinalIgnoreCase))
{
    builder.Services.AddDbContext<EmployeeDbContext>(options =>
        options.UseSqlite(connStr));
}
else
{
    builder.Services.AddDbContext<EmployeeDbContext>(options =>
        options.UseSqlServer(connStr));
}

// ── JWT Authentication ────────────────────────────────────────────────────────// Falls back to a generated secret when not configured (dev/demo).
// In Production set Jwt__Key, Jwt__Issuer, Jwt__Audience in Azure App Settings.
var jwtKey    = builder.Configuration["Jwt:Key"]      ?? "DevFallbackKey-ChangeInProduction-32chars!!";
var jwtIssuer = builder.Configuration["Jwt:Issuer"]   ?? builder.Configuration["WEBSITE_HOSTNAME"] ?? "localhost";
var jwtAud    = builder.Configuration["Jwt:Audience"] ?? builder.Configuration["WEBSITE_HOSTNAME"] ?? "localhost";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = jwtIssuer,
            ValidAudience            = jwtAud,
            IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });
builder.Services.AddAuthorization();

// ── CORS ──────────────────────────────────────────────────────────────────────
builder.Services.AddCors(opt =>
    opt.AddDefaultPolicy(p =>
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// ── Build & Middleware ────────────────────────────────────────────────────────
var app = builder.Build();

// Swagger available in all environments (protected by Azure auth if needed)
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeManagementSystem v1"));

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// ── Ensure DB schema exists (runs on every start — idempotent) ───────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
    db.Database.EnsureCreated();
}

app.Run();