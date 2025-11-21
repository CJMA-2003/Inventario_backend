using Inventario.Data;
using Microsoft.EntityFrameworkCore;
using Inventario.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION", EnvironmentVariableTarget.User) ?? builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllersWithViews();
builder.Services.Scan(scan => scan
    .FromAssemblyOf<StoreService>()      // una clase de referencia
    .AddClasses(classes => classes.InNamespaceOf<StoreService>())
    .AsSelf()
    .WithScopedLifetime()
);


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.Run();
