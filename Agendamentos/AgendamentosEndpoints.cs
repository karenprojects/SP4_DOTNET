using CrudSprint2.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;  // Importando as anotações do Swagger

namespace CrudSprint2.Agendamentos;

public static class AgendamentosEndpoints
{
    public static void MapAgendamentosEndpoints(this WebApplication app)
    {
        var endpointsAgendamentos = app.MapGroup("agendamentos");

        // Adiciona um novo agendamento no banco de dados utilizando o método POST
        endpointsAgendamentos.MapPost("", async (AddAgendamentoRequest request, AppDbContext context) =>
        {
            var verificacao = await context.Agendamentos.
                FirstOrDefaultAsync(agendamento => agendamento.N_protocolo == request.N_protocolo);

            if (verificacao != null)
            {
                return Results.Conflict("Já existe um agendamento com esse N_protocolo");
            }

            var novoAgendamento = new Agendamento(request.N_protocolo, request.Data_hora_agendamento, 
                request.Unidade_id_unidade, request.Paciente_cpf);

            await context.Agendamentos.AddAsync(novoAgendamento);
            await context.SaveChangesAsync();

            return Results.Ok(novoAgendamento);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Cria um novo agendamento", description: "Adiciona um agendamento ao banco de dados."));

        // Retorna todos os agendamentos cadastrados no banco de dados utilizando o método GET
        endpointsAgendamentos.MapGet("", async (AppDbContext context) =>
        {
            var todosAgendamentos = await context.Agendamentos.ToListAsync();
            return Results.Ok(todosAgendamentos);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Lista todos os agendamentos", description: "Retorna todos os agendamentos cadastrados no sistema."));

        // Retorna um agendamento específico pelo N_protocolo utilizando o método GET
        endpointsAgendamentos.MapGet("{n_protocolo}", async (string n_protocolo, AppDbContext context) =>
        {
            var agendamento = await context.Agendamentos.FirstOrDefaultAsync(agendamento => agendamento.N_protocolo == n_protocolo);
            return agendamento == null ? Results.NotFound() : Results.Ok(agendamento);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Obtem um agendamento", description: "Retorna um agendamento específico pelo N_protocolo."));

        // Atualiza a data e hora de um agendamento específico pelo N_protocolo utilizando o método PUT
        endpointsAgendamentos.MapPut("{n_protocolo}", async (string n_protocolo, PutAgendamentoRequest request, AppDbContext context) =>
        {
            var agendamento = await context.Agendamentos.FirstOrDefaultAsync(agendamento => agendamento.N_protocolo == n_protocolo);

            if (agendamento == null)
            {
                return Results.NotFound();
            }

            agendamento.AtualizarDataHoraAgendamento(request.Data_hora_agendamento);
            await context.SaveChangesAsync();
            return Results.Ok(agendamento);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Atualiza um agendamento", description: "Atualiza a data e hora de um agendamento pelo N_protocolo."));

        // Deleta um agendamento específico pelo N_protocolo utilizando o método DELETE
        endpointsAgendamentos.MapDelete("{n_protocolo}", async (string n_protocolo, AppDbContext context) =>
        {
            var agendamento = await context.Agendamentos.FirstOrDefaultAsync(agendamento => agendamento.N_protocolo == n_protocolo);

            if (agendamento == null)
            {
                return Results.NotFound();
            }

            context.Agendamentos.Remove(agendamento);
            await context.SaveChangesAsync();
            return Results.Ok();
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Deleta um agendamento", description: "Deleta um agendamento específico pelo N_protocolo."));
    }
}
