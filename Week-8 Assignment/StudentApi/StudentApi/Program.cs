using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentApi.Infrastructure.Data;
using System.Text;

namespace StudentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // =============================================
            // 1. CONTROLLERS
            // =============================================
            builder.Services.AddControllers();

            // =============================================
            // 2. DATABASE (EF Core + SQL Server)
            // =============================================
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // =============================================
            // 3. CORS — must be registered before building
            // =============================================
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // =============================================
            // 4. JWT AUTHENTICATION
            // =============================================
            var jwtKey     = builder.Configuration["Jwt:Key"]!;
            var jwtIssuer  = builder.Configuration["Jwt:Issuer"]!;
            var jwtAudience = builder.Configuration["Jwt:Audience"]!;

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer           = true,
                    ValidateAudience         = true,
                    ValidateLifetime         = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer              = jwtIssuer,
                    ValidAudience            = jwtAudience,
                    IssuerSigningKey         = new SymmetricSecurityKey(
                                                   Encoding.UTF8.GetBytes(jwtKey)),
                    ClockSkew                = TimeSpan.Zero   // no slack on expiry
                };
            });

            builder.Services.AddAuthorization();

            // =============================================
            // 5. SWAGGER with JWT Bearer support
            //    IMPORTANT: Use ApiKey style so Swagger does NOT
            //    auto-prepend "Bearer " — user pastes: Bearer <token>
            // =============================================
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title       = "Student Management API",
                    Version     = "v1",
                    Description = "Clean Architecture API with JWT Role-Based Auth"
                });

                // Define the security scheme
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name         = "Authorization",
                    Type         = SecuritySchemeType.ApiKey,   // ApiKey = user types full value
                    In           = ParameterLocation.Header,
                    Description  = "Enter: Bearer {your JWT token}\n\nExample: Bearer eyJhbGci..."
                });

                // Apply the scheme globally (all endpoints require it unless [AllowAnonymous])
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id   = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // =============================================
            // 6. PROBLEM DETAILS (structured error responses)
            // =============================================
            builder.Services.AddProblemDetails();

            var app = builder.Build();

            // =============================================
            // MIDDLEWARE PIPELINE — ORDER MATTERS
            // =============================================

            // Always expose Swagger (remove the IsDevelopment check for easy testing)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management API v1");
                c.RoutePrefix = "swagger";   // accessible at /swagger
            });

            // CORS must come BEFORE authentication
            app.UseCors("AllowAll");

            // HTTPS redirect after CORS
            app.UseHttpsRedirection();

            // Auth middleware — MUST be in this exact order
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}