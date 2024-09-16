using CrudSprint2.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CrudSprint2.Pacientes;

public static class PacientesEndpoints
{
    public static void MapPacientesEndpoints(this WebApplication app)
    {
        var endpointsPacientes = app.MapGroup("pacientes");

        // Adiciona um novo paciente no banco de dados utilizando o método POST
        endpointsPacientes.MapPost("", async (AddPacienteRequest request, AppDbContext context) =>
        {
            // Verifica se já existe um paciente com o mesmo CPF cadastrado
            var verificacao = await context.Pacientes.FirstOrDefaultAsync(paciente => paciente.Cpf == request.Cpf);

            if (verificacao != null)
            {
                return Results.Conflict("Já existe um paciente cadastrado com esse CPF");
            }

            var novoPaciente = new Paciente(request.Cpf, request.Nome_completo, request.Data_nasc,
                request.End_paciente, request.Tel_paciente, request.Email_paciente, request.Senha);

            await context.Pacientes.AddAsync(novoPaciente);
            await context.SaveChangesAsync();

            return Results.Ok(novoPaciente);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Cria um novo paciente", description: "Adiciona um novo paciente ao banco de dados."));

        // Retorna todos os pacientes utilizando o método GET
        endpointsPacientes.MapGet("", async (AppDbContext context) =>
        {
            var todosPacientes = await context.Pacientes.ToListAsync();
            return todosPacientes;
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Lista todos os pacientes", description: "Retorna todos os pacientes cadastrados no sistema."));

        // Retorna um paciente pelo CPF utilizando o método GET
        endpointsPacientes.MapGet("{cpf}", async (string cpf, AppDbContext context) =>
        {
            var paciente = await context.Pacientes.FirstOrDefaultAsync(paciente => paciente.Cpf == cpf);
            return paciente == null ? Results.NotFound() : Results.Ok(paciente);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Obtém um paciente", description: "Retorna um paciente específico pelo CPF."));

        // Atualiza a senha do paciente pelo CPF utilizando o método PUT
        endpointsPacientes.MapPut("/{cpf}/atualizarSenha", async (string cpf, PutPacienteRequest request, AppDbContext context) =>
        {
            var paciente = await context.Pacientes.FirstOrDefaultAsync(paciente => paciente.Cpf == cpf);

            if (paciente == null)
            {
                return Results.NotFound();
            }

            paciente.AtualizarSenha(request.Senha);
            await context.SaveChangesAsync();
            return Results.Ok(paciente);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Atualiza a senha de um paciente", description: "Atualiza a senha de um paciente pelo CPF."));

        // Deleta um paciente pelo CPF utilizando o método DELETE
        endpointsPacientes.MapDelete("{cpf}", async (string cpf, AppDbContext context) =>
        {
            var paciente = await context.Pacientes.FirstOrDefaultAsync(paciente => paciente.Cpf == cpf);

            if (paciente == null)
            {
                return Results.NotFound();
            }

            context.Pacientes.Remove(paciente);
            await context.SaveChangesAsync();

            return Results.Ok("Paciente deletado com sucesso");
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Deleta um paciente", description: "Deleta um paciente específico pelo CPF."));
    }
}
