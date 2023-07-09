using Application.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


// this will create Kestrel server and read configuration file
var builder = WebApplication.CreateBuilder(args);


// allow cors name
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// add allow cors to Services
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins, policy => {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddMediatR(typeof(List.Handler));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// using Microsoft.EntityFrameworkCore;
builder.Services.AddSqlServer<DataContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Start migration
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try{
    var context = services.GetRequiredService<DataContext>();
    // because we use async Seed, we need to use MigrateAcync here
    await context.Database.MigrateAsync();
    // start seeding data to database table
    await Seed.SeedData(context);
}catch(Exception ex){
    System.Console.WriteLine(ex.Message);
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration.");
}

app.Run();
