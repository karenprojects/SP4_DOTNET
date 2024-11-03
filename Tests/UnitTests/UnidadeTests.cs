using CrudSprint2.Models;
using Xunit;

namespace CrudSprint2.Tests.UnitTests;

public class UnidadeTests
{
    [Fact]
    public void CriarUnidade_DeveRetornarUnidadeComPropriedadesCorretas()
    {
        // Arrange
        var idUnidade = "U001";
        var enderecoUnidade = "Av. Central, 456";
        var tipoExame = "Raio-X";
        var atendeConvenio = 'S';
        var clinicaCnpj = "12345678000199";

        // Act
        var unidade = new Unidade(idUnidade, enderecoUnidade, tipoExame, atendeConvenio, clinicaCnpj);

        // Assert
        Assert.Equal(idUnidade, unidade.Id_unidade);
        Assert.Equal(enderecoUnidade, unidade.End_unidade);
        Assert.Equal(tipoExame, unidade.Tipo_exame);
        Assert.Equal(atendeConvenio, unidade.Atende_convenio);
        Assert.Equal(clinicaCnpj, unidade.Clinica_cnpj);
    }

    [Fact]
    public void AtualizarTipoExame_DeveAtualizarTipoExameCorretamente()
    {
        // Arrange
        var idUnidade = "U001";
        var enderecoUnidade = "Av. Central, 456";
        var tipoExameInicial = "Raio-X";
        var atendeConvenio = 'S';
        var clinicaCnpj = "12345678000199";

        var unidade = new Unidade(idUnidade, enderecoUnidade, tipoExameInicial, atendeConvenio, clinicaCnpj);

        var novoTipoExame = "Ultrassom";

        // Act
        unidade.AtualizarTipoExame(novoTipoExame);

        // Assert
        Assert.Equal(novoTipoExame, unidade.Tipo_exame);
    }
}
}