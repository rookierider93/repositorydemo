using MongoDB.Driver;
using todo.api.models;
using todo.api.repositories;
using todo.api.services;

var builder = WebApplication.CreateBuilder(args);

//Added Ioption for datbasesetting configuration
builder.Services.Configure<TodoDatabaseSettings>(
    builder.Configuration.GetSection("todoDatabase")
    );

//Dependency Injection for TodoService
builder.Services.AddSingleton<TodoService>();

builder.Services.AddScoped<userRepository>();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/users",async (userRepository repository, user newUser) =>
{
    await repository.CreateAsync(newUser);
    return Results.Created($"/users/{newUser.Id}", newUser);
});

app.MapGet("/users", async (userRepository repository) =>
{
    var users = await repository.GetAllAsync();
    return Results.Ok(users);
});

app.Run();

