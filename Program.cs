using AutoMapper;
using Mottu.Application.Interfaces;
using Mottu.Application.Mapping;
using Mottu.Infrastructure.Data;
using Mottu.API.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(Environment.GetEnvironmentVariable("ORACLE_CONN")));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IPatioService, PatioService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();

