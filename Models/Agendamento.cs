namespace CrudSprint2.Models;

public class Agendamento
{
    public string N_protocolo { get; init; }
    public string Data_hora_agendamento { get; private set; }
    public string Unidade_id_unidade { get; private set; }
    public string Paciente_cpf { get; private set; }
    
    public Agendamento(string n_protocolo, string data_hora_agendamento, string unidade_id_unidade, string paciente_cpf)
    {
        N_protocolo = n_protocolo;
        Data_hora_agendamento = data_hora_agendamento;
        Unidade_id_unidade = unidade_id_unidade;
        Paciente_cpf = paciente_cpf;
    }
    
    public void AtualizarDataHoraAgendamento(string data_hora_agendamento)
    {
        Data_hora_agendamento = data_hora_agendamento;
    }
}
