using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using MongoDB.Driver;
using WebApplication1.dto;
using WebApplication1.repository;
using WebApplication1.service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<MunicipioDto>("Municipios").EntityType.HasKey(m => m.Id);

builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();
builder.Services.AddScoped<IMunicipioService, MunicipioService>();
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddControllers()
    .AddOData(opt =>
        opt.AddRouteComponents("odata", modelBuilder.GetEdmModel())
           .Select().Filter().OrderBy().Expand().SetMaxTop(100));

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

// Remova ou comente a linha abaixo para desabilitar o redirecionamento de HTTPS
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();