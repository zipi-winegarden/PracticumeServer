using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySqlConnector;
using PracticumeServer.API.Mapping;
using PracticumeServer.Core.mapping;
using PracticumeServer.Core.Repositories;
using PracticumeServer.Core.Services;
using PracticumeServer.Data;
using PracticumeServer.Data.Repositories;
using PracticumeServer.Service.Services;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeServise, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

//builder.Services.AddDbContext<DataContext>();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);


builder.Services.AddCors(
    opt => opt.AddPolicy("MyPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }));

builder.Services.AddAutoMapper(typeof(ControllerMappingProfile), typeof(CoreMappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
