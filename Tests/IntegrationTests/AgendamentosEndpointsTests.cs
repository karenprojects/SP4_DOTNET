using CrudSprint2.Data;
using CrudSprint2.Models;
using CrudSprint2.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CrudSprint2.Tests.IntegrationTests;

public class AgendamentosEndpointsTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async void CriarNovoAgendamento_DeveSalvarNoBancoDeDados()
    {
        // Arrange
        var context = GetDbContext();
        var request = new AddAgendamentoRequest("12345", "2024-11-01T10:00:00", "U001", "12345678900");

        // Act
        var novoAgendamento = new Agendamento(request.N_protocolo, request.Data_hora_agendamento,
            request.Unidade_id_unidade, request.Paciente_cpf);

        await context.Agendamentos.AddAsync(novoAgendamento);
        await context.SaveChangesAsync();

        // Assert
        var agendamentosSalvos = await context.Agendamentos.ToListAsync();
        Assert.Single(agendamentosSalvos); // Verifica se há apenas um agendamento salvo no banco.
    }
}
}