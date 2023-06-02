using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCastGroupSebrae.API.Interface;
using TCastGroupSebrae.API.Repository;
using TCastGroupSebrae.API.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TCastGroupSebraeAPIContext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("TCastGroupSebraeAPIContext") ?? throw new InvalidOperationException("Connection string 'TCastGroupSebraeAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IViaCepService,ViaCepService>();
builder.Services.AddTransient<IContaRepositorio, ContaRepositorio>();

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
