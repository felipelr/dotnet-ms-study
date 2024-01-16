var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    var patients =  Enumerable.Range(1, 5).Select(index =>
        new Patient
        (
            Guid.NewGuid(),
            $"Patient {index}",
            DateOnly.FromDateTime(DateTime.Now.AddDays(index))
        ))
        .ToArray();
    return patients;
})
.WithName("ListAll")
.WithOpenApi();

app.Run();

record Patient(Guid id, string name, DateOnly birthDate)
{
}
