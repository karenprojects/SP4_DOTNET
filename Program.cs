using CrudSprint2.Agendamentos;
using CrudSprint2.Data;
using CrudSprint2.Pacientes;
using CrudSprint2.Unidades;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});
builder.Services.AddScoped<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configurando os endpoints
app.MapPacientesEndpoints();
app.MapAgendamentosEndpoints();
app.MapUnidadeEndpoints();

app.Run();