using CarsApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarsContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<CarsContext>();
        context.Database.EnsureCreated();
    }
}

app.UseHttpsRedirection();

app.MapGet("/cars", (CarsContext context) =>
{
    return context.Cars.ToList();
})
.WithName("GetCars")
.WithOpenApi();


app.MapPost("/cars", (CarsContext context, Car car) =>
{
    context.Cars.Add(car);
    context.SaveChanges();

    return Results.Ok();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
