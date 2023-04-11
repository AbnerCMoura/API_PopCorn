using Microsoft.EntityFrameworkCore;
using PopCornAndCritics.Data;
using FluentValidation.AspNetCore;
using PopCornAndCritics.Models.Validators;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PopCornAndCritics", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var config = builder.Configuration;
string connectionString = config.GetConnectionString("PopCornDB");

builder.Services.AddDbContext<Context>(opt => 
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

#pragma warning disable CS0618 // O tipo ou membro é obsoleto
builder.Services.AddControllers().AddFluentValidation(fv => 
    fv.RegisterValidatorsFromAssemblyContaining<UserDTOValidator>());
#pragma warning restore CS0618 // O tipo ou membro é obsoleto

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
