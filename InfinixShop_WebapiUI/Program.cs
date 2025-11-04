using InfinixShop_Common;
using InfinixShop_DataLogic;
using InfinixShop_BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI for API documentation and testing.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// register FileSettings so it can be injected via IOptions<FileSettings>
builder.Services.Configure<FileSettings>(builder.Configuration.GetSection("FileSettings"));
// bind EmailSettings
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));



builder.Services.AddTransient<IPhoneDataService, JsonFilePhoneDataService>();
//builder.Services.AddTransient<IPhoneDataService, TextFilePhoneDataService>();

var app = builder.Build();

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
