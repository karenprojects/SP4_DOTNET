using CrudSprint2.Data;
using CrudSprint2.Models;
using CrudSprint2.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CrudSprint2.Tests.IntegrationTests;

public class PacientesEndpointsTests
{
    private AppDbContext GetDbContext()
    {
        // Usando banco de dados em memória para os testes.
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async void CriarNovoPaciente_DeveSalvarNoBancoDeDados()
    {
        // Arrange
        var context = GetDbContext();
        var request = new AddPacienteRequest("12345678900", "João da Silva", 
            "1990-01-01", "Rua A", "11999999999", 
            "joao.silva@email.com", "senhaSegura");

        // Act
        var novoPaciente = new Paciente(request.Cpf, request.Nome_completo,
            request.Data_nasc, request.End_paciente,
            request.Tel_paciente, request.Email_paciente,
            request.Senha);

        await context.Pacientes.AddAsync(novoPaciente);
        await context.SaveChangesAsync();

        // Assert
        var pacientesSalvos = await context.Pacientes.ToListAsync();
        Assert.Single(pacientesSalvos); // Verifica se há apenas um paciente salvo no banco.
    }
}
}