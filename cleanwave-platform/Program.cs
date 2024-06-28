using cleanwave_platform.Accounts;
using cleanwave_platform.Profiles.Application.Internal.CommandServices;
using cleanwave_platform.Profiles.Application.Internal.QueryServices;
using cleanwave_platform.Profiles.Domain.Repositories;
using cleanwave_platform.Profiles.Domain.Services;
using cleanwave_platform.Profiles.Infraestructure.Persistence.EFC.Repositories;
using cleanwave_platform.Shared.Domain.Repositories;
using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Configuration;
using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Repositories;
using cleanwave_platform.Shared.Interfaces.ASP.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
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

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Account Bounded Context Injection Configuration
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountQueryService, AccountQueryService>();
builder.Services.AddScoped<IAccountCommandService, AccountCommnadService>();

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
