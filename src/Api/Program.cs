using System.Security.Claims;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
builder.Services.AddTransient<IBaseService, BuildService>();
builder.Services.AddTransient<IBaseService, GameService>();

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters.ValidateAudience = false;
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });
});
var app = builder.Build();

app.UseCors();
app.UseHttpsRedirection();

app.MapGet("identity", (ClaimsPrincipal user) => user.Claims.Select(c => new { c.Type, c.Value }))
    .RequireAuthorization("ApiScope");

app.MapControllers();
app.Run();


