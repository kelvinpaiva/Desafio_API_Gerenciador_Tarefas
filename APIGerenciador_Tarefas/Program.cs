using APIGerenciador_Tarefas.Development;
using APIGerenciador_Tarefas.Interface;
using APIGerenciador_Tarefas.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<wnbokcfxContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ToDoManagerContext")));

builder.Services.AddSwaggerGen(opt =>
{  
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});


builder.Services.AddTransient<Interface_Projeto, Projeto_Develop>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
