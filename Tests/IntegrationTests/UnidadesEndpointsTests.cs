using CrudSprint2.Data;
using CrudSprint2.Models;
using CrudSprint2.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CrudSprint2.Tests.IntegrationTests;

public class UnidadesEndpointsTests
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
    public async void CriarNovaUnidade_DeveSalvarNoBancoDeDados()
    {
        // Arrange
        var context = GetDbContext();
        var request = new AddUnidadeRequest("U001", 
            "Av. Central", 
            "Raio-X", 
            'S', 
            "12345678000199");

        // Act
        var novaUnidade = new Unidade(request.Id_unidade,
            request.End_unidade,
            request.Tipo_exame,
            request.Atende_convenio,
            request.Clinica_cnpj);

        await context.Unidades.AddAsync(novaUnidade);
        await context.SaveChangesAsync();

        // Assert
        var unidadesSalvas = await context.Unidades.ToListAsync();
        Assert.Single(unidadesSalvas); // Verifica se há apenas uma unidade salva no banco.
    }
}
}