using Coding_Task_Api.Application.Mappings;
using Coding_Task_Api.Domain.Interfaces;
using Coding_Task_Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


//  Add DB Context and Unit of Work for data persistence
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CustomerOrderDb")); // Using an in-memory database

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// This scans the assembly where your handlers are located to find them automatically.
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// This finds the MappingProfile class and registers its configurations.
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 4. Add standard API services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // This allows Swagger to display the XML comments you write above your methods.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
