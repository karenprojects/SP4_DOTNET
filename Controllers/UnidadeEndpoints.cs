using CrudSprint2.Data;
using CrudSprint2.Models;
using CrudSprint2.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization; // Importar para usar [Authorize]

namespace CrudSprint2.Controllers;

public static class UnidadeEndpoints
{
    public static void MapUnidadeEndpoints(this WebApplication app)
    {
        var endpointsUnidades = app.MapGroup("unidades");

        // Adiciona uma nova unidade no banco de dados utilizando o método POST (Protegido com [Authorize])
        endpointsUnidades.MapPost("", [Authorize] async (AddUnidadeRequest request, AppDbContext context) =>
        {
            var verificacao = await context.Unidades.
                FirstOrDefaultAsync(unidade => unidade.Id_unidade == request.Id_unidade);

            if (verificacao != null)
            {
                return Results.Conflict("Já existe uma unidade cadastrada com esse Id");
            }

            var novaUnidade = new Unidade(request.Id_unidade, request.End_unidade, request.Tipo_exame,
                request.Atende_convenio, request.Clinica_cnpj);

            await context.Unidades.AddAsync(novaUnidade);
            await context.SaveChangesAsync();

            return Results.Ok(novaUnidade);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Cria uma nova unidade", description: "Adiciona uma nova unidade ao banco de dados."));

        // Retorna todas as unidades cadastradas no banco de dados utilizando o método GET (Protegido com [Authorize])
        endpointsUnidades.MapGet("", [Authorize] async (AppDbContext context) =>
        {
            var todasUnidades = await context.Unidades.ToListAsync();
            return Results.Ok(todasUnidades);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Lista todas as unidades", description: "Retorna todas as unidades cadastradas no sistema."));

        // Retorna uma unidade específica pelo id utilizando o método GET (Protegido com [Authorize])
        endpointsUnidades.MapGet("{id_unidade}", [Authorize] async (string id_unidade, AppDbContext context) =>
        {
            var unidade = await context.Unidades.FirstOrDefaultAsync(unidade => unidade.Id_unidade == id_unidade);
            return unidade == null ? Results.NotFound() : Results.Ok(unidade);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Obtém uma unidade", description: "Retorna uma unidade específica pelo Id_unidade."));

        // Atualiza o tipo de exame de uma unidade específica pelo id utilizando o método PUT (Protegido com [Authorize])
        endpointsUnidades.MapPut("{id_unidade}", [Authorize] async (string id_unidade, PutUnidadeRequest request, AppDbContext context) =>
        {
            var unidade = await context.Unidades.FirstOrDefaultAsync(unidade => unidade.Id_unidade == id_unidade);

            if (unidade == null)
            {
                return Results.NotFound();
            }

            unidade.AtualizarTipoExame(request.Tipo_exame);
            await context.SaveChangesAsync();

            return Results.Ok(unidade);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Atualiza uma unidade", description: "Atualiza o tipo de exame de uma unidade pelo Id_unidade."));

        // Deleta uma unidade específica pelo id utilizando o método DELETE (Protegido com [Authorize])
        endpointsUnidades.MapDelete("{id_unidade}", [Authorize] async (string id_unidade, AppDbContext context) =>
        {
            var unidade = await context.Unidades.FirstOrDefaultAsync(unidade => unidade.Id_unidade == id_unidade);

            if (unidade == null)
            {
                return Results.NotFound();
            }

            context.Unidades.Remove(unidade);
            await context.SaveChangesAsync();

            return Results.Ok();
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Deleta uma unidade", description: "Deleta uma unidade específica pelo Id_unidade."));
    }
}