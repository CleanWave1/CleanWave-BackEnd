using cleanwave_platform.Accounts;
using cleanwave_platform.Accounts.Infrastructure.Persistence.EFC.Repositories;
using cleanwave_platform.iam.Application.CommandServices;
using cleanwave_platform.iam.Application.OutboundServices;
using cleanwave_platform.iam.Application.QueryServices;
using cleanwave_platform.iam.Domain.Repositories;
using cleanwave_platform.iam.Domain.Services;
using cleanwave_platform.iam.Infrastructure.Hashing.BCrypt.Services;
using cleanwave_platform.iam.Infrastructure.Persistence.EFC.Repositories;
using cleanwave_platform.iam.Infrastructure.Pipeline.Extensions;
using cleanwave_platform.iam.Infrastructure.Tokens.JWT.Configuration;
using cleanwave_platform.iam.Infrastructure.Tokens.JWT.Services;
using cleanwave_platform.iam.Interfaces.ACL;
using cleanwave_platform.iam.Interfaces.ACL.Services;
using cleanwave_platform.Shared.Domain.Repositories;
using cleanwave_platform.Shared.Infraestructure.Persistance.EFC.Configuration;
using cleanwave_platform.Shared.Infraestructure.Persistance.EFC.Repositories;
using cleanwave_platform.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using cleanwave_platform.Profiles.Application.Internal.CommandServices;
using cleanwave_platform.Profiles.Application.Internal.QueryServices;
using cleanwave_platform.Profiles.Domain.Repositories;
using cleanwave_platform.Profiles.Domain.Services;
using cleanwave_platform.Profiles.Infraestructure.Persistence.EFC.Repositories;
using cleanwave_platform.Shared.Interfaces.ASP.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Account Bounded Context Injection Configuration
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountQueryService, AccountQueryService>();
builder.Services.AddScoped<IAccountCommandService, AccountCommnadService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
//Dependency Injection

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// TokenSettings Configuration

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryServices, UserQueryServices>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// Customer Bounded Context Injection Configuration
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerQueryService, CustomerQueryService>();
builder.Services.AddScoped<ICustomerCommandService, CustomerCommandService>();

// Cleaning Entrepreneur Bounded Context Injection Configuration
builder.Services.AddScoped<ICleaningEntrepreneurRepository, CleaningEntrepreneurRepository>();
builder.Services.AddScoped<ICleaningEntrepreneurQueryService, CleaningEntrepreneurQueryService>();
builder.Services.AddScoped<ICleaningEntrepreneurCommandService, CleaningEntrepreneurCommandService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

// Add Authorization Middleware to Pipeline
app.UseRequestAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
