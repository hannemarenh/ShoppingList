using Microsoft.Extensions.Options;
using MongoDB.Driver;
using server.Models;
using server.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.Configure<ListItemStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(ListItemStoreDatabaseSettings))); // get settings from appsettings to ListItemStoreDatabase setting
builder.Services.AddSingleton<IListItemStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ListItemStoreDatabaseSettings>>().Value); 
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ListItemStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IListItemService, ListItemService>();


builder.Services.AddControllers();

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

// app.UseDefaultFiles();
// app.UseStaticFiles();

// app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
