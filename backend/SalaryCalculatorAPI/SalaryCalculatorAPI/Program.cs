using SalaryCalculatorAPI.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        // only for this project and its simplicity
        policy.AllowAnyOrigin() 
              .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddScoped<ISalaryCalculator, SalaryCalculatorHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
