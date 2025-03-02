using Microsoft.EntityFrameworkCore;
using space_colonization_api.Data;
using space_colonization_api.Repositories.Planets;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "space_colonization_api", Version = "v1" });
});
builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}
builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins(
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<SpaceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
