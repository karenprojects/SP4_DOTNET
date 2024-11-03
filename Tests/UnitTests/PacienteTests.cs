using CrudSprint2.Models;
using Xunit;

namespace CrudSprint2.Tests.UnitTests;

public class PacienteTests
{
    [Fact]
    public void CriarPaciente_DeveRetornarPacienteComPropriedadesCorretas()
    {
        // Arrange
        var cpf = "12345678900";
        var nomeCompleto = "João da Silva";
        var dataNasc = "1990-01-01";
        var endereco = "Rua A, 123";
        var telefone = "11999999999";
        var email = "joao.silva@email.com";
        var senha = "senhaSegura";

        // Act
        var paciente = new Paciente(cpf, nomeCompleto, dataNasc, endereco, telefone, email, senha);

        // Assert
        Assert.Equal(cpf, paciente.Cpf);
        Assert.Equal(nomeCompleto, paciente.Nome_completo);
        Assert.Equal(dataNasc, paciente.Data_nasc);
        Assert.Equal(endereco, paciente.End_paciente);
        Assert.Equal(telefone, paciente.Tel_paciente);
        Assert.Equal(email, paciente.Email_paciente);
        Assert.Equal(senha, paciente.Senha);
    }

    [Fact]
    public void AtualizarSenha_DeveAtualizarSenhaCorretamente()
    {
        // Arrange
        var cpf = "12345678900";
        var nomeCompleto = "João da Silva";
        var dataNasc = "1990-01-01";
        var endereco = "Rua A, 123";
        var telefone = "11999999999";
        var email = "joao.silva@email.com";
        var senhaInicial = "senhaSegura";

        var paciente = new Paciente(cpf, nomeCompleto, dataNasc, endereco, telefone, email, senhaInicial);

        var novaSenha = "novaSenhaSegura";

        // Act
        paciente.AtualizarSenha(novaSenha);

        // Assert
        Assert.Equal(novaSenha, paciente.Senha);
    }
}
}