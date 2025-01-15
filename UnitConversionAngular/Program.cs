var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// localhost:4200
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("https://localhost:4200") // Adjust with the correct URL for your UI
                          .AllowAnyMethod()  // Allow all HTTP methods (GET, POST, etc.)
                          .AllowAnyHeader()); // Allow all headers
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowLocalhost"); 

app.UseAuthorization();

app.MapControllers();

app.Run();
