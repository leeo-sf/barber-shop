using BarberShop.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.ConfigDbContext(configuration);

builder.Services.ConfigureApiVersioning();

builder.Services.ConfigureServices();

builder.Services.ConfigureSwagger();

builder.Services.ConfigureMediator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();