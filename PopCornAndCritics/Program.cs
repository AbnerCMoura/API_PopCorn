using Microsoft.EntityFrameworkCore;
using PopCornAndCritics.Data;
using FluentValidation.AspNetCore;
using PopCornAndCritics.Models;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;
string ConnectionString = config.GetConnectionString("PopCornDB");

builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(ConnectionString));

#pragma warning disable CS0618 // O tipo ou membro é obsoleto
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserDTOValidator>());
#pragma warning restore CS0618 // O tipo ou membro é obsoleto


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
