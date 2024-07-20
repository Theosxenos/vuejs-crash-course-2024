using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Allow requests from this origin
            .AllowAnyMethod() // Allow any HTTP method (GET, POST, etc.)
            .AllowAnyHeader(); // Allow any headers
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

async Task<List<TaskItem>> LoadTasksAsync(string filePath)
{
    using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    return (await JsonSerializer.DeserializeAsync<List<TaskItem>>(stream, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase}))!;
}

var tasks = await LoadTasksAsync("tasks.json");

app.MapPost("/tasks", (TaskItem newTask) =>
{
    if (newTask.Id == 0)
    {
        var highestId = tasks.Any() ? tasks.Max(t => t.Id) : 0;
        newTask = newTask with { Id = highestId + 1 };
    }
    
    tasks.Add(newTask);
    
    return Results.Created($"/tasks/{newTask.Id}", newTask);
});

app.MapGet("/tasks", () => tasks)
    .WithName("GetTasks")
    .WithOpenApi();

app.MapGet("/tasks/{id:int}", (int id) => tasks.SingleOrDefault(t => t.Id == id))
    .WithName("GetTask")
    .WithOpenApi();

app.MapDelete("/tasks/{id:int}", (int id) => tasks.Remove(tasks.SingleOrDefault(t => t.Id == id)!))
    .WithOpenApi();

app.Run();

record TaskItem(int UserId, int Id, string Title, bool Completed);