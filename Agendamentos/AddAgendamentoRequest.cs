namespace CrudSprint2.Agendamentos;

public record AddAgendamentoRequest(string N_protocolo, string Data_hora_agendamento, 
    string Unidade_id_unidade, string Paciente_cpf);