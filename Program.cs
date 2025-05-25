using Mottu.Infrastructure.Data;
using Mottu.Application.Mapping;
using Mottu.Application.Interfaces;
using Mottu.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));


builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IPatioService, PatioService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); 

app.UseAuthorization();
app.MapControllers();
app.Run();