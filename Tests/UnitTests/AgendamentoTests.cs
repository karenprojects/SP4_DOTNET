using CrudSprint2.Models;
using Xunit;

namespace CrudSprint2.Tests.UnitTests
{
    public class AgendamentoTests
    {
        [Fact]
        public void CriarAgendamento_DeveRetornarAgendamentoComPropriedadesCorretas()
        {
            // Arrange
            var n_protocolo = "12345";
            var data_hora_agendamento = "2024-11-01T10:00:00";
            var unidade_id_unidade = "U001";
            var paciente_cpf = "12345678900";

            // Act
            var agendamento = new Agendamento(n_protocolo, data_hora_agendamento, unidade_id_unidade, paciente_cpf);

            // Assert
            Assert.Equal(n_protocolo, agendamento.N_protocolo);
            Assert.Equal(data_hora_agendamento, agendamento.Data_hora_agendamento);
            Assert.Equal(unidade_id_unidade, agendamento.Unidade_id_unidade);
            Assert.Equal(paciente_cpf, agendamento.Paciente_cpf);
        }
    }
}