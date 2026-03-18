using AttendanceTracker.Application.Service;
using AttendanceTracker.Domain.Interface.IRepository;
using AttendanceTracker.Infrastructure.Dbcontext;
using AttendanceTracker.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IServiceRole, RoleService>();
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AttendanceDbContext>(x =>
    x.UseSqlServer(cs));
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
